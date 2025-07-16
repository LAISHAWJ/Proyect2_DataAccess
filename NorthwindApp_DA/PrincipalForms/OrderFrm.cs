namespace NorthwindApp_DA
{
    public partial class OrderFrm : Form
    {
        private readonly IServiceProvider _services;
        private readonly MenuFrm _menuFrm;
        public OrderFrm(IServiceProvider services, MenuFrm menuFrm)
        {
            InitializeComponent();
            _services = services;
            _menuFrm = menuFrm;
        }

        private void OrderFrm_Load(object sender, EventArgs e)
        {

        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            _menuFrm.Show();
            this.Close();
        }
    }
}
