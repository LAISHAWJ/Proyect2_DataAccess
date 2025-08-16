using FluentValidation.Results;
using Northwind.Application.Servicios;
using Northwind.Application.Validators;
using Northwind.Core.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindApp_Final.CrearEditRegisFrm
{
    public partial class SuppliercrearFrm : Form
    {
        private readonly SupplierService _supplierService;
        private readonly SupplierValid _validator;
        private Supplier _supplierEdit;
        private bool _isEditMode = false;

        public SuppliercrearFrm(SupplierService supplierService, SupplierValid validator)
        {
            InitializeComponent();
            _supplierService = supplierService;
            _validator = validator;
            _supplierEdit = new Supplier();
        }

        public void SetEditMode(Supplier supplier)
        {
            _supplierEdit = supplier ?? new Supplier();
            _isEditMode = true;
            this.Text = "Editar Proveedor";

            TxtNameCompany.Text = _supplierEdit.CompanyName ?? string.Empty;
            TxtNameContact.Text = _supplierEdit.ContactName ?? string.Empty;
            TxtContactTitle.Text = _supplierEdit.ContactTitle ?? string.Empty;
            TxtDirec.Text = _supplierEdit.Address ?? string.Empty;
            TxtCity.Text = _supplierEdit.City ?? string.Empty;
            TxtRegion.Text = _supplierEdit.Region ?? string.Empty;
            TxtCodePostal.Text = _supplierEdit.PostalCode ?? string.Empty;
            TxtCountry.Text = _supplierEdit.Country ?? string.Empty;
            TxtTel.Text = _supplierEdit.Phone ?? string.Empty;
            TxtFax.Text = _supplierEdit.Fax ?? string.Empty;
            TxtHomePage.Text = _supplierEdit.HomePage ?? string.Empty;
        }

        private async void BtSave_Click(object sender, EventArgs e)
        {
            var supplier = _isEditMode ? _supplierEdit : new Supplier();

            supplier.CompanyName = TxtNameCompany.Text.Trim();
            supplier.ContactName = TxtNameContact.Text.Trim();
            supplier.ContactTitle = TxtContactTitle.Text.Trim();
            supplier.Address = TxtDirec.Text.Trim();
            supplier.City = TxtCity.Text.Trim();
            supplier.Region = TxtRegion.Text.Trim();
            supplier.PostalCode = TxtCodePostal.Text.Trim();
            supplier.Country = TxtCountry.Text.Trim();
            supplier.Phone = TxtTel.Text.Trim();
            supplier.Fax = TxtFax.Text.Trim();
            supplier.HomePage = TxtHomePage.Text.Trim();

            var resultado = _validator.Validate(supplier);

            if (!resultado.IsValid)
            {
                MostrarErroresPorCampo(resultado.Errors);
                return;
            }

            try
            {
                if (_isEditMode)
                    await _supplierService.UpdateAsync(supplier);
                else
                    await _supplierService.AddAsync(supplier);

                MessageBox.Show("Proveedor guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarErroresPorCampo(IEnumerable<ValidationFailure> errores)
        {
            foreach (var error in errores)
            {
                switch (error.PropertyName)
                {
                    case nameof(Supplier.CompanyName):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtNameCompany.Focus();
                        return;
                    case nameof(Supplier.ContactName):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtNameContact.Focus();
                        return;
                    case nameof(Supplier.ContactTitle):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtContactTitle.Focus();
                        return;
                    case nameof(Supplier.Address):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtDirec.Focus();
                        return;
                    case nameof(Supplier.City):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtCity.Focus();
                        return;
                    case nameof(Supplier.Region):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtRegion.Focus();
                        return;
                    case nameof(Supplier.PostalCode):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtCodePostal.Focus();
                        return;
                    case nameof(Supplier.Country):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtCountry.Focus();
                        return;
                    case nameof(Supplier.Phone):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtTel.Focus();
                        return;
                    case nameof(Supplier.Fax):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtFax.Focus();
                        return;
                    case nameof(Supplier.HomePage):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtHomePage.Focus();
                        return;
                }
            }
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}