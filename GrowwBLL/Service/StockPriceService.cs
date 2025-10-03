using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrowwBLL.Interface;
using GrowwDAL.Interface;
using GrowwModel;

namespace GrowwBLL.Service
{
    public class StockPriceService : IStockPriceService
    {
        private readonly IStockPriceRepository _repository;

        public StockPriceService(IStockPriceRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StockPrice>> GetStockPriceByRangeAsync(string range, int stockId)
        {
            return await _repository.GetStockPriceByRangeAsync(range, stockId);
        }
    }

}
