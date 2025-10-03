using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrowwDAL.Interface;
using GrowwModel;
using Microsoft.EntityFrameworkCore;

namespace GrowwDAL.Repository
{
    public class StockPriceRepository : IStockPriceRepository
    {
        private readonly ShareMarketDbContext _context;

        public StockPriceRepository(ShareMarketDbContext context)
        {
            _context = context;
        }

        public async Task<List<StockPrice>> GetStockPriceByRangeAsync(string range, int stockId)
        {
            try
            {
                DateTime startDate = range switch
                {
                    "1D" => DateTime.Today,
                    "1W" => DateTime.Today.AddDays(-7),
                    "1M" => DateTime.Today.AddMonths(-1),
                    "3M" => DateTime.Today.AddMonths(-3),
                    "6M" => DateTime.Today.AddMonths(-6),
                    "1Y" => DateTime.Today.AddYears(-1),
                    "5Y" => DateTime.Today.AddYears(-5),
                    _ => DateTime.Today.AddMonths(-1)
                };

                return await (from md in _context.MasterDates
                              join sp in _context.StockPrices
                                  on md.TradeDate equals sp.StockDate into spGroup
                              from sp in spGroup.DefaultIfEmpty()
                              where md.TradeDate >= startDate
                                    && md.TradeDate <= DateTime.Today
                                    && md.IsActive
                                    && sp.StockId == stockId
                                    && sp.IsActive
                              orderby md.TradeDate descending
                              select new StockPrice
                              {
                                  Id = sp.Id,
                                  StockId = sp.StockId,
                                  Price = sp.Price,
                                  StockDate = sp.StockDate,
                                  IsActive = sp.IsActive,
                                  MasterDate = md
                              }).ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception here if needed
                throw new ApplicationException("Error in repository while fetching stock prices.", ex);
            }
        }


    }


}
