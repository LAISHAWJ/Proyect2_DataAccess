using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Servicios;
using Northwind.Core.Models;
using NorthwindApp_DA.CrearEditRegisFrm;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindApp_DA
{
    public partial class SupplierFrm : Form
    {
        private readonly SupplierService _supplierService;
        private readonly IServiceProvider _serviceProvider;
        private readonly MenuFrm _menuFrm;

        public SupplierFrm(SupplierService supplierService, IServiceProvider serviceProvider, MenuFrm menuFrm)
        {
            InitializeComponent();
            _supplierService = supplierService;
            _serviceProvider = serviceProvider;
            _menuFrm = menuFrm;
            CargarSuppliersAsync().ConfigureAwait(false); // Carga asíncrona al iniciar
        }

        private async Task CargarSuppliersAsync()
        {
            try
            {
                var suppliers = await _supplierService.GetAllAsync();
                if (suppliers != null && suppliers.Any())
                {
                    SuppDgv.DataSource = suppliers;
                    SuppDgv.Columns[nameof(Supplier.Products)].Visible = false;
                }
                else
                {
                    MessageBox.Show("No hay suplidores disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SuppDgv.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar suplidores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SupplierFrm_Load(object sender, EventArgs e)
        {
            // La carga ya se hace en el constructor con async
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetService<SuppliercrearFrm>();
            if (form != null)
            {
                form.FormClosed += async (s, args) => await CargarSuppliersAsync(); // Recargar lista al cerrar
                form.ShowDialog();
            }
        }

        private async void BtUpdate_Click(object sender, EventArgs e)
        {
            if (SuppDgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un suplidor para editar.");
                return;
            }

            var supplier = (Supplier)SuppDgv.SelectedRows[0].DataBoundItem;
            var form = _serviceProvider.GetService<SuppliercrearFrm>();
            if (form != null)
            {
                form.SetEditMode(supplier);
                form.FormClosed += async (s, args) => await CargarSuppliersAsync();
                form.ShowDialog();
            }
        }

        private async void BtDelete_Click(object sender, EventArgs e)
        {
            if (SuppDgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un suplidor para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var supplier = (Supplier)SuppDgv.SelectedRows[0].DataBoundItem;

            var confirmar = MessageBox.Show($"¿Deseas eliminar '{supplier.CompanyName}'?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmar == DialogResult.Yes)
            {
                await _supplierService.DeleteAsync(supplier.SupplierId);
                await CargarSuppliersAsync();
            }
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            _menuFrm.Show();
            this.Close();
        }
    }
}