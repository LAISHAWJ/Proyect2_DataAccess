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
    public partial class EmployeeFrm : Form
    {
        private readonly EmployeeRepos _employeeRepos;
        private readonly IServiceProvider _serviceProvider;
        private MenuFrm _menuFrm;
        public EmployeeFrm(EmployeeRepos employeeRepos, IServiceProvider serviceProvider, MenuFrm menuFrm)
        {
            InitializeComponent();
            _employeeRepos = employeeRepos;
            _serviceProvider = serviceProvider;
            _menuFrm = menuFrm;
            CargarEmployee();
        }

        private void CargarEmployee()
        {
            var employees = _employeeRepos.GetAllEmployee();
            if (employees != null && employees.Count > 0)
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
            }

        }


        private void BtClose_Click(object sender, EventArgs e)
        {
            _menuFrm.Show();
            this.Close();
        }

        private void EmployeeFrm_Load(object sender, EventArgs e)
        {
            CargarEmployee();
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetService<EmployeeCrearFrm>();
            if (form != null)
            {
                form.FormClosed += (s, args) => CargarEmployee(); // recargar lista al cerrar
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

            var empleado = (Employee)DtGVwEmployee.SelectedRows[0].DataBoundItem;
            var form = Program.ServiceProvider.GetService<EmployeeCrearFrm>();
            if (form != null)
            {
                form.SetEditMode(empleado);
                form.FormClosed += (s, args) => CargarEmployee();
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

            var empleado = (Employee)DtGVwEmployee.SelectedRows[0].DataBoundItem;

            var confirmar = MessageBox.Show($"¿Deseas eliminar '{empleado.FirstName}'?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmar == DialogResult.Yes)
            {
                _employeeRepos.DeleteEmployee(empleado.EmployeeId);
                CargarEmployee();
            }
        }
    }
}
