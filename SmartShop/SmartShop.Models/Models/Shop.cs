using System.Collections.Generic;

namespace SmartShop.Models.Models
{
    public class Shop
    {
        public Shop()
        {
            this.Cashboxes = new HashSet<Cashbox>();
        }

        public int IdShop { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Cashbox> Cashboxes { get; set; }

    }
}
