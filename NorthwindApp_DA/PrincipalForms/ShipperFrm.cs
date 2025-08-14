using Microsoft.Extensions.DependencyInjection;
using NorthwindApp_DA;
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

        private void BtAdd_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetService<ShipperCrearFrm>();
            if (form != null)
            {
                form.FormClosed += (s, args) => CargarShippers(); // recargar lista al cerrar
                form.ShowDialog();
            }
        }

        private void BtUpdate_Click(object sender, EventArgs e)
        {
            if (DtGVwShipper.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un transportista para editar.");
                return;
            }

            var shipper = (Shipper)DtGVwShipper.SelectedRows[0].DataBoundItem;
            var form = Program.ServiceProvider.GetService<ShipperCrearFrm>();
            if (form != null)
            {
                form.SetEditMode(shipper);
                form.FormClosed += (s, args) => CargarShippers();
                form.ShowDialog();
            }
        }

        private void BtDelete_Click(object sender, EventArgs e)
        {
            if (DtGVwShipper.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un transportista para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var shipper = (Shipper)DtGVwShipper.SelectedRows[0].DataBoundItem;

            var confirmar = MessageBox.Show($"¿Deseas eliminar '{shipper.CompanyName}'?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmar == DialogResult.Yes)
            {
                _shipperRepos.DeleteShipper(shipper.ShipperId);
                CargarShippers();
            }
        }
    }
}
