using Bai2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai2.ViewModels
{
    public class HomeIndexVM
    {
        public List<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
