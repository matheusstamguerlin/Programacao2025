using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Product? Product { get; set; }
        public double Quantity { get; set; }
        public double PurchasePrice { get; set; }

        public bool Validate()
        {
            bool isValid = true;

            isValid = this.Product != null &&
            this.Quantity > 0 &&
            this.Id > 0 &&
            this.PurchasePrice > 0;
             
            return isValid;
        }
    }
}
