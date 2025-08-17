using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Servicios;
using Northwind.Core.Models;
using NorthwindApp_Final.CrearEditRegisFrm;
using System;
using System.Windows.Forms;

namespace NorthwindApp_Final.PrincipalForms
{
    public partial class CustomerFrm : Form
    {
        private readonly CustomerService _customerService;
        private readonly IServiceProvider _serviceProvider;
        private readonly MenuFrm _menuFrm;

        public CustomerFrm(CustomerService customerService, IServiceProvider serviceProvider, MenuFrm menuFrm)
        {
            InitializeComponent();
            _customerService = customerService;
            _serviceProvider = serviceProvider;
            _menuFrm = menuFrm;
            this.Load += new EventHandler(CargarCustomer); // Carga sincrónica al iniciar
        }

        private void CargarCustomer(object sender, EventArgs e)
        {
            try
            {
                var customers = _customerService.GetAllCustomer();
                if (customers != null && customers.Any())
                {
                    DtGVwCustomer.DataSource = customers.ToList();
                    DtGVwCustomer.Columns[nameof(Customer.Orders)].Visible = false;
                    DtGVwCustomer.Columns[nameof(Customer.CustomerTypes)].Visible = false;
                }
                else
                {
                    MessageBox.Show("No hay clientes disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DtGVwCustomer.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomerFrm_Load(object sender, EventArgs e)
        {
            // La carga ya se hace en el evento Load
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            _menuFrm.Show();
            this.Close();
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetService<CustomerCrearFrm>();
            if (form != null)
            {
                form.FormClosed += (s, args) => CargarCustomer(s, args); // Recargar lista al cerrar
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
            var form = _serviceProvider.GetService<CustomerCrearFrm>();
            if (form != null)
            {
                form.SetEditMode(customer);
                form.FormClosed += (s, args) => CargarCustomer(s, args);
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
                _customerService.DeleteCustomer(customer.CustomerId);
                CargarCustomer(sender, e);
            }
        }

        private void BtSearch_Click(object sender, EventArgs e)
        {
            string filtro = TxtBuscarId.Text.Trim();

            try
            {
                var allCustomers = _customerService.GetAllCustomer();
                if (string.IsNullOrEmpty(filtro))
                {
                    // Si no hay texto, cargar todo
                    CargarCustomer(sender, e);
                }
                else
                {
                    var filteredCustomers = allCustomers
                        .Where(c => c.CustomerId.StartsWith(filtro, StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    DtGVwCustomer.DataSource = filteredCustomers;
                    DtGVwCustomer.Columns[nameof(Customer.Orders)].Visible = false;
                    DtGVwCustomer.Columns[nameof(Customer.CustomerTypes)].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}