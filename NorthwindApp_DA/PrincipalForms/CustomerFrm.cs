using Microsoft.Extensions.DependencyInjection;
using NorthwindApp_DA;
using NorthwindApp_DA.CrearEditRegisFrm;
using NorthwindApp_DA.Models;
using NorthwindApp_DA.Repository;
using NorthwindApp_Final.CrearEditRegisFrm;
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

        private void BtAdd_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetService<CustomerCrearFrm>();
            if (form != null)
            {
                form.FormClosed += (s, args) => CargarCustomer(); // recargar lista al cerrar
                form.ShowDialog();
            }
        }

        private void BtUpdate_Click(object sender, EventArgs e)
        {
            if (DtGVwCustomer.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un cliente para editar.");
                return;
            }

            var customer = (Customer)DtGVwCustomer.SelectedRows[0].DataBoundItem;
            var form = Program.ServiceProvider.GetService<CustomerCrearFrm>();
            if (form != null)
            {
                form.SetEditMode(customer);
                form.FormClosed += (s, args) => CargarCustomer();
                form.ShowDialog();
            }
        }

        private void BtDelete_Click(object sender, EventArgs e)
        {
            if (DtGVwCustomer.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un cliente para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var customer = (Customer)DtGVwCustomer.SelectedRows[0].DataBoundItem;

            var confirmar = MessageBox.Show($"¿Deseas eliminar '{customer.CompanyName}'?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmar == DialogResult.Yes)
            {
                _customerRepos.DeleteCustomer(customer.CustomerId);
                CargarCustomer();
            }
        }

        private void BtSearch_Click(object sender, EventArgs e)
        {
            string filtro = TxtBuscarId.Text.Trim();

            if (string.IsNullOrEmpty(filtro))
            {
                // Si no hay texto, cargar todo
                CargarCustomer();
            }
            else
            {
                var customers = _customerRepos
                    .GetAllCustomer() // traes todos
                    .Where(c => c.CustomerId.StartsWith(filtro, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                DtGVwCustomer.DataSource = customers;

                DtGVwCustomer.Columns[nameof(Customer.Orders)].Visible = false;
                DtGVwCustomer.Columns[nameof(Customer.CustomerTypes)].Visible = false;
            }
        }
    }
}
