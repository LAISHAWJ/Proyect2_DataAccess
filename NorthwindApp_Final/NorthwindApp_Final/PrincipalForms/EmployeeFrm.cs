using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Servicios;
using Northwind.Core.Models;
using NorthwindApp_Final.CrearEditRegisFrm;
using System;
using System.Windows.Forms;

namespace NorthwindApp_Final.PrincipalForms
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
            this.Load += new EventHandler(CargarEmployee);
        }

        private void CargarEmployee(object sender, EventArgs e)
        {
            try
            {
                var employees = _employeeService.GetAllEmployee();
                if (employees != null && employees.Any())
                {
                    DtGVwEmployee.DataSource = employees.ToList();
                    
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
            
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetService<EmployeeCrearFrm>();
            if (form != null)
            {
                form.FormClosed += (s, args) => CargarEmployee(s, args); // Recargar lista al cerrar
                form.ShowDialog();
            }
        }

        private void BtUpdate_Click(object sender, EventArgs e)
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
                form.FormClosed += (s, args) => CargarEmployee(s, args);
                form.ShowDialog();
            }
        }

        private void BtDelete_Click(object sender, EventArgs e)
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
                _employeeService.DeleteEmployee(employee.EmployeeId);
                CargarEmployee(sender, e);
            }
        }
    }
}