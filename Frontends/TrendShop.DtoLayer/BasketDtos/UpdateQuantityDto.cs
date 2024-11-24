using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendShop.DtoLayer.BasketDtos
{
    public class UpdateQuantityDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

}
