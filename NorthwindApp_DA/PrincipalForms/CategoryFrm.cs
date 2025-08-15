using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Servicios;
using Northwind.Core.Models;
using NorthwindApp_DA.CrearEditRegisFrm;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindApp_DA
{
    public partial class CategoryFrm : Form
    {
        private readonly CategoryService _categoryService;
        private readonly IServiceProvider _serviceProvider;
        private readonly MenuFrm _menuFrm;

        public CategoryFrm(CategoryService categoryService, IServiceProvider serviceProvider, MenuFrm menuFrm)
        {
            InitializeComponent();
            _categoryService = categoryService;
            _serviceProvider = serviceProvider;
            _menuFrm = menuFrm;
            CargarCategoriasAsync().ConfigureAwait(false); // Carga asíncrona al iniciar
        }

        private async Task CargarCategoriasAsync()
        {
            try
            {
                var categories = await _categoryService.GetAllAsync();
                CategoryDtGvw.DataSource = categories;
                CategoryDtGvw.Columns[nameof(Category.Products)].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar las categorías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CategoryFrm_Load(object sender, EventArgs e)
        {
            // La carga ya se hace en el constructor con async
        }

        private async void BtUpdate_Click(object sender, EventArgs e)
        {
            if (CategoryDtGvw.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una categoría para editar.");
                return;
            }

            var category = (Category)CategoryDtGvw.SelectedRows[0].DataBoundItem;
            var form = _serviceProvider.GetService<CategoryCrearFrm>();
            if (form != null)
            {
                form.SetEditMode(category);
                form.FormClosed += async (s, args) => await CargarCategoriasAsync();
                form.ShowDialog();
            }
        }

        private async void BtDelete_Click(object sender, EventArgs e)
        {
            if (CategoryDtGvw.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una categoría para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var category = (Category)CategoryDtGvw.SelectedRows[0].DataBoundItem;

            var confirmar = MessageBox.Show($"¿Deseas eliminar '{category.CategoryName}'?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmar == DialogResult.Yes)
            {
                await _categoryService.DeleteAsync(category.CategoryId);
                await CargarCategoriasAsync();
            }
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            _menuFrm.Show();
            this.Close();
        }

        private void BtAddCat_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetService<CategoryCrearFrm>();
            if (form != null)
            {
                form.FormClosed += async (s, args) => await CargarCategoriasAsync(); // Recargar lista al cerrar
                form.ShowDialog();
            }
        }
    }
}