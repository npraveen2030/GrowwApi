using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrowwModel;

namespace GrowwDAL.Interface
{
    public interface IStockPriceRepository
    {
        Task<List<StockPrice>> GetStockPriceByRangeAsync(string range, int stockId);
    }

}
