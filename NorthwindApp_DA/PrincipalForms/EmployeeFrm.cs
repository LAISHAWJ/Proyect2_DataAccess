using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Servicios;
using Northwind.Core.Models;
using NorthwindApp_DA;
using NorthwindApp_DA.CrearEditRegisFrm;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindApp_DA.PrincipalForms
{
    public partial class EmployeeFrm : Form
    {
        private readonly EmployeeService _employeeService;
        private readonly IServiceProvider _serviceProvider;
        private readonly MenuFrm _menuFrm;

        public EmployeeFrm(EmployeeService employeeService, IServiceProvider serviceProvider, MenuFrm menuFrm)
        {
            InitializeComponent();
            _employeeService = employeeService;
            _serviceProvider = serviceProvider;
            _menuFrm = menuFrm;
            CargarEmployeeAsync().ConfigureAwait(false); // Carga asíncrona al iniciar
        }

        private async Task CargarEmployeeAsync()
        {
            try
            {
                var employees = await _employeeService.GetAllAsync();
                if (employees != null && employees.Any())
                {
                    DtGVwEmployee.DataSource = employees;
                    // Ocultar las propiedades de navegación
                    DtGVwEmployee.Columns[nameof(Employee.InverseReportsToNavigation)].Visible = false;
                    DtGVwEmployee.Columns[nameof(Employee.Orders)].Visible = false;
                    DtGVwEmployee.Columns[nameof(Employee.ReportsToNavigation)].Visible = false;
                    DtGVwEmployee.Columns[nameof(Employee.PhotoPath)].Visible = false;
                    DtGVwEmployee.Columns[nameof(Employee.ReportsTo)].Visible = false;
                }
                else
                {
                    MessageBox.Show("No hay empleados disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DtGVwEmployee.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            _menuFrm.Show();
            this.Close();
        }

        private void EmployeeFrm_Load(object sender, EventArgs e)
        {
            // La carga ya se hace en el constructor con async
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetService<EmployeeCrearFrm>();
            if (form != null)
            {
                form.FormClosed += async (s, args) => await CargarEmployeeAsync(); // Recargar lista al cerrar
                form.ShowDialog();
            }
        }

        private async void BtUpdate_Click(object sender, EventArgs e)
        {
            if (DtGVwEmployee.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un empleado para editar.");
                return;
            }

            var employee = (Employee)DtGVwEmployee.SelectedRows[0].DataBoundItem;
            var form = _serviceProvider.GetService<EmployeeCrearFrm>();
            if (form != null)
            {
                form.SetEditMode(employee);
                form.FormClosed += async (s, args) => await CargarEmployeeAsync();
                form.ShowDialog();
            }
        }

        private async void BtDelete_Click(object sender, EventArgs e)
        {
            if (DtGVwEmployee.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un empleado para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var employee = (Employee)DtGVwEmployee.SelectedRows[0].DataBoundItem;

            var confirmar = MessageBox.Show($"¿Deseas eliminar '{employee.FirstName}'?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmar == DialogResult.Yes)
            {
                await _employeeService.DeleteAsync(employee.EmployeeId);
                await CargarEmployeeAsync();
            }
        }
    }
}