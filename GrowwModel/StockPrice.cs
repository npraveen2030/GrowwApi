using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowwModel
{
    public class StockPrice
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public decimal Price { get; set; }
        public DateTime StockDate { get; set; }
        public bool IsActive { get; set; }

        public MasterDate MasterDate { get; set; }
    }
}
