using NorthwindApp_DA.Models;
using NorthwindApp_DA.Repository;
using NorthwindApp_DA.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindApp_DA.CrearEditRegisFrm
{
    public partial class CategoryCrearFrm : Form
    {
        private readonly CategoryRepos _categoryRepos;
        private readonly CategoryValid _validator;
        private Category _categoryEdit;
        private bool _isEditMode = false; // Indica si estamos en modo edición
        public CategoryCrearFrm(CategoryRepos categoryRepos, CategoryValid validator)
        {
            InitializeComponent();
            _categoryRepos = categoryRepos;
            _validator = validator;
            _categoryEdit = new Category();
        }

        // Método para Activar modo edición
        public void SetEditMode(Category category)
        {
            _isEditMode = true;
            _categoryEdit = category;
            TxtNameCat.Text = category.CategoryName;
            TxtDescripCat.Text = category.Description;
            if (category.Picture != null)
            {
                var imagen = ConvertirBytesAImagen(category.Picture);
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

        private void BtSave_Click(object sender, EventArgs e)
        {

            _categoryEdit.CategoryName = TxtNameCat.Text;
            _categoryEdit.Description = TxtDescripCat.Text;

            if (PbxCat.Image != null)
            {
                using var ms = new MemoryStream();
                PbxCat.Image.Save(ms, PbxCat.Image.RawFormat);
                _categoryEdit.Picture = ms.ToArray();
            }

            var resultado = _validator.Validate(_categoryEdit);
            if (!resultado.IsValid)
            {
                var errores = string.Join("\n", resultado.Errors.Select(e => e.ErrorMessage));
                MessageBox.Show(errores, "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_isEditMode)
            {
                _categoryRepos.UpdateCategory(_categoryEdit);
                MessageBox.Show("Categoría actualizada.");
            }
            else
            {
                _categoryRepos.AddCategory(_categoryEdit);
                MessageBox.Show("Categoría agregada.");
            }

            this.Close();
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
    }
}
