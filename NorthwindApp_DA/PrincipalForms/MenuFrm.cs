using Microsoft.Extensions.DependencyInjection;
using NorthwindApp_DA.PrincipalForms;
using NorthwindApp_Final.PrincipalForms;
using System;
using System.Windows.Forms;

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

        private void NavigateToForm<TForm>() where TForm : Form
        {
            var form = _services.GetService<TForm>();
            if (form != null)
            {
                this.Hide();
                form.Show();
            }
            else
            {
                MessageBox.Show($"No se pudo cargar el formulario de tipo {typeof(TForm).Name}.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtCategory_Click(object sender, EventArgs e)
        {
            NavigateToForm<CategoryFrm>();
        }

        private void BtExit_Click(object sender, EventArgs e)
        {
            DialogResult optionToExit = MessageBox.Show("¿Desea salir del Sistema de Inventario?", "SALIR",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (optionToExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void BtProducts_Click(object sender, EventArgs e)
        {
            NavigateToForm<ProductsFrm>();
        }

        private void BtSupplier_Click(object sender, EventArgs e)
        {
            NavigateToForm<SupplierFrm>();
        }

        private void BtCrearOrder_Click(object sender, EventArgs e)
        {
            NavigateToForm<OrderFrm>();
        }

        private void BtViewOrder_Click(object sender, EventArgs e)
        {
            NavigateToForm<OrderDetailsFrm>();
        }

        private void BtEmployee_Click(object sender, EventArgs e)
        {
            NavigateToForm<EmployeeFrm>();
        }

        private void BtCustomer_Click(object sender, EventArgs e)
        {
            NavigateToForm<CustomerFrm>();
        }

        private void BtShipper_Click(object sender, EventArgs e)
        {
            NavigateToForm<ShipperFrm>();
        }
    }
}