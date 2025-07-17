using Microsoft.EntityFrameworkCore;
using NorthwindApp_DA.Data;
using NorthwindApp_DA.Models;
using NorthwindApp_DA.Repository;
using System.ComponentModel;
using System.Windows.Forms;

namespace NorthwindApp_DA.CrearEditRegisFrm
{
    public partial class OrderCrearFrm : Form
    {
        private readonly NorthwindContext _context;
        private readonly OrderRepos _orderRepos;
        private readonly int _orderId;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public OrderDetail CreatedOrderDetail { get; private set; }
       

        public OrderCrearFrm(NorthwindContext context, int orderId)
        {
            InitializeComponent();
            _context = context;
            _orderRepos = new OrderRepos(_context);
            _orderId = orderId;
            CargarProductos();
        }

        public OrderCrearFrm(NorthwindContext context)
        {
            _context = context;
        }

        private void CargarProductos()
        {
            
                var products = _context.Products
                    .Select(p => new ProductSelectionOrder
                    {
                        ProductID = p.ProductId,
                        ProductName = p.ProductName ?? "No Name",
                        UnitPrice = p.UnitPrice ?? 0,
                        CategoryID = p.Category != null ? p.Category.CategoryName : "No Category",
                        SupplierID = p.Supplier != null ? p.Supplier.CompanyName : "No Supplier"
                    })
                    .OrderBy(p => p.ProductID) 
                    .ToList();

                ProductOrderDgv.DataSource = products;
            
        }   


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtCrear_Click(object sender, EventArgs e)
        {

            if (ProductOrderDgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(TxtCantidad.Text, out var quantity) || quantity <= 0)
            {
                MessageBox.Show("La cantidad debe ser un número entero positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(TxtDescuento.Text, out var discount) || discount < 0 || discount > 100)
            {
                MessageBox.Show("El descuento debe ser un valor entre 0 y 100.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedRow = ProductOrderDgv.SelectedRows[0];
            var productId = (int)selectedRow.Cells["ProductId"].Value;
            var unitPrice = (decimal)selectedRow.Cells["UnitPrice"].Value;

            CreatedOrderDetail = new OrderDetail
            {
                OrderId = _orderId,
                ProductId = productId,
                UnitPrice = unitPrice,
                Quantity = (short)quantity,
                Discount = (float)(discount / 100) 
            };

            _context.OrderDetails.Add(CreatedOrderDetail);
            try
            {
                _context.SaveChanges();
                MessageBox.Show("Detalle de orden creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el detalle de la orden: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
