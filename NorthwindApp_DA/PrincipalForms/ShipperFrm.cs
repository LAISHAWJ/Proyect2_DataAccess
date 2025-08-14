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
    public partial class ShipperFrm : Form
    {
        private readonly ShipperRepos _shipperRepos;
        private readonly IServiceProvider _serviceProvider;
        private MenuFrm _menuFrm;
        public ShipperFrm(ShipperRepos shipperRepos, IServiceProvider serviceProvider, MenuFrm menuFrm)
        {
            InitializeComponent();
            _shipperRepos = shipperRepos;
            _serviceProvider = serviceProvider;
            CargarShippers();
            _menuFrm = menuFrm;
        }

        private void CargarShippers()
        {
            var shippers = _shipperRepos.GetAllShipper();
            if (shippers != null && shippers.Count > 0)
            {
                DtGVwShipper.DataSource = shippers;
                DtGVwShipper.Columns[nameof(Customer.Orders)].Visible = false;
            }
            else
            {
                MessageBox.Show("No hay transportistas disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void ShipperFrm_Load(object sender, EventArgs e)
        {
            CargarShippers();
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            _menuFrm.Show();
            this.Close();
        }
    }
}
