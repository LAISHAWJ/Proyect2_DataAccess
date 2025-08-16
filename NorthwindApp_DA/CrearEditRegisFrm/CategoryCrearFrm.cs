using FluentValidation.Results;
using Northwind.Application.Servicios;
using Northwind.Application.Validators;
using Northwind.Core.Models;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindApp_Final.CrearEditRegisFrm
{
    public partial class CategoryCrearFrm : Form
    {
        private readonly CategoryService _categoryService;
        private readonly CategoryValid _validator;
        private Category _categoryEdit;
        private bool _isEditMode = false; // Indica el modo edición

        public CategoryCrearFrm(CategoryService categoryService, CategoryValid validator)
        {
            InitializeComponent();
            _categoryService = categoryService;
            _validator = validator;
            _categoryEdit = new Category();
        }

        // Método para Activar modo edición
        public void SetEditMode(Category category)
        {
            _isEditMode = true;
            _categoryEdit = category ?? new Category();
            TxtNameCat.Text = _categoryEdit.CategoryName ?? string.Empty;
            TxtDescripCat.Text = _categoryEdit.Description ?? string.Empty;
            if (_categoryEdit.Picture != null)
            {
                var imagen = ConvertirBytesAImagen(_categoryEdit.Picture);
                if (imagen != null)
                {
                    PbxCat.Image = imagen;
                }
                else
                {
                    MessageBox.Show("La imagen no se pudo mostrar.");
                }
            }
            else
            {
                PbxCat.Image = null;
            }
        }

        private void BtSubir_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Imágenes|*.jpg;*.png;*.bmp";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                PbxCat.Image = Image.FromFile(dialog.FileName);
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

        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MostrarErroresPorCampo(IEnumerable<ValidationFailure> errores)
        {
            foreach (var error in errores)
            {
                switch (error.PropertyName)
                {
                    case nameof(Category.CategoryName):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtNameCat.Focus();
                        return;

                    case nameof(Category.Description):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtDescripCat.Focus();
                        return;
                }
            }
        }

        private async void BtSave_Click(object sender, EventArgs e)
        {
            _categoryEdit.CategoryName = TxtNameCat.Text;
            _categoryEdit.Description = TxtDescripCat.Text;

            if (PbxCat.Image != null)
            {
                using var ms = new MemoryStream();
                PbxCat.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                _categoryEdit.Picture = ms.ToArray();
            }

            var resultado = _validator.Validate(_categoryEdit);
            if (!resultado.IsValid)
            {
                MostrarErroresPorCampo(resultado.Errors);
                return;
            }

            try
            {
                if (_isEditMode)
                {
                    await _categoryService.UpdateAsync(_categoryEdit);
                    MessageBox.Show("Categoría actualizada.");
                }
                else
                {
                    await _categoryService.AddAsync(_categoryEdit);
                    MessageBox.Show("Categoría agregada.");
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}