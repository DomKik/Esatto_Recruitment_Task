using Esatto_Recruitment_WinForms.Database;
using Esatto_Recruitment_WinForms.Interfaces;
using Esatto_Recruitment_WinForms.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esatto_Recruitment_WinForms.Services
{
    public class CurrencyService : ICurrencyService
    {
        public async Task UpdateCurrencies(IEnumerable<CurrencyInfo> newestCurrencies)
        {
            using (var dbContext = new SQLiteDbContext())
            {
                var existing = await dbContext.Currencies
                    .Select(c => new { c.Table, c.Code })
                    .ToListAsync();

                var existingSet = new HashSet<string>(existing.Select(e => e.Code));

                var newCurrencies = newestCurrencies
                    .Where(c => !existingSet.Contains(c.Code))
                    .Select(c => new CurrencyInfo
                    {
                        Id = c.Id,
                        Table = c.Table,
                        Code = c.Code,
                        Name = c.Name
                    })
                    .ToList();

                newCurrencies.Add(new CurrencyInfo
                {
                    Table = "",
                    Code = "PLN",
                    Name = "polski złoty"
                });

                if (newCurrencies.Count > 0)
                {
                    dbContext.Currencies.AddRange(newCurrencies);
                    await dbContext.SaveChangesAsync();
                }
            }
                
        }

        public int CountCurrencies()
        {
            using (var dbContext = new SQLiteDbContext())
            {
                return dbContext.Currencies.ToList().Count;
            }
        }

        public IEnumerable<CurrencyInfo> GetAllCurrencies()
        {
            using (var dbContext = new SQLiteDbContext())
            {
                return dbContext.Currencies.ToList();
            }
        }
    }
}
