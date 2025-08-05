using Microsoft.EntityFrameworkCore;
using NorthwindApp_DA.Data;
using NorthwindApp_DA.Models;
using NorthwindApp_DA.Repository;
using System.Windows.Forms;

namespace NorthwindApp_DA.PrincipalForms
{
    public partial class OrderDetailsFrm : Form
    {
        private readonly IServiceProvider _serviceProvider = Program.ServiceProvider;
        private readonly OrderDetailsRepos _orderDetailsRepos;
        private readonly MenuFrm _menuFrm;

        public OrderDetailsFrm(IServiceProvider serviceProvider, OrderDetailsRepos orderDetailsRepos, MenuFrm menuFrm)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _orderDetailsRepos = orderDetailsRepos;
            _menuFrm = menuFrm;
        }

        private void CargarOrdenesDetalle()
        {
            var orderDetails = _orderDetailsRepos.GetOrderWithDetails();
            if (orderDetails != null && orderDetails.Count > 0)
            {
                OrderDetailDgv.DataSource = orderDetails;
                OrderDetailDgv.Columns["OrderId"].HeaderText = "ID Orden";
                OrderDetailDgv.Columns["CompanyName"].HeaderText = "Cliente";
                OrderDetailDgv.Columns["LastName"].HeaderText = "Empleado";
                OrderDetailDgv.Columns["OrderDate"].HeaderText = "Fecha Orden";
                OrderDetailDgv.Columns["RequiredDate"].HeaderText = "Fecha Requerida";
                OrderDetailDgv.Columns["ShippedDate"].HeaderText = "Fecha Envío";
                OrderDetailDgv.Columns["ShipViaName"].HeaderText = "Transportista";
                OrderDetailDgv.Columns["Freight"].HeaderText = "Cargos";
                OrderDetailDgv.Columns["ShipName"].HeaderText = "Destinatario";
                OrderDetailDgv.Columns["ShipAddress"].HeaderText = "Dirección Envío";
                OrderDetailDgv.Columns["ShipCity"].HeaderText = "Ciudad Envío";
                OrderDetailDgv.Columns["ShipRegion"].HeaderText = "Región Envío";
                OrderDetailDgv.Columns["ShipPostalCode"].HeaderText = "Código Postal";
                OrderDetailDgv.Columns["ShipCountry"].HeaderText = "País Envío";
                OrderDetailDgv.Columns["ProductName"].HeaderText = "Nombre Producto";
                OrderDetailDgv.Columns["UnitPrice"].HeaderText = "Precio Unitario";
                OrderDetailDgv.Columns["Quantity"].HeaderText = "Cantidad";
                OrderDetailDgv.Columns["Discount"].HeaderText = "Descuento";
            }
            else
            {
                MessageBox.Show("No hay detalles de órdenes disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OrderDetailDgv.DataSource = null;
            }
        }

        private void CargarOrderDetails(int orderId)
        {
            var detalles = _orderDetailsRepos.GetOrderWithDetailsByOrderId(orderId);
            if (detalles != null && detalles.Count > 0)
            {
                OrderDetailDgv.DataSource = detalles;
                OrderDetailDgv.Columns["OrderId"].HeaderText = "ID Orden";
                OrderDetailDgv.Columns["CompanyName"].HeaderText = "Cliente";
                OrderDetailDgv.Columns["LastName"].HeaderText = "Empleado";
                OrderDetailDgv.Columns["OrderDate"].HeaderText = "Fecha Orden";
                OrderDetailDgv.Columns["RequiredDate"].HeaderText = "Fecha Requerida";
                OrderDetailDgv.Columns["ShippedDate"].HeaderText = "Fecha Envío";
                OrderDetailDgv.Columns["ShipViaName"].HeaderText = "Transportista";
                OrderDetailDgv.Columns["Freight"].HeaderText = "Cargos";
                OrderDetailDgv.Columns["ShipName"].HeaderText = "Destinatario";
                OrderDetailDgv.Columns["ShipAddress"].HeaderText = "Dirección Envío";
                OrderDetailDgv.Columns["ShipCity"].HeaderText = "Ciudad Envío";
                OrderDetailDgv.Columns["ShipRegion"].HeaderText = "Región Envío";
                OrderDetailDgv.Columns["ShipPostalCode"].HeaderText = "Código Postal";
                OrderDetailDgv.Columns["ShipCountry"].HeaderText = "País Envío";
                OrderDetailDgv.Columns["ProductName"].HeaderText = "Nombre Producto";
                OrderDetailDgv.Columns["UnitPrice"].HeaderText = "Precio Unitario";
                OrderDetailDgv.Columns["Quantity"].HeaderText = "Cantidad";
                OrderDetailDgv.Columns["Discount"].HeaderText = "Descuento";
            }
            else
            {
                MessageBox.Show($"No se encontraron detalles para la orden con ID {orderId}.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OrderDetailDgv.DataSource = null;
            }
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            _menuFrm.Show();
            this.Close();
        }

        private void OrderDetailsFrm_Load(object sender, EventArgs e)
        {
            CargarOrdenesDetalle();
        }

        private void BtSearch_Click_1(object sender, EventArgs e)
        {
            string textoFiltro = TxtFiltroOrderD.Text.Trim();

            if (string.IsNullOrEmpty(textoFiltro))
            {
                // Si el TextBox está vacío, carga todos los detalles
                CargarOrdenesDetalle();
            }
            else if (int.TryParse(textoFiltro, out int orderId))
            {
                // Si el texto es un número válido, carga los detalles filtrados
                CargarOrderDetails(orderId);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de orden válido (número entero) o deje el campo vacío para ver todos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}