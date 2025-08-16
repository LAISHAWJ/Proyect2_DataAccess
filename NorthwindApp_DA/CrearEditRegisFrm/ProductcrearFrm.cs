using FluentValidation.Results;
using Northwind.Application.Services;
using Northwind.Application.Validators;
using Northwind.Core.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindApp_Final.CrearEditRegisFrm
{
    public partial class ProductcrearFrm : Form
    {
        private readonly ProductService _productService;
        private readonly ProductValid _validator;
        private Product _productEdit;
        private bool _isEditMode = false;

        public ProductcrearFrm(ProductService productService, ProductValid validator)
        {
            InitializeComponent();
            _productService = productService;
            _validator = validator;
            _productEdit = new Product();

            CargarCategoriasAsync().ConfigureAwait(false);
            CargarSuplidoresAsync().ConfigureAwait(false);
        }

        private async Task CargarCategoriasAsync()
        {
            try
            {
                var categorias = await _productService.GetAllCategoriesAsync();
                CategCmbx.DisplayMember = "CategoryName";
                CategCmbx.ValueMember = "CategoryId";
                CategCmbx.DataSource = categorias;
                CategCmbx.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarSuplidoresAsync()
        {
            try
            {
                var suplidores = await _productService.GetAllSuppliersAsync();
                SuppCmbx.DisplayMember = "CompanyName";
                SuppCmbx.ValueMember = "SupplierId";
                SuppCmbx.DataSource = suplidores;
                SuppCmbx.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar suplidores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SetEditMode(Product product)
        {
            _productEdit = product ?? new Product();
            _isEditMode = true;

            TxtNameProduct.Text = _productEdit.ProductName ?? string.Empty;
            TxtQuantityPerUnit.Text = _productEdit.QuantityPerUnit ?? string.Empty;
            TxtUnitPrice.Text = _productEdit.UnitPrice?.ToString() ?? string.Empty;
            TxtUnitsInStock.Text = _productEdit.UnitsInStock?.ToString() ?? string.Empty;
            TxtUnitsOnOrder.Text = _productEdit.UnitsOnOrder?.ToString() ?? string.Empty;
            TxtReorderLevel.Text = _productEdit.ReorderLevel?.ToString() ?? string.Empty;
            CategCmbx.SelectedValue = _productEdit.CategoryId ?? 0;
            SuppCmbx.SelectedValue = _productEdit.SupplierId ?? 0;
            DiscontCbx.Checked = _productEdit.Discontinued;
        }

        private async void BtSave_Click(object sender, EventArgs e)
        {
            if (CategCmbx.SelectedValue == null || !(CategCmbx.SelectedValue is int))
            {
                MessageBox.Show("Seleccione una categoría válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SuppCmbx.SelectedValue == null || !(SuppCmbx.SelectedValue is int))
            {
                MessageBox.Show("Seleccione un suplidor válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var product = _isEditMode ? _productEdit : new Product();

            product.ProductName = TxtNameProduct.Text.Trim();
            product.QuantityPerUnit = TxtQuantityPerUnit.Text.Trim();

            product.UnitPrice = decimal.TryParse(TxtUnitPrice.Text, out decimal precio) ? precio : (decimal?)null;
            product.UnitsInStock = short.TryParse(TxtUnitsInStock.Text, out short stock) ? stock : (short?)null;
            product.UnitsOnOrder = short.TryParse(TxtUnitsOnOrder.Text, out short ordenado) ? ordenado : (short?)null;
            product.ReorderLevel = short.TryParse(TxtReorderLevel.Text, out short reorden) ? reorden : (short?)null;

            product.CategoryId = (int)CategCmbx.SelectedValue;
            product.SupplierId = (int)SuppCmbx.SelectedValue;
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
                    await _productService.UpdateAsync(product);
                else
                    await _productService.AddAsync(product);

                MessageBox.Show("Producto guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarErroresPorCampo(IEnumerable<ValidationFailure> errores)
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