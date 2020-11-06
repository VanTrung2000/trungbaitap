using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;             
using System.Linq;
using System.Threading.Tasks;

namespace Bai2.Models
{
    public class Category
    {
        public int Id { get; set; }
        [DisplayName("Ten the loai")]
        [Required]
        [MinLength(3)]
        public string CategoryName { get; set; }
        [DisplayName("Mo ta the loai")]
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
