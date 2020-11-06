using Bai2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai2.ViewModels
{
    public class ProductViewmodel
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> CategoryeSelectList { get; set; }
    }
}
