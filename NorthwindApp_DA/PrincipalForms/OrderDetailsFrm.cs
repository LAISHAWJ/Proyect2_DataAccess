using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindApp_DA.PrincipalForms
{
    public partial class OrderDetailsFrm : Form
    {
        private readonly IServiceProvider _services;
        private readonly MenuFrm _menuFrm;
        public OrderDetailsFrm(IServiceProvider services, MenuFrm menuFrm)
        {
            InitializeComponent();
            _services = services;
            _menuFrm = menuFrm;
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            _menuFrm.Show();
            this.Close();
        }
    }
}
