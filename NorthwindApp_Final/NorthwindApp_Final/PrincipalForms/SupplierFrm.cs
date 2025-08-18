using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Servicios;
using Northwind.Core.Models;
using NorthwindApp_Final.CrearEditRegisFrm;
using System;
using System.Windows.Forms;

namespace NorthwindApp_Final.PrincipalForms
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
            this.Load += new EventHandler(CargarSuppliers); 
        }

        private void CargarSuppliers(object sender, EventArgs e)
        {
            try
            {
                var suppliers = _supplierService.GetAllSupplier();
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
            
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetService<SuppliercrearFrm>();
            if (form != null)
            {
                form.FormClosed += (s, args) => CargarSuppliers(s, args);
                form.ShowDialog();
            }
        }

        private void BtUpdate_Click(object sender, EventArgs e)
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
                form.FormClosed += (s, args) => CargarSuppliers(s, args);
                form.ShowDialog();
            }
        }

        private void BtDelete_Click(object sender, EventArgs e)
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
                _supplierService.DeleteSupplier(supplier.SupplierId);
                CargarSuppliers(sender, e);
            }
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            _menuFrm.Show();
            this.Close();
        }
    }
}