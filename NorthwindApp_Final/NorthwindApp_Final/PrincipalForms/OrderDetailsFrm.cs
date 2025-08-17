using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Services;
using NorthwindApp_Final.CrearEditRegisFrm;
using System;
using System.Windows.Forms;

namespace NorthwindApp_Final.PrincipalForms
{
    public partial class OrderDetailsFrm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly OrderDetailsService _orderDetailsService;
        private readonly MenuFrm _menuFrm;

        public OrderDetailsFrm(IServiceProvider serviceProvider, OrderDetailsService orderDetailsService, MenuFrm menuFrm)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _orderDetailsService = orderDetailsService ?? throw new ArgumentNullException(nameof(orderDetailsService));
            _menuFrm = menuFrm ?? throw new ArgumentNullException(nameof(menuFrm));
            this.Load += new EventHandler(CargarOrdenesDetalle); // Carga sincrónica al iniciar
        }

        private void CargarOrdenesDetalle(object sender, EventArgs e)
        {
            try
            {
                var orderDetails = _orderDetailsService.GetOrderWithDetailsAsync();
                if (orderDetails != null && orderDetails.Count > 0)
                {
                    OrderDetailDgv.DataSource = orderDetails;
                    ConfigurarEncabezados();
                }
                else
                {
                    MessageBox.Show("No hay detalles de órdenes disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OrderDetailDgv.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar detalles de órdenes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarOrderDetailsAsync(int orderId)
        {
            try
            {
                var detalles = _orderDetailsService.GetOrderWithDetailsByOrderIdAsync(orderId);
                if (detalles != null && detalles.Count > 0)
                {
                    OrderDetailDgv.DataSource = detalles;
                    ConfigurarEncabezados();
                }
                else
                {
                    MessageBox.Show($"No se encontraron detalles para la orden con ID {orderId}.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OrderDetailDgv.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar detalles para la orden {orderId}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarEncabezados()
        {
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

        private void BtClose_Click(object sender, EventArgs e)
        {
            _menuFrm.Show();
            this.Close();
        }

        private void OrderDetailsFrm_Load(object sender, EventArgs e)
        {
            // La carga ya se hace en el evento Load
        }

        private void BtSearch_Click_1(object sender, EventArgs e)
        {
            string textoFiltro = TxtFiltroOrderD.Text.Trim();

            if (string.IsNullOrEmpty(textoFiltro))
            {
                // Si el TextBox está vacío, carga todos los detalles
                CargarOrdenesDetalle(sender, e);
            }
            else if (int.TryParse(textoFiltro, out int orderId))
            {
                // Si el texto es un número válido, carga los detalles filtrados
                CargarOrderDetailsAsync(orderId);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de orden válido (número entero) o deje el campo vacío para ver todos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}