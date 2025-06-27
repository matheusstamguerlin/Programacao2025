using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository
    {
        public Product Retrieve(int id)
        {
            foreach (Product c in CustomerData.Products)
            {
                if (c.Id == id) return c;
            }

            return null!;
        }

        public List<Product> RetrieveByName(string name)
        {
            List<Product> ret = [];

            foreach (Product p in CustomerData.Products)
            {
                if (p.ProductName!.ToLower().Contains(name.ToLower()))
                {
                    ret.Add(p);
                }
            }

            return ret;
        }

        public List<Product> RetrieveAll()
        {
            return CustomerData.Products;
        }

        public bool Delete(Product product) 
        {
            return CustomerData.Products.Remove(product);
        }

        public void Update(Product newProduct)
        { 
            Product oldProduct = Retrieve(newProduct.Id);

            oldProduct.ProductName = newProduct.ProductName;
            oldProduct.Description = newProduct.Description;
            oldProduct.CurrentPrice = newProduct.CurrentPrice;
        }

        public void Save(Product product)
        {
            product.Id = GetCount() + 1;
            CustomerData.Products.Add(product);
        }
        public bool DeleteById(int id)
        {
            Product product = Retrieve(id);

            if (product != null) return Delete(product);

            return false;
        }

        public int GetCount()
        {
            return CustomerData.Products.Count;
        }
    }
}
