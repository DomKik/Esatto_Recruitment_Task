using Esatto_Recruitment_WinForms.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Esatto_Recruitment_WinForms.Database
{
    public class SQLiteDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<CurrencyInfo> Currencies { get; set; }

        public SQLiteDbContext()
        {

        }
        public SQLiteDbContext(DbContextOptions<SQLiteDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string AppPath = AppDomain.CurrentDomain.BaseDirectory;
            string dbPath = Path.Combine(AppPath, "database.db");

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
