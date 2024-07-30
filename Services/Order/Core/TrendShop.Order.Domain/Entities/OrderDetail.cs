using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendShop.Order.Domain.Entities
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }

        //Ürünler MongoDb'de string olarak tutulduğundan ilişkilendirme adına string tipinde tutuyoruz.
        public string ProductID { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public string ProductName { get; set; }
        public decimal ProductTotalPrice { get; set; } // Genel toplamın hesaplanması
        public decimal OrderingID { get; set; } // Genel toplamın son hali
        public Ordering Ordering { get; set; } // Genel toplamın son hali
    }
}
