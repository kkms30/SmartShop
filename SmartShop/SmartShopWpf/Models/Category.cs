using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShopWpf.Models
{
    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }

        public int IdCategory { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
