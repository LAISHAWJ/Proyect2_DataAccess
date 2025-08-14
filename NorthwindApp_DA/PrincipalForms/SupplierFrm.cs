using Microsoft.Extensions.DependencyInjection;
using NorthwindApp_DA.CrearEditRegisFrm;
using NorthwindApp_DA.Models;
using NorthwindApp_DA.Repository;

namespace NorthwindApp_DA
{
    public partial class SupplierFrm : Form
    {
        private readonly SupplierRepos _supplierRepos;
        private readonly IServiceProvider _serviceProvider;
        private MenuFrm _menuFrm;
        public SupplierFrm(SupplierRepos supplierRepos, IServiceProvider serviceProvider, MenuFrm menuFrm)
        {
            InitializeComponent();
            _supplierRepos = supplierRepos;
            _serviceProvider = serviceProvider;
            CargarSuppliers();
            _menuFrm = menuFrm;
        }

        private void CargarSuppliers()
        {
            var suppliers = _supplierRepos.GetAllSupplier();
            if (suppliers != null && suppliers.Count > 0)
            {
                SuppDgv.DataSource = suppliers;
                SuppDgv.Columns[nameof(Supplier.Products)].Visible = false;
            }
            else
            {
                MessageBox.Show("No hay suplidores disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void SupplierFrm_Load(object sender, EventArgs e)
        {
            CargarSuppliers();
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetService<SuppliercrearFrm>();
            if (form != null)
            {
                form.FormClosed += (s, args) => CargarSuppliers(); // recargar lista al cerrar
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
            var form = Program.ServiceProvider.GetService<SuppliercrearFrm>();
            if (form != null)
            {
                form.SetEditMode(supplier);
                form.FormClosed += (s, args) => CargarSuppliers();
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

            var suplidor = (Supplier)SuppDgv.SelectedRows[0].DataBoundItem;

            var confirmar = MessageBox.Show($"¿Deseas eliminar '{suplidor.CompanyName}'?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmar == DialogResult.Yes)
            {
                _supplierRepos.DeleteSupplier(suplidor.SupplierId);
                CargarSuppliers();
            }
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            _menuFrm.Show();
            this.Close();
        }
    }
}
