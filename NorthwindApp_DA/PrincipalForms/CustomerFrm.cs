using NorthwindApp_DA;
using NorthwindApp_DA.Models;
using NorthwindApp_DA.Repository;
using NorthwindApp_Final.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindApp_Final.PrincipalForms
{
    public partial class CustomerFrm : Form
    {
        private readonly CustomerRepos _customerRepos;
        private readonly IServiceProvider _serviceProvider;
        private MenuFrm _menuFrm;

        public CustomerFrm(CustomerRepos customerRepos, IServiceProvider serviceProvider, MenuFrm menuFrm)
        {
            InitializeComponent();
            _customerRepos = customerRepos;
            _serviceProvider = serviceProvider;
            CargarCustomer();
            _menuFrm = menuFrm;
        }

        private void CargarCustomer()
        {
            var customers = _customerRepos.GetAllCustomer();
            if (customers != null && customers.Count > 0)
            {
                DtGVwCustomer.DataSource = customers;
                DtGVwCustomer.Columns[nameof(Customer.Orders)].Visible = false;
                DtGVwCustomer.Columns[nameof(Customer.CustomerTypes)].Visible = false;
            }
            else
            {
                MessageBox.Show("No hay clientes disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void CustomerFrm_Load(object sender, EventArgs e)
        {
            CargarCustomer();
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            _menuFrm.Show();
            this.Close();
        }
    }
}
