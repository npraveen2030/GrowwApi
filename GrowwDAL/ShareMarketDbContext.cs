using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using GrowwModel;
using Microsoft.EntityFrameworkCore;

namespace GrowwDAL
{
    public class ShareMarketDbContext : DbContext
    {
        public ShareMarketDbContext(DbContextOptions<ShareMarketDbContext> options) : base(options) { }

        public DbSet<StockPrice> StockPrices { get; set; }
        public DbSet<MasterDate> MasterDates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockPrice>().ToTable("StockPrice", "ShareMarket");
            modelBuilder.Entity<MasterDate>().ToTable("MasterDate", "ShareMarket");
        }
    }

}
