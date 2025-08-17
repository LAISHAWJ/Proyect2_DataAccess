using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Servicios;
using Northwind.Core.Models;
using NorthwindApp_Final.CrearEditRegisFrm;
using System;
using System.Windows.Forms;

namespace NorthwindApp_Final.PrincipalForms
{
    public partial class ShipperFrm : Form
    {
        private readonly ShipperService _shipperService;
        private readonly IServiceProvider _serviceProvider;
        private readonly MenuFrm _menuFrm;

        public ShipperFrm(ShipperService shipperService, IServiceProvider serviceProvider, MenuFrm menuFrm)
        {
            InitializeComponent();
            _shipperService = shipperService;
            _serviceProvider = serviceProvider;
            _menuFrm = menuFrm;
            this.Load += new EventHandler(CargarShippers); // Carga sincrónica al iniciar
        }

        private void CargarShippers(object sender, EventArgs e)
        {
            try
            {
                var shippers = _shipperService.GetAllShipper();
                if (shippers != null && shippers.Any())
                {
                    DtGVwShipper.DataSource = shippers;
                    DtGVwShipper.Columns[nameof(Shipper.Orders)].Visible = false; // Corregido a Shipper.Orders
                }
                else
                {
                    MessageBox.Show("No hay transportistas disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DtGVwShipper.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar transportistas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShipperFrm_Load(object sender, EventArgs e)
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
            var form = _serviceProvider.GetService<ShipperCrearFrm>();
            if (form != null)
            {
                form.FormClosed += (s, args) => CargarShippers(s, args); // Recargar lista al cerrar
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
            var form = _serviceProvider.GetService<ShipperCrearFrm>();
            if (form != null)
            {
                form.SetEditMode(shipper);
                form.FormClosed += (s, args) => CargarShippers(s, args);
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
                _shipperService.DeleteShipper(shipper.ShipperId);
                CargarShippers(sender, e);
            }
        }
    }
}