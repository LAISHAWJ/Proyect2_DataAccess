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
            CargarShippersAsync().ConfigureAwait(false); // Carga asíncrona al iniciar
        }

        private async Task CargarShippersAsync()
        {
            try
            {
                var shippers = await _shipperService.GetAllAsync();
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
            // La carga ya se hace en el constructor con async
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
                form.FormClosed += async (s, args) => await CargarShippersAsync(); // Recargar lista al cerrar
                form.ShowDialog();
            }
        }

        private async void BtUpdate_Click(object sender, EventArgs e)
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
                form.FormClosed += async (s, args) => await CargarShippersAsync();
                form.ShowDialog();
            }
        }

        private async void BtDelete_Click(object sender, EventArgs e)
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
                await _shipperService.DeleteAsync(shipper.ShipperId);
                await CargarShippersAsync();
            }
        }
    }
}