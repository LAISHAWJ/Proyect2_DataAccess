using Northwind.Application.Services;
using Northwind.Core.Models;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindApp_Final.CrearEditRegisFrm
{
    public partial class OrderCrearFrm : Form
    {
        private readonly OrderService _orderService;
        private int _orderId;
        private OrderDetail _orderDetailToEdit;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public OrderDetail CreatedOrderDetail { get; private set; }

        public OrderCrearFrm(IServiceProvider serviceProvider, OrderService orderService)
        {
            InitializeComponent();
            if (serviceProvider == null) throw new ArgumentNullException(nameof(serviceProvider));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            // Inicialización diferida de _orderId y _orderDetailToEdit
        }

        public void SetOrderId(int orderId)
        {
            _orderId = orderId;
            if (_orderDetailToEdit == null && !IsDisposed)
            {
                _ = CargarProductosAsync();
            }
        }

        public void SetOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailToEdit = orderDetail;
            _orderId = orderDetail?.OrderId ?? _orderId;
            if (orderDetail != null && !IsDisposed)
            {
                ConfigurarModoEdicion();
            }
            else if (_orderId != 0 && !IsDisposed && _orderDetailToEdit == null)
            {
                _ = CargarProductosAsync();
            }
        }

        private async Task CargarProductosAsync()
        {
            if (IsDisposed) return;
            try
            {
                var productos = await _orderService.GetProductsAsync();
                var productList = productos.Select(p => new ProductSelectionOrder
                {
                    ProductID = p.ProductId,
                    ProductName = p.ProductName ?? "Sin Nombre",
                    UnitPrice = p.UnitPrice ?? 0m,
                    CategoryID = p.Category != null ? p.Category.CategoryName : "No Category",
                    SupplierID = p.Supplier != null ? p.Supplier.CompanyName : "No Supplier"
                }).OrderBy(p => p.ProductID).ToList();

                if (ProductOrderDgv.InvokeRequired)
                {
                    ProductOrderDgv.Invoke(new Action(() =>
                    {
                        ProductOrderDgv.DataSource = productList;
                        ProductOrderDgv.Columns["CategoryID"].HeaderText = "Categoría";
                        ProductOrderDgv.Columns["SupplierID"].HeaderText = "Proveedor";
                    }));
                }
                else
                {
                    ProductOrderDgv.DataSource = productList;
                    ProductOrderDgv.Columns["CategoryID"].HeaderText = "Categoría";
                    ProductOrderDgv.Columns["SupplierID"].HeaderText = "Proveedor";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarModoEdicion()
        {
            if (IsDisposed) return;
            Text = "Editar Detalle de Orden";
            BtCrear.Text = "Actualizar";

            if (ProductOrderDgv.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in ProductOrderDgv.Rows)
                {
                    if ((int)row.Cells["ProductId"].Value == _orderDetailToEdit.ProductId)
                    {
                        row.Selected = true;
                        ProductOrderDgv.FirstDisplayedScrollingRowIndex = row.Index;
                        break;
                    }
                }
            }

            TxtCantidad.Text = _orderDetailToEdit.Quantity.ToString();
            TxtDescuento.Text = (_orderDetailToEdit.Discount * 100).ToString("F2");
        }

        private async void BtCrear_Click(object sender, EventArgs e)
        {
            try
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

                if (_orderDetailToEdit == null)
                {
                    CreatedOrderDetail = new OrderDetail
                    {
                        OrderId = _orderId,
                        ProductId = productId,
                        UnitPrice = precioUnitario,
                        Quantity = (short)cantidad,
                        Discount = (float)(descuento / 100)
                    };
                    await _orderService.AddOrderDetailAsync(CreatedOrderDetail); // Nuevo método
                }
                else
                {
                    if (_orderDetailToEdit.ProductId != productId)
                    {
                        await _orderService.DeleteOrderDetailAsync(_orderId, _orderDetailToEdit.ProductId);
                        CreatedOrderDetail = new OrderDetail
                        {
                            OrderId = _orderId,
                            ProductId = productId,
                            UnitPrice = precioUnitario,
                            Quantity = (short)cantidad,
                            Discount = (float)(descuento / 100)
                        };
                        await _orderService.AddOrderDetailAsync(CreatedOrderDetail); // Nuevo método
                    }
                    else
                    {
                        _orderDetailToEdit.UnitPrice = precioUnitario;
                        _orderDetailToEdit.Quantity = (short)cantidad;
                        _orderDetailToEdit.Discount = (float)(descuento / 100);
                        CreatedOrderDetail = _orderDetailToEdit;
                        await _orderService.UpdateOrderDetailAsync(CreatedOrderDetail); // Nuevo método
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