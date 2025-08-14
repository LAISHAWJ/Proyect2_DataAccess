using NorthwindApp_DA.Models;
using NorthwindApp_DA.Repository;
using NorthwindApp_DA.Validators;
using NorthwindApp_Final.Repository;
using NorthwindApp_Final.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindApp_Final.CrearEditRegisFrm
{
    public partial class ShipperCrearFrm : Form
    {
        private readonly ShipperRepos _shipperRepos;
        private readonly ShipperValid _validator;
        private Shipper _shipperEdit;
        private bool _isEditMode = false;
        public ShipperCrearFrm(ShipperRepos shipperRepos, ShipperValid validator)
        {
            InitializeComponent();
            _shipperRepos = shipperRepos;
            _validator = validator;
            _shipperEdit = new Shipper();
        }

        public void SetEditMode(Shipper shipper)
        {
            _shipperEdit = shipper;
            _isEditMode = true;

            TxtCompanyName.Text = shipper.CompanyName;
            TxtTel.Text = shipper.Phone;
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
                    _shipperRepos.UpdateShipper(shipper);
                else
                    _shipperRepos.AddShipper(shipper);

                MessageBox.Show("Transportista guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el Transportista: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void MostrarErroresPorCampo(IEnumerable<FluentValidation.Results.ValidationFailure> errores)
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
