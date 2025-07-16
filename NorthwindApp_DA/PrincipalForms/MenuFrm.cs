using Microsoft.Extensions.DependencyInjection;
using NorthwindApp_DA.PrincipalForms;

namespace NorthwindApp_DA
{
    public partial class MenuFrm : Form
    {
        private readonly IServiceProvider _services;


        public MenuFrm(IServiceProvider services)
        {
            InitializeComponent();
            _services = services ?? throw new ArgumentNullException(nameof(services));

        }


        private void BtCategory_Click(object sender, EventArgs e)
        {
            var categoryForm = Program.ServiceProvider.GetService<CategoryFrm>();
            if (categoryForm != null)
            {
                this.Hide();
                categoryForm.Show();
            }
        }

        private void BtExit_Click(object sender, EventArgs e)
        {
            DialogResult Opcionsalir = MessageBox.Show("¿Desea salir del Sistema de Inventario?", "SALIR", MessageBoxButtons.YesNo,
          MessageBoxIcon.Question);
            if (Opcionsalir == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void BtProducts_Click(object sender, EventArgs e)
        {
            var productFrm = Program.ServiceProvider.GetService<ProductsFrm>();
            if (productFrm != null)
            {
                this.Hide();
                productFrm.Show();
            }
        }

        private void BtSupplier_Click(object sender, EventArgs e)
        {
            var supplierFrm = Program.ServiceProvider.GetService<SupplierFrm>();
            if (supplierFrm != null)
            {
                this.Hide();
                supplierFrm.Show();
            }
        }

        private void BtCrearOrder_Click(object sender, EventArgs e)
        {
            var orderFrm = Program.ServiceProvider.GetService<OrderFrm>();
            if (orderFrm != null)
            {
                this.Hide();
                orderFrm.Show();
            }
        }

        private void BtViewOrder_Click(object sender, EventArgs e)
        {
            var orderdetailFrm = Program.ServiceProvider.GetService<OrderDetailsFrm>();
            if (orderdetailFrm != null)
            {
                this.Hide();
                orderdetailFrm.Show();
            }
        }
    }
}
