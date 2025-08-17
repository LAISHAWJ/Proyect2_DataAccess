using FluentValidation.Results;
using Northwind.Application.Servicios;
using Northwind.Application.Validators;
using Northwind.Core.Models;
using System;
using System.Windows.Forms;

namespace NorthwindApp_Final.CrearEditRegisFrm
{
    public partial class CustomerCrearFrm : Form
    {
        private readonly CustomerService _customerService;
        private readonly CustomerValid _validator;
        private Customer _customerEdit;
        private bool _isEditMode = false;

        public CustomerCrearFrm(CustomerService customerService, CustomerValid validator)
        {
            InitializeComponent();
            _customerService = customerService;
            _validator = validator;
            _customerEdit = new Customer();
        }

        public void SetEditMode(Customer customer)
        {
            _customerEdit = customer ?? new Customer();
            _isEditMode = true;

            TxtCustomerId.Text = _customerEdit.CustomerId ?? string.Empty;
            TxtCustomerId.Enabled = false;

            TxtCompanyName.Text = _customerEdit.CompanyName ?? string.Empty;
            TxtNameContact.Text = _customerEdit.ContactName ?? string.Empty;
            TxtContactTitle.Text = _customerEdit.ContactTitle ?? string.Empty;
            TxtDirec.Text = _customerEdit.Address ?? string.Empty;
            TxtCity.Text = _customerEdit.City ?? string.Empty;
            TxtRegion.Text = _customerEdit.Region ?? string.Empty;
            TxtCodePostal.Text = _customerEdit.PostalCode ?? string.Empty;
            TxtCountry.Text = _customerEdit.Country ?? string.Empty;
            TxtTel.Text = _customerEdit.Phone ?? string.Empty;
            TxtFax.Text = _customerEdit.Fax ?? string.Empty;
        }

        private void CustomerCrearFrm_Load(object sender, EventArgs e)
        {
            // No se requiere lógica de carga
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            var customer = _isEditMode ? _customerEdit : new Customer();

            customer.CustomerId = TxtCustomerId.Text.Trim();
            customer.CompanyName = TxtCompanyName.Text.Trim();
            customer.ContactName = TxtNameContact.Text.Trim();
            customer.ContactTitle = TxtContactTitle.Text.Trim();
            customer.Address = TxtDirec.Text.Trim();
            customer.City = TxtCity.Text.Trim();
            customer.Region = TxtRegion.Text.Trim();
            customer.PostalCode = TxtCodePostal.Text.Trim();
            customer.Country = TxtCountry.Text.Trim();
            customer.Phone = TxtTel.Text.Trim();
            customer.Fax = TxtFax.Text.Trim();

            var resultado = _validator.Validate(customer);

            if (!resultado.IsValid)
            {
                MostrarErroresPorCampo(resultado.Errors);
                return;
            }

            try
            {
                if (_isEditMode)
                    _customerService.UpdateCustomer(customer);
                else
                    _customerService.AddCustomer(customer);

                MessageBox.Show("Cliente guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarErroresPorCampo(IEnumerable<ValidationFailure> errores)
        {
            foreach (var error in errores)
            {
                switch (error.PropertyName)
                {
                    case nameof(Customer.CustomerId):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtCustomerId.Focus();
                        return;
                    case nameof(Customer.CompanyName):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtCompanyName.Focus();
                        return;
                    case nameof(Customer.ContactName):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtNameContact.Focus();
                        return;
                    case nameof(Customer.ContactTitle):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtContactTitle.Focus();
                        return;
                    case nameof(Customer.Address):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtDirec.Focus();
                        return;
                    case nameof(Customer.City):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtCity.Focus();
                        return;
                    case nameof(Customer.Region):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtRegion.Focus();
                        return;
                    case nameof(Customer.PostalCode):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtCodePostal.Focus();
                        return;
                    case nameof(Customer.Country):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtCountry.Focus();
                        return;
                    case nameof(Customer.Phone):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtTel.Focus();
                        return;
                    case nameof(Customer.Fax):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtFax.Focus();
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