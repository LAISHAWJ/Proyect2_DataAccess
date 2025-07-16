using NorthwindApp_DA.Models;
using NorthwindApp_DA.Repository;
using NorthwindApp_DA.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindApp_DA.CrearEditRegisFrm
{
    public partial class ProductcrearFrm : Form
    {
        private readonly ProductRepos _productRepos;
        private readonly CategoryRepos _categoryRepos;
        private readonly SupplierRepos _supplierRepos;
        private readonly ProductValid _validator;
        private Product _productEdit;
        private bool _isEditMode = false;
        public ProductcrearFrm(ProductRepos productRepos, CategoryRepos categoryRepos, SupplierRepos supplierRepos, ProductValid validator)
        {
            InitializeComponent();
            _productRepos = productRepos;
            _categoryRepos = categoryRepos;
            _supplierRepos = supplierRepos;
            _validator = validator;
            _productEdit = new Product();

            CargarCategorias();
            CargarSuplidores();
        }

        private void CargarCategorias()
        {
            var categorias = _categoryRepos.GetAllCategories();
            CategCmbx.DisplayMember = "CategoryName";
            CategCmbx.ValueMember = "CategoryId";
            CategCmbx.DataSource = categorias;
        }

        private void CargarSuplidores()
        {
            var suplidores = _supplierRepos.GetAllSupplier();
            SuppCmbx.DisplayMember = "CompanyName";
            SuppCmbx.ValueMember = "SupplierId";
            SuppCmbx.DataSource = suplidores;
        }


        public void SetEditMode(Product product)
        {
            _productEdit = product;
            _isEditMode = true;

            TxtNameProduct.Text = product.ProductName;
            TxtQuantityPerUnit.Text = product.QuantityPerUnit;
            TxtUnitPrice.Text = product.UnitPrice?.ToString();
            TxtUnitsInStock.Text = product.UnitsInStock?.ToString();
            TxtUnitsOnOrder.Text = product.UnitsOnOrder?.ToString();
            TxtReorderLevel.Text = product.ReorderLevel?.ToString();
            CategCmbx.SelectedValue = product.CategoryId ?? 0;
            SuppCmbx.SelectedValue = product.SupplierId ?? 0;
            DiscontCbx.Checked = product.Discontinued;
        }

        private void BtSave_Click(object sender, EventArgs e)
        {
            var product = _isEditMode ? _productEdit : new Product();

            product.ProductName = TxtNameProduct.Text.Trim();
            product.QuantityPerUnit = TxtQuantityPerUnit.Text.Trim();

            product.UnitPrice = decimal.TryParse(TxtUnitPrice.Text, out decimal precio) ? precio : (decimal?)null;
            product.UnitsInStock = short.TryParse(TxtUnitsInStock.Text, out short stock) ? stock : (short?)null;
            product.UnitsOnOrder = short.TryParse(TxtUnitsOnOrder.Text, out short ordenado) ? ordenado : (short?)null;
            product.ReorderLevel = short.TryParse(TxtReorderLevel.Text, out short reorden) ? reorden : (short?)null;

            product.CategoryId = (int?)CategCmbx.SelectedValue;
            product.SupplierId = (int?)SuppCmbx.SelectedValue;
            product.Discontinued = DiscontCbx.Checked;

            var resultado = _validator.Validate(product);

            if (!resultado.IsValid)
            {
                MostrarErroresPorCampo(resultado.Errors);
                return;
            }

            try
            {
                if (_isEditMode)
                    _productRepos.UpdateProduct(product);
                else
                    _productRepos.AddProduct(product);

                MessageBox.Show("Producto guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarErroresPorCampo(IEnumerable<FluentValidation.Results.ValidationFailure> errores)
        {
            foreach (var error in errores)
            {
                switch (error.PropertyName)
                {
                    case nameof(Product.ProductName):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtNameProduct.Focus();
                        return;
                    case nameof(Product.QuantityPerUnit):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtQuantityPerUnit.Focus();
                        return;
                    case nameof(Product.UnitPrice):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtUnitPrice.Focus();
                        return;
                    case nameof(Product.UnitsInStock):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtUnitsInStock.Focus();
                        return;
                    case nameof(Product.UnitsOnOrder):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtUnitsOnOrder.Focus();
                        return;
                    case nameof(Product.ReorderLevel):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtReorderLevel.Focus();
                        return;
                    case nameof(Product.CategoryId):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        CategCmbx.Focus();
                        return;
                    case nameof(Product.SupplierId):
                        MessageBox.Show(error.ErrorMessage, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        SuppCmbx.Focus();
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
