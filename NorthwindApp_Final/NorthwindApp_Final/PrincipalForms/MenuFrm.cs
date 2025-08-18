using Microsoft.Extensions.DependencyInjection;
using NorthwindApp_Final.PrincipalForms;

namespace NorthwindApp_Final.PrincipalForms
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
            var categoryForm = _services.GetService<CategoryFrm>();
            if (categoryForm != null)
            {
                this.Hide();
                categoryForm.Show();
            }
        }

        private void BtProducts_Click(object sender, EventArgs e)
        {
            var productFrm = _services.GetService<ProductsFrm>();
            if (productFrm != null)
            {
                this.Hide();
                productFrm.Show();
            }
        }

        private void BtSupplier_Click(object sender, EventArgs e)
        {
            var supplierFrm = _services.GetService<SupplierFrm>();
            if (supplierFrm != null)
            {
                this.Hide();
                supplierFrm.Show();
            }
        }

        private void BtCrearOrder_Click(object sender, EventArgs e)
        {
            var orderFrm = _services.GetService<OrderFrm>();
            if (orderFrm != null)
            {
                this.Hide();
                orderFrm.Show();
            }
        }

        private void BtViewOrder_Click(object sender, EventArgs e)
        {
            var orderdetailFrm = _services.GetService<OrderDetailsFrm>();
            if (orderdetailFrm != null)
            {
                this.Hide();
                orderdetailFrm.Show();
            }
        }

        private void BtEmployee_Click(object sender, EventArgs e)
        {
            var employeeForm = _services.GetService<EmployeeFrm>();
            if (employeeForm != null)
            {
                this.Hide();
                employeeForm.Show();
            }
        }

        private void BtCustomer_Click(object sender, EventArgs e)
        {
            var customerForm = _services.GetService<CustomerFrm>();
            if (customerForm != null)
            {
                this.Hide();
                customerForm.Show();
            }
        }

        private void BtShipper_Click(object sender, EventArgs e)
        {
            var shipperForm = _services.GetService<ShipperFrm>();
            if (shipperForm != null)
            {
                this.Hide();
                shipperForm.Show();
            }
        }

        private void MenuFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("¿Seguro que quieres salir?", "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void MenuFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
