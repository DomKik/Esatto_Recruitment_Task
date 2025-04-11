using Esatto_Recruitment_WinForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esatto_Recruitment_WinForms.Interfaces
{
    public interface ICurrencyExchangeAPIService
    {
        public Task<decimal> GetCurrentExchangeRate(string code);
        public Task<List<CurrencyInfo>> GetAllCurrenciesInfo();
    }
}
