namespace NorthwindApp_DA
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();
            Application.Run(new MenuFrm());
        }
    }
}