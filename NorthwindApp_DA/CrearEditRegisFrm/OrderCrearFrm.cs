using Northwind.Application.Services;
using Northwind.Core.Models;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindApp_DA.CrearEditRegisFrm
{
    public partial class OrderCrearFrm : Form
    {
        private readonly OrderService _orderService;
        private readonly int _orderId;
        private readonly OrderDetail _orderDetailToEdit;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public OrderDetail CreatedOrderDetail { get; private set; }

        public OrderCrearFrm(OrderService orderService, int orderId, OrderDetail orderDetailToEdit = null)
        {
            InitializeComponent();
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _orderId = orderId;
            _orderDetailToEdit = orderDetailToEdit;
            CargarProductosAsync().ConfigureAwait(false);
            if (_orderDetailToEdit != null)
            {
                ConfigurarModoEdicion();
            }
        }

        private async Task CargarProductosAsync()
        {
            try
            {
                // Simulamos GetProductsAsync (ajusta según tu implementación en OrderService)
                var productos = await _orderService.GetProductsAsync(); // Ajusta si necesitas un método específico
                var productList = productos.Select(p => new ProductSelectionOrder
                {
                    ProductID = p.ProductId,
                    ProductName = p.ProductName ?? "Sin Nombre",
                    UnitPrice = p.UnitPrice ?? 0m,
                    CategoryID = p.Category != null ? p.Category.CategoryName : "No Category",
                    SupplierID = p.Supplier != null ? p.Supplier.CompanyName : "No Supplier"
                }).OrderBy(p => p.ProductID).ToList();

                ProductOrderDgv.DataSource = productList;
                // ProductOrderDgv.Columns["ProductID"].Visible = false; // Descomenta si deseas ocultar
                ProductOrderDgv.Columns["CategoryID"].HeaderText = "Categoría";
                ProductOrderDgv.Columns["SupplierID"].HeaderText = "Proveedor";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarModoEdicion()
        {
            Text = "Editar Detalle de Orden";
            BtCrear.Text = "Actualizar";

            // Buscar y seleccionar el producto correspondiente en el DataGridView
            foreach (DataGridViewRow row in ProductOrderDgv.Rows)
            {
                if ((int)row.Cells["ProductId"].Value == _orderDetailToEdit.ProductId)
                {
                    row.Selected = true;
                    ProductOrderDgv.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }

            // Cargar los valores actuales del detalle a editar
            TxtCantidad.Text = _orderDetailToEdit.Quantity.ToString();
            TxtDescuento.Text = (_orderDetailToEdit.Discount * 100).ToString("F2");
        }

        private async void BtCrear_Click(object sender, EventArgs e)
        {
            if (ProductOrderDgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(TxtCantidad.Text.Trim(), out var cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser un número entero positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtCantidad.Focus();
                return;
            }

            if (!decimal.TryParse(TxtDescuento.Text.Trim(), out var descuento) || descuento < 0 || descuento > 100)
            {
                MessageBox.Show("El descuento debe ser un valor entre 0 y 100.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtDescuento.Focus();
                return;
            }

            var filaSeleccionada = ProductOrderDgv.SelectedRows[0];
            var productId = (int)filaSeleccionada.Cells["ProductId"].Value;
            var precioUnitario = (decimal)filaSeleccionada.Cells["UnitPrice"].Value;

            try
            {
                if (_orderDetailToEdit == null)
                {
                    // Crear un nuevo detalle de orden
                    CreatedOrderDetail = new OrderDetail
                    {
                        OrderId = _orderId,
                        ProductId = productId,
                        UnitPrice = precioUnitario,
                        Quantity = (short)cantidad,
                        Discount = (float)(descuento / 100)
                    };

                    await _orderService.AddAsync(CreatedOrderDetail);
                }
                else
                {
                    // Manejar la actualización del detalle de orden
                    if (_orderDetailToEdit.ProductId != productId)
                    {
                        // Si el ProductId cambia, eliminar el detalle existente y crear uno nuevo
                        await _orderService.DeleteAsync(_orderDetailToEdit.OrderId, _orderDetailToEdit.ProductId); // Ajusta si necesitas un método específico
                        CreatedOrderDetail = new OrderDetail
                        {
                            OrderId = _orderId,
                            ProductId = productId,
                            UnitPrice = precioUnitario,
                            Quantity = (short)cantidad,
                            Discount = (float)(descuento / 100)
                        };
                        await _orderService.AddAsync(CreatedOrderDetail);
                    }
                    else
                    {
                        // Si el ProductId no cambia, actualizar el detalle existente
                        _orderDetailToEdit.UnitPrice = precioUnitario;
                        _orderDetailToEdit.Quantity = (short)cantidad;
                        _orderDetailToEdit.Discount = (float)(descuento / 100);
                        CreatedOrderDetail = _orderDetailToEdit;
                        await _orderService.UpdateAsync(CreatedOrderDetail);
                    }
                }

                MessageBox.Show(_orderDetailToEdit == null ? "Detalle de orden creado exitosamente." : "Detalle de orden actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el detalle de la orden: {ex.InnerException?.Message ?? ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
  
}