using FluentValidation.Results;
using Northwind.Application.Servicios;
using Northwind.Application.Validators;
using Northwind.Core.Models;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindApp_Final.CrearEditRegisFrm
{
    public partial class EmployeeCrearFrm : Form
    {
        private readonly EmployeeService _employeeService;
        private readonly EmployeeValid _validator;
        private Employee _employeeEdit;
        private bool _isEditMode = false; // Indica el modo edición

        public EmployeeCrearFrm(EmployeeService employeeService, EmployeeValid validator)
        {
            InitializeComponent();
            _employeeService = employeeService;
            _validator = validator;
            _employeeEdit = new Employee();
        }

        public void SetEditMode(Employee employee)
        {
            _isEditMode = true;
            _employeeEdit = employee ?? new Employee();
            TxtLastNames.Text = _employeeEdit.LastName ?? string.Empty;
            TxtNames.Text = _employeeEdit.FirstName ?? string.Empty;
            TxtTitleCortes.Text = _employeeEdit.TitleOfCourtesy ?? string.Empty;
            TxtDateTimBirth.Value = _employeeEdit.BirthDate ?? DateTime.Today;
            TxtPhone.Text = _employeeEdit.HomePhone ?? string.Empty;
            TxtExt.Text = _employeeEdit.Extension ?? string.Empty;
            TxtDirec.Text = _employeeEdit.Address ?? string.Empty;
            TxtCity.Text = _employeeEdit.City ?? string.Empty;
            TxtRegion.Text = _employeeEdit.Region ?? string.Empty;
            TxtCodePostal.Text = _employeeEdit.PostalCode ?? string.Empty;
            TxtCountry.Text = _employeeEdit.Country ?? string.Empty;
            TxtDateTimHire.Value = _employeeEdit.HireDate ?? DateTime.Today;
            TxtTitle.Text = _employeeEdit.Title ?? string.Empty;
            TxtNotes.Text = _employeeEdit.Notes ?? string.Empty;

            if (_employeeEdit.Photo != null)
            {
                var imagen = ConvertirBytesAImagen(_employeeEdit.Photo);
                if (imagen != null)
                {
                    PbxEmployee.Image = imagen;
                }
                else
                {
                    MessageBox.Show("La imagen no se pudo mostrar.");
                }
            }
            else
            {
                PbxEmployee.Image = null;
            }
        }

        private Image ConvertirBytesAImagen(byte[] bytes)
        {
            try
            {
                // Quitar encabezado OLE si la imagen proviene de Northwind
                byte[] imagenReal;

                if (EsImagenConEncabezadoOLE(bytes))
                {
                    imagenReal = bytes.Skip(78).ToArray(); // Eliminar los 78 bytes iniciales
                }
                else
                {
                    imagenReal = bytes;
                }

                using var ms = new MemoryStream(imagenReal);
                return Image.FromStream(ms);
            }
            catch
            {
                return null;
            }
        }

        private bool EsImagenConEncabezadoOLE(byte[] bytes)
        {
            return bytes != null && bytes.Length > 78 && bytes[0] == 0x15 && bytes[1] == 0x1C;
        }

        private void BtSubir_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Imágenes|*.jpg;*.png;*.bmp";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                PbxEmployee.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void MostrarErroresPorCampo(IEnumerable<ValidationFailure> errores)
        {
            foreach (var error in errores)
            {
                switch (error.PropertyName)
                {
                    case nameof(Employee.FirstName):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtNames.Focus();
                        return;

                    case nameof(Employee.LastName):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtLastNames.Focus();
                        return;

                    case nameof(Employee.HomePhone):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtPhone.Focus();
                        return;

                    case nameof(Employee.Extension):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtExt.Focus();
                        return;

                    case nameof(Employee.Address):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtDirec.Focus();
                        return;

                    case nameof(Employee.City):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtCity.Focus();
                        return;

                    case nameof(Employee.Country):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtCountry.Focus();
                        return;

                    case nameof(Employee.Title):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtTitleCortes.Focus();
                        return;

                    case nameof(Employee.HireDate):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtDateTimHire.Focus();
                        return;
                }
            }
        }

        private async void BtSave_Click(object sender, EventArgs e)
        {
            _employeeEdit.LastName = TxtLastNames.Text;
            _employeeEdit.FirstName = TxtNames.Text;
            _employeeEdit.TitleOfCourtesy = TxtTitleCortes.Text;
            _employeeEdit.BirthDate = TxtDateTimBirth.Value;
            _employeeEdit.HomePhone = TxtPhone.Text;
            _employeeEdit.Extension = TxtExt.Text;
            _employeeEdit.Address = TxtDirec.Text;
            _employeeEdit.City = TxtCity.Text;
            _employeeEdit.Region = TxtRegion.Text;
            _employeeEdit.PostalCode = TxtCodePostal.Text;
            _employeeEdit.Country = TxtCountry.Text;
            _employeeEdit.HireDate = TxtDateTimHire.Value;
            _employeeEdit.Title = TxtTitle.Text;
            _employeeEdit.Notes = TxtNotes.Text;

            if (PbxEmployee.Image != null)
            {
                using var ms = new MemoryStream();
                PbxEmployee.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                _employeeEdit.Photo = ms.ToArray();
            }

            var resultado = _validator.Validate(_employeeEdit);
            if (!resultado.IsValid)
            {
                MostrarErroresPorCampo(resultado.Errors);
                return;
            }

            try
            {
                if (_isEditMode)
                    await _employeeService.UpdateAsync(_employeeEdit);
                else
                    await _employeeService.AddAsync(_employeeEdit);

                MessageBox.Show(_isEditMode ? "Empleado actualizado." : "Empleado agregado.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}