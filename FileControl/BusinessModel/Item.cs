using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Item_Name { get; set; }
        public Decimal Item_Rate { get; set; }
        public Decimal Item_Quantity { get; set; }
        public Decimal Discount { get; set; }
        public Decimal Amount { get; set; }



    }
}
