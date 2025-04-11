using Esatto_Recruitment_WinForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esatto_Recruitment_WinForms.Interfaces
{
    public interface ICurrencyService
    {
        public Task UpdateCurrencies(IEnumerable<CurrencyInfo> newestCurrencies);
        public int CountCurrencies();
        public IEnumerable<CurrencyInfo> GetAllCurrencies();
    }
}
