using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esatto_Recruitment_WinForms.Models
{
    public class CurrencyInfo
    {
        public int Id { get; set; }
        public string Table { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string FormattedDisplay
        {
            get
            {
                return $"({Code}) {Name}";
            }
        }
    }
}
