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
    public partial class EmployeeCrearFrm : Form
    {
        private readonly EmployeeRepos _employeeRepos;
        private readonly EmployeeValid _validator;
        private Employee _employeeEdit;
        private bool _isEditMode = false; // Indica el modo edición

        public EmployeeCrearFrm(EmployeeRepos employeeRepos, EmployeeValid validator)
        {
            InitializeComponent();
            _employeeRepos = employeeRepos;
            _validator = validator;
            _employeeEdit = new Employee();
        }

        public void SetEditMode(Employee employee)
        {
            _isEditMode = true;
            _employeeEdit = employee;
            TxtLastNames.Text = employee.LastName;
            TxtNames.Text = employee.FirstName;
            TxtTitleCortes.Text = employee.TitleOfCourtesy;
            TxtDateTimBirth.Value = employee.BirthDate ?? DateTime.Today;
            TxtPhone.Text = employee.HomePhone;
            TxtExt.Text = employee.Extension;
            TxtDirec.Text = employee.Address;
            TxtCity.Text = employee.City;
            TxtRegion.Text = employee.Region;
            TxtCodePostal.Text = employee.PostalCode;
            TxtCountry.Text = employee.Country;
            TxtDateTimHire.Value = employee.HireDate ?? DateTime.Today;
            TxtTitle.Text = employee.Title;
            TxtNotes.Text = employee.Notes;

            if (employee.Photo != null)
            {
                var imagen = ConvertirBytesAImagen(employee.Photo);
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

        private void MostrarErroresPorCampo(IEnumerable<FluentValidation.Results.ValidationFailure> errores)
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


        private void BtSave_Click(object sender, EventArgs e)
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
            _employeeEdit.HireDate = DateTime.TryParse(TxtDateTimHire.Text, out var hireDate) ? hireDate : null;
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

            if (_isEditMode)
            {
                _employeeRepos.UpdateEmployee(_employeeEdit);
                MessageBox.Show("Empleado actualizado.");
            }
            else
            {
                _employeeRepos.AddEmployee(_employeeEdit);
                MessageBox.Show("Empleado agregado.");
            }

            this.Close();
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
