using Esatto_Recruitment_WinForms.Services;
using Esatto_Recruitment_WinForms.Database;
using Esatto_Recruitment_WinForms.Services;

namespace Esatto_Recruitment_WinForms
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(new ProductService(), new CurrencyService(), new CurrencyExchangeAPIService()));
        }
    }
}