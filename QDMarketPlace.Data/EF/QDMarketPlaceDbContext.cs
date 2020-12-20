using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace QDMarketPlace.Data.EF
{
    public  class QDMarketPlaceDbContext:DbContext
    {
        public QDMarketPlaceDbContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }    
    }
}
