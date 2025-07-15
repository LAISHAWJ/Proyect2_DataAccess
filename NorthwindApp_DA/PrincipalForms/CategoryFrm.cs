using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NorthwindApp_DA.CrearEditRegisFrm;
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

namespace NorthwindApp_DA
{
    public partial class CategoryFrm : Form
    {
        private readonly CategoryRepos _categoryRepos;
        private readonly IServiceProvider _serviceProvider;
        private MenuFrm _menuFrm;



        public CategoryFrm(CategoryRepos categoryRepos, IServiceProvider serviceProvider, MenuFrm menuFrm)
        {
            InitializeComponent();
            _categoryRepos = categoryRepos;
            _serviceProvider = serviceProvider;
            CargarCategorias();
            _menuFrm = menuFrm;
        }

        private void CargarCategorias()
        {
            try
            {
                CategoryDtGvw.DataSource = _categoryRepos.GetAllCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar las categorías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CategoryFrm_Load(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        private void BtUpdate_Click(object sender, EventArgs e)
        {
            if (CategoryDtGvw.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una categoría para editar.");
                return;
            }

            var categoria = (Category)CategoryDtGvw.SelectedRows[0].DataBoundItem;
            var form = Program.ServiceProvider.GetService<CategoryCrearFrm>();
            if (form != null)
            {
                form.SetEditMode(categoria);
                form.FormClosed += (s, args) => CargarCategorias();
                form.ShowDialog();
            }
        }

        private void BtDelete_Click(object sender, EventArgs e)
        {
            if (CategoryDtGvw.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una categoría para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var categoria = (Category)CategoryDtGvw.SelectedRows[0].DataBoundItem;

            var confirmar = MessageBox.Show($"¿Deseas eliminar '{categoria.CategoryName}'?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmar == DialogResult.Yes)
            {
                _categoryRepos.DeleteCategory(categoria.CategoryId);
                CargarCategorias();
            }
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            _menuFrm.Show();
            this.Close();
        }

        private void BtAddCat_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetService<CategoryCrearFrm>();
            if (form != null)
            {
                form.FormClosed += (s, args) => CargarCategorias(); // recargar lista al cerrar
                form.ShowDialog();
            }
        }
    }
}