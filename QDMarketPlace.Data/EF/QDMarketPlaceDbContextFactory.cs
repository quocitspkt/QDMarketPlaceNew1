using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QDMarketPlace.Data.EF
{
    class QDMarketPlaceDbContextFactory : IDesignTimeDbContextFactory<QDMarketPlaceDbContext>
    {
        public QDMarketPlaceDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("QDMarketPlaceDb");

            var optionsBuilder = new DbContextOptionsBuilder<QDMarketPlaceDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new QDMarketPlaceDbContext(optionsBuilder.Options);
        }
    }
}
