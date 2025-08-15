using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Services;
using Northwind.Core.Models;
using NorthwindApp_DA.CrearEditRegisFrm;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindApp_DA
{
    public partial class OrderFrm : Form
    {
        private List<Order> _ordenesEnSesion;
        private readonly IServiceProvider _serviceProvider;
        private readonly OrderService _orderService;
        private readonly MenuFrm _menuFrm;

        public OrderFrm(IServiceProvider serviceProvider, OrderService orderService, MenuFrm menuFrm)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _menuFrm = menuFrm ?? throw new ArgumentNullException(nameof(menuFrm));
            _ordenesEnSesion = new List<Order>();
            CargarOrdenesEnSesionAsync().ConfigureAwait(false); // Carga asíncrona al iniciar
        }

        private void OrderFrm_Load(object sender, EventArgs e)
        {
            CargarCombosAsync().ConfigureAwait(false); // Configuración asíncrona de combos
        }

        private async Task CargarOrdenesEnSesionAsync()
        {
            try
            {
                if (_ordenesEnSesion == null || !_ordenesEnSesion.Any())
                {
                    OrderDgv.DataSource = null;
                    return;
                }
                var detalles = _ordenesEnSesion.SelectMany(o => o.OrderDetails.Select(d => new
                {
                    o.OrderId,
                    o.OrderDate,
                    Producto = d.Product.ProductName,
                    Categoria = d.Product.Category?.CategoryName ?? "N/A",
                    Suplidor = d.Product.Supplier?.CompanyName ?? "N/A",
                    d.UnitPrice,
                    d.Quantity,
                    d.Discount,
                    ExtendedPrice = d.UnitPrice * d.Quantity * (1 - (decimal)d.Discount)
                })).ToList();

                OrderDgv.DataSource = detalles;
                OrderDgv.Refresh();

                await CalcularTotalesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar órdenes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CalcularTotalesAsync()
        {
            try
            {
                if (_ordenesEnSesion.Count == 0)
                {
                    TxtSubtotal.Text = "";
                    TxtFreight.Text = "";
                    TxtTotal.Text = "";
                    return;
                }

                decimal subtotal = _ordenesEnSesion
                    .SelectMany(o => o.OrderDetails)
                    .Sum(d => d.UnitPrice * d.Quantity * (1 - (decimal)d.Discount));

                decimal freight = subtotal * 0.18m;

                foreach (var orden in _ordenesEnSesion)
                {
                    orden.Freight = freight;
                }

                decimal total = subtotal + freight;

                TxtSubtotal.Text = subtotal.ToString("C");
                TxtFreight.Text = freight.ToString("C");
                TxtTotal.Text = total.ToString("C");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular totales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarCombosAsync()
        {
            try
            {
                var clientes = await _orderService.GetCustomersAsync();
                ClienteCbx.DataSource = clientes;
                ClienteCbx.DisplayMember = "CompanyName";
                ClienteCbx.ValueMember = "CustomerId";

                var empleados = await _orderService.GetEmployeesAsync();
                EmpleadoCbx.DataSource = empleados;
                EmpleadoCbx.DisplayMember = "LastName";
                EmpleadoCbx.ValueMember = "EmployeeId";

                var transportistas = await _orderService.GetShippersAsync();
                ShipViaCbx.DataSource = transportistas;
                ShipViaCbx.DisplayMember = "CompanyName";
                ShipViaCbx.ValueMember = "ShipperId";

                var destinatarios = (await _orderService.GetAllAsync())
                    .Select(o => o.ShipName)
                    .Where(s => !string.IsNullOrEmpty(s))
                    .Distinct()
                    .ToList();
                ShipNameCbx.DataSource = destinatarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar combos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<Order> CrearNuevaOrdenAsync()
        {
            var nuevaOrden = new Order
            {
                CustomerId = ClienteCbx.SelectedValue?.ToString(),
                EmployeeId = EmpleadoCbx.SelectedValue != null ? (int?)EmpleadoCbx.SelectedValue : null,
                OrderDate = DtOrderDate.Value,
                RequiredDate = DtRequiredDate.Value,
                ShippedDate = DtShippedDate.Value,
                ShipVia = ShipViaCbx.SelectedValue != null ? (int?)ShipViaCbx.SelectedValue : null,
                Freight = decimal.TryParse(TxtFreight.Text, out var freight) ? freight : 0,
                ShipName = ShipNameCbx.Text,
                ShipAddress = TxtDirecOrder.Text,
                ShipCity = TxtCityOrder.Text,
                ShipRegion = TxtRegionOrder.Text,
                ShipPostalCode = TxtCodePostalOrder.Text,
                ShipCountry = TxtShipCountry.Text,
                OrderDetails = new List<OrderDetail>()
            };

            await _orderService.AddAsync(nuevaOrden);
            return nuevaOrden;
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            _menuFrm.Show();
            this.Close();
        }

        private async void BtCrearOrderDetail_Click(object sender, EventArgs e)
        {
            if (_ordenesEnSesion == null)
            {
                _ordenesEnSesion = new List<Order>();
            }

            Order ordenActual;

            if (_ordenesEnSesion.Count == 0)
            {
                ordenActual = await CrearNuevaOrdenAsync();
                _ordenesEnSesion.Add(ordenActual);
            }
            else
            {
                ordenActual = _ordenesEnSesion[0];
            }

            using (var crearOrderFrm = _serviceProvider.GetService<OrderCrearFrm>())
            {
                if (crearOrderFrm != null)
                {
                    crearOrderFrm.SetOrderId(ordenActual.OrderId);
                    if (crearOrderFrm.ShowDialog() == DialogResult.OK)
                    {
                        var ordenRecargada = await _orderService.GetByIdAsync(ordenActual.OrderId);
                        if (ordenRecargada != null)
                        {
                            int index = _ordenesEnSesion.FindIndex(o => o.OrderId == ordenRecargada.OrderId);
                            if (index >= 0)
                            {
                                _ordenesEnSesion[index] = ordenRecargada;
                            }
                            else
                            {
                                _ordenesEnSesion.Add(ordenRecargada);
                            }
                        }
                        await CargarOrdenesEnSesionAsync();
                        await CalcularTotalesAsync();
                    }
                }
            }
        }

        private async void BtSave_Click(object sender, EventArgs e)
        {
            if (_ordenesEnSesion == null || !_ordenesEnSesion.Any())
            {
                MessageBox.Show("Por favor, cree una orden antes de guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var ordenAValidar = new Order
            {
                CustomerId = ClienteCbx.SelectedValue?.ToString(),
                EmployeeId = EmpleadoCbx.SelectedValue != null ? (int?)EmpleadoCbx.SelectedValue : 0,
                OrderDate = DtOrderDate.Value,
                RequiredDate = DtRequiredDate.Value,
                ShipVia = ShipViaCbx.SelectedValue != null ? (int?)ShipViaCbx.SelectedValue : 0,
                ShipName = ShipNameCbx.Text,
                ShipAddress = TxtDirecOrder.Text,
            };

            var validador = new Northwind.Application.Validators.OrderValid(); // Ajuste de namespace
            var resultado = validador.Validate(ordenAValidar);

            if (!resultado.IsValid)
            {
                foreach (var error in resultado.Errors)
                {
                    MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    if (error.PropertyName == "CustomerId") ClienteCbx.Focus();
                    else if (error.PropertyName == "EmployeeId") EmpleadoCbx.Focus();
                    else if (error.PropertyName == "OrderDate") DtOrderDate.Focus();
                    else if (error.PropertyName == "RequiredDate") DtRequiredDate.Focus();
                    else if (error.PropertyName == "ShipVia") ShipViaCbx.Focus();
                    else if (error.PropertyName == "ShipName") ShipNameCbx.Focus();
                    else if (error.PropertyName == "ShipAddress") TxtDirecOrder.Focus();

                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(TxtCityOrder.Text))
            {
                MessageBox.Show("Ciudad obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtCityOrder.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtShipCountry.Text))
            {
                MessageBox.Show("País de envío obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtShipCountry.Focus();
                return;
            }

            try
            {
                var ordenActual = _ordenesEnSesion[0];
                ordenActual.CustomerId = ClienteCbx.SelectedValue?.ToString();
                ordenActual.EmployeeId = EmpleadoCbx.SelectedValue != null ? (int?)EmpleadoCbx.SelectedValue : null;
                ordenActual.OrderDate = DtOrderDate.Value;
                ordenActual.RequiredDate = DtRequiredDate.Value;
                ordenActual.ShippedDate = DtShippedDate.Value;
                ordenActual.ShipVia = ShipViaCbx.SelectedValue != null ? (int?)ShipViaCbx.SelectedValue : null;
                ordenActual.Freight = decimal.TryParse(TxtFreight.Text, out var freight) ? freight : ordenActual.Freight ?? 0m;
                ordenActual.ShipName = ShipNameCbx.Text;
                ordenActual.ShipAddress = TxtDirecOrder.Text;
                ordenActual.ShipCity = TxtCityOrder.Text;
                ordenActual.ShipRegion = TxtRegionOrder.Text;
                ordenActual.ShipPostalCode = TxtCodePostalOrder.Text;
                ordenActual.ShipCountry = TxtShipCountry.Text;

                await _orderService.UpdateAsync(ordenActual);
                MessageBox.Show("Orden guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarOrdenesEnSesionAsync();
                LimpiarFormulario();
                _ordenesEnSesion = new List<Order>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la orden: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtDeleteOrder_Click(object sender, EventArgs e)
        {
            if (OrderDgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona una o varias órdenes para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"¿Seguro que quieres eliminar {OrderDgv.SelectedRows.Count} orden(es)?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            foreach (DataGridViewRow row in OrderDgv.SelectedRows)
            {
                var orderId = (int)row.Cells["OrderId"].Value;
                await _orderService.DeleteAsync(orderId);

                var ordenSesion = _ordenesEnSesion.FirstOrDefault(o => o.OrderId == orderId);
                if (ordenSesion != null)
                {
                    _ordenesEnSesion.Remove(ordenSesion);
                }
            }

            await CargarOrdenesEnSesionAsync();
            LimpiarFormulario();

            MessageBox.Show("Orden(es) eliminada(s) correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void BtEditOrderDetail_Click(object sender, EventArgs e)
        {
            if (_ordenesEnSesion == null || !_ordenesEnSesion.Any())
            {
                MessageBox.Show("No hay ninguna orden para editar. Por favor, cree una orden primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ordenActual = _ordenesEnSesion[0]; // Assuming only one order in session

            // Populate form fields with the current order's data
            ClienteCbx.SelectedValue = ordenActual.CustomerId;
            EmpleadoCbx.SelectedValue = ordenActual.EmployeeId;
            DtOrderDate.Value = ordenActual.OrderDate ?? DateTime.Now;
            DtRequiredDate.Value = ordenActual.RequiredDate ?? DateTime.Now;
            DtShippedDate.Value = ordenActual.ShippedDate ?? DateTime.Now;
            ShipViaCbx.SelectedValue = ordenActual.ShipVia;
            ShipNameCbx.Text = ordenActual.ShipName;
            TxtDirecOrder.Text = ordenActual.ShipAddress;
            TxtCityOrder.Text = ordenActual.ShipCity;
            TxtRegionOrder.Text = ordenActual.ShipRegion;
            TxtCodePostalOrder.Text = ordenActual.ShipPostalCode;
            TxtShipCountry.Text = ordenActual.ShipCountry;

            // Allow editing of OrderDetails via OrderCrearFrm
            if (OrderDgv.SelectedRows.Count > 0)
            {
                var selectedRow = OrderDgv.SelectedRows[0];
                var productName = (string)selectedRow.Cells["Producto"].Value;
                var orderDetail = ordenActual.OrderDetails.FirstOrDefault(od => od.Product.ProductName == productName);

                if (orderDetail != null)
                {
                    using (var crearOrderFrm = _serviceProvider.GetService<OrderCrearFrm>())
                    {
                        if (crearOrderFrm != null)
                        {
                            crearOrderFrm.SetOrderId(ordenActual.OrderId);
                            crearOrderFrm.SetOrderDetail(orderDetail);
                            if (crearOrderFrm.ShowDialog() == DialogResult.OK)
                            {
                                var ordenRecargada = await _orderService.GetByIdAsync(ordenActual.OrderId);
                                if (ordenRecargada != null)
                                {
                                    int index = _ordenesEnSesion.FindIndex(o => o.OrderId == ordenRecargada.OrderId);
                                    if (index >= 0)
                                    {
                                        _ordenesEnSesion[index] = ordenRecargada;
                                    }
                                    else
                                    {
                                        _ordenesEnSesion.Add(ordenRecargada);
                                    }
                                }
                                await CargarOrdenesEnSesionAsync();
                                await CalcularTotalesAsync();
                            }
                        }
                    }
                }
            }

            // Update order metadata in session
            ordenActual.CustomerId = ClienteCbx.SelectedValue?.ToString();
            ordenActual.EmployeeId = EmpleadoCbx.SelectedValue != null ? (int?)EmpleadoCbx.SelectedValue : null;
            ordenActual.OrderDate = DtOrderDate.Value;
            ordenActual.RequiredDate = DtRequiredDate.Value;
            ordenActual.ShippedDate = DtShippedDate.Value;
            ordenActual.ShipVia = ShipViaCbx.SelectedValue != null ? (int?)ShipViaCbx.SelectedValue : null;
            ordenActual.Freight = decimal.TryParse(TxtFreight.Text, out var freight) ? freight : ordenActual.Freight ?? 0m;
            ordenActual.ShipName = ShipNameCbx.Text;
            ordenActual.ShipAddress = TxtDirecOrder.Text;
            ordenActual.ShipCity = TxtCityOrder.Text;
            ordenActual.ShipRegion = TxtRegionOrder.Text;
            ordenActual.ShipPostalCode = TxtCodePostalOrder.Text;
            ordenActual.ShipCountry = TxtShipCountry.Text;

            await CargarOrdenesEnSesionAsync();
            await CalcularTotalesAsync();
        }

        private void LimpiarFormulario()
        {
            ClienteCbx.SelectedIndex = -1;
            EmpleadoCbx.SelectedIndex = -1;
            ShipNameCbx.SelectedIndex = -1;
            ShipViaCbx.SelectedIndex = -1;
            DtOrderDate.Value = DateTime.Now;
            TxtSubtotal.Text = "";
            TxtFreight.Text = "";
            TxtTotal.Text = "";
            OrderDgv.DataSource = null;
            TxtDirecOrder.Text = string.Empty;
            TxtCityOrder.Text = string.Empty;
            TxtRegionOrder.Text = string.Empty;
            TxtCodePostalOrder.Text = string.Empty;
            TxtShipCountry.Text = string.Empty;
        }
    }
}