using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NorthwindApp_DA.CrearEditRegisFrm;
using NorthwindApp_DA.Data;
using NorthwindApp_DA.Models;
using NorthwindApp_DA.Repository;
using System;
using System.Windows.Forms;

namespace NorthwindApp_DA
{
    public partial class OrderFrm : Form
    {

        private List<Order> _ordenesEnSesion;

        private readonly IServiceProvider _serviceProvider = Program.ServiceProvider;
        private readonly NorthwindContext _context;
        private readonly OrderRepos _orderRepos;
        private readonly MenuFrm _menuFrm;

        public OrderFrm(NorthwindContext context, MenuFrm menuFrm)
        {
            InitializeComponent();
            _context = context;
            _orderRepos = new OrderRepos(_context);
            _menuFrm = menuFrm;
            _ordenesEnSesion = new List<Order>();
        }

        private void OrderFrm_Load(object sender, EventArgs e)
        {
            CargarOrdenesEnSesion();
            CalcularTotales();
            CargarCombos();
            _ordenesEnSesion = new List<Order>();

        }


        private void CargarOrdenesEnSesion()
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
                Categoria = d.Product.Category.CategoryName,
                Suplidor = d.Product.Supplier.CompanyName,
                d.UnitPrice,
                d.Quantity,
                d.Discount,
                ExtendedPrice = d.UnitPrice * d.Quantity * (1 - (decimal)d.Discount)
            })).ToList();

            OrderDgv.DataSource = detalles;
            OrderDgv.Refresh();

            CalcularTotales();
        }


        private void CalcularTotales()
        {
            if (_ordenesEnSesion.Count == 0)
                return;

            
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



        private void CargarCombos()
        {
            var clientes = _orderRepos.GetCustomers();
            ClienteCbx.DataSource = clientes;
            ClienteCbx.DisplayMember = "CompanyName";
            ClienteCbx.ValueMember = "CustomerId";

            var empleados = _orderRepos.GetEmployees();
            EmpleadoCbx.DataSource = empleados;
            EmpleadoCbx.DisplayMember = "LastName";
            EmpleadoCbx.ValueMember = "EmployeeId";

            var transportistas = _orderRepos.GetShippers();
            ShipViaCbx.DataSource = transportistas;
            ShipViaCbx.DisplayMember = "CompanyName";
            ShipViaCbx.ValueMember = "ShipperId";

            var destinatarios = _orderRepos.GetAllOrders()
                                    .Select(o => o.ShipName)
                                    .Where(s => !string.IsNullOrEmpty(s))
                                    .Distinct()
                                    .ToList();
            ShipNameCbx.DataSource = destinatarios;
        }

        private Order CrearNuevaOrden()
        {
            var nuevaOrden = new Order
            {
                CustomerId = ClienteCbx.SelectedValue.ToString(),
                EmployeeId = (int)EmpleadoCbx.SelectedValue,
                OrderDate = DtOrderDate.Value,
                RequiredDate = DtRequiredDate.Value,
                ShippedDate = DtShippedDate.Value,
                ShipVia = (int)ShipViaCbx.SelectedValue,
                Freight = decimal.TryParse(TxtFreight.Text, out var freight) ? freight : 0,
                ShipName = ShipNameCbx.Text,
                ShipAddress = TxtDirecOrder.Text,
                ShipCity = TxtCityOrder.Text,
                ShipRegion = TxtRegionOrder.Text,
                ShipPostalCode = TxtCodePostalOrder.Text,
                ShipCountry = TxtShipCountry.Text,
                OrderDetails = new List<OrderDetail>()
            };

            _context.Orders.Add(nuevaOrden);
            _context.SaveChanges();

            return nuevaOrden;
        }


        private void BtCancel_Click(object sender, EventArgs e)
        {
            _menuFrm.Show();
            this.Close();
        }

        private void BtCrearOrderDetail_Click(object sender, EventArgs e)
        {
            if (_ordenesEnSesion == null)
            {
                _ordenesEnSesion = new List<Order>();
            }

            
            Order ordenActual;

            if (_ordenesEnSesion.Count == 0)
            {
                ordenActual = CrearNuevaOrden(); 
                _ordenesEnSesion.Add(ordenActual);
            }
            else
            {
                
                ordenActual = _ordenesEnSesion[0]; 
            }

            using (var crearOrderFrm = new OrderCrearFrm(_context, ordenActual.OrderId))
            {
                if (crearOrderFrm.ShowDialog() == DialogResult.OK)
                {
                    
                    var ordenRecargada = _context.Orders
                        .Include(o => o.OrderDetails)
                        .ThenInclude(od => od.Product)
                        .ThenInclude(p => p.Category)
                        .Include(o => o.OrderDetails)
                        .ThenInclude(od => od.Product)
                        .ThenInclude(p => p.Supplier)
                        .FirstOrDefault(o => o.OrderId == ordenActual.OrderId);

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

                    CargarOrdenesEnSesion();
                    CalcularTotales();
                }
            }
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            if (_ordenesEnSesion == null || !_ordenesEnSesion.Any())
            {
                MessageBox.Show("Por favor, cree una orden antes de guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            var ordenAValidar = new Order
            {
                CustomerId = ClienteCbx.SelectedValue?.ToString(),
                EmployeeId = EmpleadoCbx.SelectedValue != null ? (int)EmpleadoCbx.SelectedValue : 0,
                OrderDate = DtOrderDate.Value,
                RequiredDate = DtRequiredDate.Value,
                ShipVia = ShipViaCbx.SelectedValue != null ? (int)ShipViaCbx.SelectedValue : 0,
                ShipName = ShipNameCbx.Text,
                ShipAddress = TxtDirecOrder.Text,
            };

            var validador = new Validators.OrderValid();
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
                _context.SaveChanges();
                MessageBox.Show("Orden guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarOrdenesEnSesion();
                LimpiarFormulario();

                // Reiniciar la lista para una nueva orden
                _ordenesEnSesion = new List<Order>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la orden: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtDeleteOrder_Click(object sender, EventArgs e)
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


                var ordenDb = _context.Orders
                    .Include(o => o.OrderDetails)
                    .FirstOrDefault(o => o.OrderId == orderId);

                if (ordenDb != null)
                {
                    _context.OrderDetails.RemoveRange(ordenDb.OrderDetails);
                    _context.Orders.Remove(ordenDb);
                }


                var ordenSesion = _ordenesEnSesion.FirstOrDefault(o => o.OrderId == orderId);
                if (ordenSesion != null)
                {
                    _ordenesEnSesion.Remove(ordenSesion);
                }
            }

            _context.SaveChanges();

            CargarOrdenesEnSesion();
            LimpiarFormulario();

            MessageBox.Show("Orden(es) eliminada(s) correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }


        private void LimpiarFormulario()
        {
            // Limpiar los combos
            ClienteCbx.SelectedIndex = -1;
            EmpleadoCbx.SelectedIndex = -1;
            ShipNameCbx.SelectedIndex = -1;
            ShipViaCbx.SelectedIndex = -1;

            // Limpiar fecha
            DtOrderDate.Value = DateTime.Now;

            // Limpiar campos de totales
            TxtSubtotal.Text = "";
            TxtFreight.Text = "";
            TxtTotal.Text = "";

            // Limpiar el DataGridView
            OrderDgv.DataSource = null;

            //Limpiar demas texbox
            TxtDirecOrder.Text = string.Empty;
            TxtCityOrder.Text = string.Empty;
            TxtRegionOrder.Text = string.Empty;
            TxtCodePostalOrder.Text = string.Empty;
            TxtShipCountry.Text = string.Empty;

        }

        private void TxtFreight_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
