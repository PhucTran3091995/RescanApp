using HSEVIMES_PCBA_Config.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;

namespace HSEVIMES_PCBA_Config.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TbScanOut> TbScanOut { get; set; }
        public DbSet<TbRescan> TbRescan { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var host = ConfigurationManager.AppSettings["MySqlHost"];
                var port = ConfigurationManager.AppSettings["MySqlPort"];
                var user = ConfigurationManager.AppSettings["MySqlUser"];
                var password = ConfigurationManager.AppSettings["MySqlPassword"];
                var database = ConfigurationManager.AppSettings["MySqlDatabase"];

                var connectionString = $"server={host};port={port};database={database};user={user};password={password};";
                optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 36)));
            }
        }
    }
}