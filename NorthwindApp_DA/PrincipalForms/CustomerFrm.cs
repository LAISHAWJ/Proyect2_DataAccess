using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Servicios;
using Northwind.Core.Models;
using NorthwindApp_DA;
using NorthwindApp_DA.CrearEditRegisFrm;
using NorthwindApp_Final.CrearEditRegisFrm;
using System;
using System.Threading.Tasks;
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
            CargarCustomerAsync().ConfigureAwait(false); // Carga asíncrona al iniciar
        }

        private async Task CargarCustomerAsync()
        {
            try
            {
                var customers = await _customerService.GetAllAsync();
                if (customers != null && customers.Any())
                {
                    DtGVwCustomer.DataSource = customers;
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
            // La carga ya se hace en el constructor con async
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
                form.FormClosed += async (s, args) => await CargarCustomerAsync(); // Recargar lista al cerrar
                form.ShowDialog();
            }
        }

        private async void BtUpdate_Click(object sender, EventArgs e)
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
                form.FormClosed += async (s, args) => await CargarCustomerAsync();
                form.ShowDialog();
            }
        }

        private async void BtDelete_Click(object sender, EventArgs e)
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
                await _customerService.DeleteAsync(customer.CustomerId);
                await CargarCustomerAsync();
            }
        }

        private async void BtSearch_Click(object sender, EventArgs e)
        {
            string filtro = TxtBuscarId.Text.Trim();

            try
            {
                var allCustomers = await _customerService.GetAllAsync();
                if (string.IsNullOrEmpty(filtro))
                {
                    // Si no hay texto, cargar todo
                    await CargarCustomerAsync();
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