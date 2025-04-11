using Esatto_Recruitment_WinForms.Interfaces;
using Esatto_Recruitment_WinForms.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Esatto_Recruitment_WinForms.Services
{

    public class ExchangeRateResponse
    {
        public string Table { get; set; }
        public string Currency { get; set; }
        public string Code { get; set; }
        public Rate[] Rates { get; set; }
    }

    public class Rate
    {
        public string No { get; set; }
        public string EffectiveDate { get; set; }
        public decimal Mid { get; set; }
    }
    public class CurrencyExchangeAPIService : ICurrencyExchangeAPIService
    {

        private Dictionary<string, decimal> exchangeRates = new Dictionary<string, decimal>();
        public async Task<decimal> GetCurrentExchangeRate(string code="usd")
        {
            if(code.ToLower() == "pln")
            {
                return 1;
            }

            if(exchangeRates.ContainsKey(code))
            {
                return exchangeRates[code];
            }

            string url = $"https://api.nbp.pl/api/exchangerates/rates/a/{code}/?format=json";
            string url2 = $"https://api.nbp.pl/api/exchangerates/rates/b/{code}/?format=json";

            using HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                if(!response.IsSuccessStatusCode)
                {
                    response = await client.GetAsync(url2);
                    response.EnsureSuccessStatusCode();
                }

                string json = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                ExchangeRateResponse data = JsonSerializer.Deserialize<ExchangeRateResponse>(json, options);

                if(data != null)
                {
                    exchangeRates.Add(code, data.Rates[0].Mid);
                    return data.Rates[0].Mid;
                }

                return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<List<CurrencyInfo>> GetAllCurrenciesInfo()
        {
            var tables = new[] { "a", "b" };
            var result = new List<CurrencyInfo>();

            HttpClient client = new HttpClient();

            foreach (var table in tables)
            {
                var url = $"https://api.nbp.pl/api/exchangerates/tables/{table}/?format=json";

                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                    continue;

                var json = await response.Content.ReadAsStringAsync();

                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement[0];

                if (root.TryGetProperty("rates", out JsonElement rates))
                {
                    foreach (var rate in rates.EnumerateArray())
                    {
                        var item = new CurrencyInfo
                        {
                            Table = table,
                            Name = rate.GetProperty("currency").GetString(),
                            Code = rate.GetProperty("code").GetString()
                        };

                        result.Add(item);
                    }
                }
            }

            return result;
        }
    }
}
