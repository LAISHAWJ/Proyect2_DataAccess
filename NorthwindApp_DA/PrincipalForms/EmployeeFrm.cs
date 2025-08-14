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
    }
}
