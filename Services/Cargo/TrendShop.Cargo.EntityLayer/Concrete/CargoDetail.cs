using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendShop.Cargo.EntityLayer.Concrete
{
    public class CargoDetail
    {
        public int CargoDetailID { get; set; }

        // Kargoyu gönderen müşteri.
        public string SenderCustomer { get; set; }

        // Kargoyu alan müşteri.
        public string ReceiverCustomer { get; set; }
        public int Barcode { get; set; }
        public int CargoCompanyID { get; set; }
        public CargoCompany CargoCompany { get; set; }
    }
}
