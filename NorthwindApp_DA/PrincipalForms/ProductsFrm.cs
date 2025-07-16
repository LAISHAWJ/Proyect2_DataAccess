using Microsoft.Extensions.DependencyInjection;
using NorthwindApp_DA.CrearEditRegisFrm;
using NorthwindApp_DA.Models;
using NorthwindApp_DA.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindApp_DA
{
    public partial class ProductsFrm : Form
    {
        private readonly ProductRepos _productRepos;
        private readonly IServiceProvider _serviceProvider;
        private readonly MenuFrm _menuFrm;
        public ProductsFrm(ProductRepos productRepos, IServiceProvider serviceProvider, MenuFrm menuFrm)
        {
            InitializeComponent();
            _productRepos = productRepos;
            _serviceProvider = serviceProvider;
            _menuFrm = menuFrm;
            CargarProductos();
            
        }

        private void ProductsFrm_Load(object sender, EventArgs e)
        {
            CargarProductos();
            ConfigurarComboFiltros();
        }

        private void CargarProductos()
        {
            var productos = _productRepos.GetAllProducts();

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

            ProductDgv.DataSource = productos;

            if (productos.Count == 0)
            {
                MessageBox.Show("No se encontraron productos con los filtros aplicados.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void ConfigurarComboFiltros()
        {
            //Status
            StatusCbx.Items.Clear();
            StatusCbx.Items.Add("Todos");
            StatusCbx.Items.Add("Activos");
            StatusCbx.Items.Add("Descontinuados");
            StatusCbx.SelectedIndex = 1; // Por defecto: "Activos"

            // Categorías
            var categorias = _productRepos.GetAllCategories(); 
            CmbxCat.Items.Clear();
            CmbxCat.Items.Add("Todas");
            foreach (var cat in categorias)
                CmbxCat.Items.Add(cat.CategoryName);
            CmbxCat.SelectedIndex = 0;

            // Suplidores
            var suplidores = _productRepos.GetAllSuppliers(); 
            CmbxSup.Items.Clear();
            CmbxSup.Items.Add("Todos");
            foreach (var sup in suplidores)
                CmbxSup.Items.Add(sup.CompanyName);
            CmbxSup.SelectedIndex = 0;
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetService<ProductcrearFrm>();
            if (form != null)
            {
                form.FormClosed += (s, args) => CargarProductos();
                form.ShowDialog();
            }
        }

        private void BtUpdate_Click(object sender, EventArgs e)
        {
            if (ProductDgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un producto para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var producto = (Product)ProductDgv.SelectedRows[0].DataBoundItem;
            var form = _serviceProvider.GetService<ProductcrearFrm>();
            if (form != null)
            {
                form.SetEditMode(producto);
                form.FormClosed += (s, args) => CargarProductos();
                form.ShowDialog();
            }
        }

        private void BtDelete_Click(object sender, EventArgs e)
        {
            if (ProductDgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un producto para descontinuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var producto = (Product)ProductDgv.SelectedRows[0].DataBoundItem;

            var confirmar = MessageBox.Show($"¿Deseas marcar como descontinuado el producto '{producto.ProductName}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar == DialogResult.Yes)
            {
                producto.Discontinued = true;

                try
                {
                    _productRepos.UpdateProduct(producto); // Reutilizas el método existente
                    CargarProductos();
                    MessageBox.Show("Producto marcado como descontinuado.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al marcar como descontinuado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            _menuFrm.Show();
            this.Close();
        }

        private void BtSearch_Click(object sender, EventArgs e)
        {
            CargarProductos();
        }
    }
}
