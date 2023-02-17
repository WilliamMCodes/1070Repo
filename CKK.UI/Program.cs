using CKK.DB.UOW;
using CKK.GUI.WinForms;
namespace CKK.GUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            UnitOfWork Store = new UnitOfWork(new DatabaseConnectionFactory());
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(Store));
        }
    }
}