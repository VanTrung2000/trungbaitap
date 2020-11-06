using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai2.Models
{
    public class Tag
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public List<ProductTag> ProductTags { set; get; }
    }
}
