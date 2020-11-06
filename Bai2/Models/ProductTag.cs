using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai2.Models
{
    public class ProductTag
    {
        public int ProductId { set; get; }
        public int TagId { set; get; }
        public Product Product { set; get; }
        public Tag Tag { set; get; }
    }
}
