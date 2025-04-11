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

        private static string _dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");

        public SQLiteDbContext()
        {
            EnsureDatabaseCreated();
        }

        public SQLiteDbContext(DbContextOptions<SQLiteDbContext> options) : base(options)
        {
            EnsureDatabaseCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_dbPath}");
        }

        private void EnsureDatabaseCreated()
        {
            if (!File.Exists(_dbPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_dbPath)!);
            }

            this.Database.EnsureCreated();
        }
    }

}
