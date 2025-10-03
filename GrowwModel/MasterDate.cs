using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowwModel
{
    public class MasterDate
    {
        public int Id { get; set; }
        public DateTime TradeDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsActive { get; set; }

        public ICollection<StockPrice> StockPrices { get; set; }
    }
}
