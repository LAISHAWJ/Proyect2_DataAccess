using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Services;
using NorthwindApp_DA.CrearEditRegisFrm;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindApp_DA
{
    public partial class ProductsFrm : Form
    {
        private readonly ProductService _productService;
        private readonly IServiceProvider _serviceProvider;
        private readonly MenuFrm _menuFrm;

        public ProductsFrm(ProductService productService, IServiceProvider serviceProvider, MenuFrm menuFrm)
        {
            InitializeComponent();
            _productService = productService;
            _serviceProvider = serviceProvider;
            _menuFrm = menuFrm;
            CargarProductosAsync().ConfigureAwait(false); // Carga asíncrona al iniciar
        }

        private void ProductsFrm_Load(object sender, EventArgs e)
        {
            ConfigurarComboFiltrosAsync().ConfigureAwait(false); // Configuración asíncrona de filtros
        }

        private async Task CargarProductosAsync()
        {
            try
            {
                var productos = await _productService.GetAllAsync();

                string estado = StatusCbx.SelectedItem?.ToString();
                string categoriaSeleccionada = CmbxCat.SelectedItem?.ToString();
                string suplidorSeleccionado = CmbxSup.SelectedItem?.ToString();

                // Filtro por estado
                if (estado == "Activos")
                    productos = productos.Where(p => !p.Discontinued).ToList();
                else if (estado == "Descontinuados")
                    productos = productos.Where(p => p.Discontinued).ToList();

                // Filtro por categoría
                if (!string.IsNullOrEmpty(categoriaSeleccionada) && categoriaSeleccionada != "Todas")
                    productos = productos.Where(p => p.Category != null && p.Category.CategoryName == categoriaSeleccionada).ToList();

                // Filtro por suplidor
                if (!string.IsNullOrEmpty(suplidorSeleccionado) && suplidorSeleccionado != "Todos")
                    productos = productos.Where(p => p.Supplier != null && p.Supplier.CompanyName == suplidorSeleccionado).ToList();

                var productosMostrados = productos.Select(p => new
                {
                    p.ProductId,
                    p.ProductName,
                    CategoryName = p.Category?.CategoryName ?? "N/A",
                    CompanyName = p.Supplier?.CompanyName ?? "N/A",
                    p.QuantityPerUnit,
                    p.UnitPrice,
                    p.UnitsInStock,
                    p.UnitsOnOrder,
                    p.ReorderLevel,
                    p.Discontinued
                }).ToList();

                ProductDgv.AutoGenerateColumns = true;
                ProductDgv.DataSource = productosMostrados;

                if (productosMostrados.Count == 0)
                {
                    MessageBox.Show("No se encontraron productos con los filtros aplicados.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ConfigurarComboFiltrosAsync()
        {
            try
            {
                // Status
                StatusCbx.Items.Clear();
                StatusCbx.Items.Add("Todos");
                StatusCbx.Items.Add("Activos");
                StatusCbx.Items.Add("Descontinuados");
                StatusCbx.SelectedIndex = 1; // Por defecto: "Activos"

                // Categorías
                var categorias = await _productService.GetAllCategoriesAsync();
                CmbxCat.Items.Clear();
                CmbxCat.Items.Add("Todas");
                foreach (var cat in categorias)
                    CmbxCat.Items.Add(cat.CategoryName);
                CmbxCat.SelectedIndex = 0;

                // Suplidores
                var suplidores = await _productService.GetAllSuppliersAsync();
                CmbxSup.Items.Clear();
                CmbxSup.Items.Add("Todos");
                foreach (var sup in suplidores)
                    CmbxSup.Items.Add(sup.CompanyName);
                CmbxSup.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al configurar filtros: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetService<ProductcrearFrm>();
            if (form != null)
            {
                form.FormClosed += async (s, args) => await CargarProductosAsync();
                form.ShowDialog();
            }
        }

        private async void BtUpdate_Click(object sender, EventArgs e)
        {
            if (ProductDgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un producto para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var productoSeleccionado = ProductDgv.SelectedRows[0].DataBoundItem;
            var productId = (int)productoSeleccionado.GetType().GetProperty("ProductId").GetValue(productoSeleccionado);
            var producto = (await _productService.GetAllAsync()).FirstOrDefault(p => p.ProductId == productId);

            if (producto != null)
            {
                var form = _serviceProvider.GetService<ProductcrearFrm>();
                if (form != null)
                {
                    form.SetEditMode(producto);
                    form.FormClosed += async (s, args) => await CargarProductosAsync();
                    form.ShowDialog();
                }
            }
        }

        private async void BtDelete_Click(object sender, EventArgs e)
        {
            if (ProductDgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un producto para descontinuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var productoSeleccionado = ProductDgv.SelectedRows[0].DataBoundItem;
            var productId = (int)productoSeleccionado.GetType().GetProperty("ProductId").GetValue(productoSeleccionado);
            var producto = (await _productService.GetAllAsync()).FirstOrDefault(p => p.ProductId == productId);

            if (producto != null)
            {
                var confirmar = MessageBox.Show($"¿Deseas marcar como descontinuado el producto '{producto.ProductName}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmar == DialogResult.Yes)
                {
                    producto.Discontinued = true;

                    try
                    {
                        await _productService.UpdateAsync(producto);
                        await CargarProductosAsync();
                        MessageBox.Show("Producto marcado como descontinuado.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al marcar como descontinuado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            _menuFrm.Show();
            this.Close();
        }

        private async void BtSearch_Click(object sender, EventArgs e)
        {
            await CargarProductosAsync();
        }
    }
}