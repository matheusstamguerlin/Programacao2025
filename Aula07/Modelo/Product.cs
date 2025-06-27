using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Product
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public int CurrentPrice { get; set; }
        public bool Validate()
        {
            bool isValid = true;

            isValid = !string.IsNullOrEmpty(ProductName) &&
            this.CurrentPrice > 0 && this.Id > 0;

            return isValid;
        }

        public Customer Retrieve()
        {
            return new Customer();
        }

        public void Save(Customer customer)
        {}
    }
}
