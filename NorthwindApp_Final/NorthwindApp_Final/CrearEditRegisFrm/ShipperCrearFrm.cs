using FluentValidation.Results;
using Northwind.Application.Servicios;
using Northwind.Application.Validators;
using Northwind.Core.Models;
using System;
using System.Windows.Forms;

namespace NorthwindApp_Final.CrearEditRegisFrm
{
    public partial class ShipperCrearFrm : Form
    {
        private readonly ShipperService _shipperService;
        private readonly ShipperValid _validator;
        private Shipper _shipperEdit;
        private bool _isEditMode = false;

        public ShipperCrearFrm(ShipperService shipperService, ShipperValid validator)
        {
            InitializeComponent();
            _shipperService = shipperService;
            _validator = validator;
            _shipperEdit = new Shipper();
        }

        public void SetEditMode(Shipper shipper)
        {
            _shipperEdit = shipper ?? new Shipper();
            _isEditMode = true;

            TxtCompanyName.Text = _shipperEdit.CompanyName ?? string.Empty;
            TxtTel.Text = _shipperEdit.Phone ?? string.Empty;
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            var shipper = _isEditMode ? _shipperEdit : new Shipper();

            shipper.CompanyName = TxtCompanyName.Text.Trim();
            shipper.Phone = TxtTel.Text.Trim();

            var resultado = _validator.Validate(shipper);

            if (!resultado.IsValid)
            {
                MostrarErroresPorCampo(resultado.Errors);
                return;
            }

            try
            {
                if (_isEditMode)
                    _shipperService.UpdateShipper(shipper);
                else
                    _shipperService.AddShipper(shipper);

                MessageBox.Show("Transportista guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el Transportista: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarErroresPorCampo(IEnumerable<ValidationFailure> errores)
        {
            foreach (var error in errores)
            {
                switch (error.PropertyName)
                {
                    case nameof(Shipper.CompanyName):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtCompanyName.Focus();
                        return;

                    case nameof(Shipper.Phone):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtTel.Focus();
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