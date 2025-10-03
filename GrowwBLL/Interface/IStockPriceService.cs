using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrowwModel;

namespace GrowwBLL.Interface
{
    public interface IStockPriceService
    {
        Task<List<StockPrice>> GetStockPriceByRangeAsync(string range, int stockId);
    }

}
