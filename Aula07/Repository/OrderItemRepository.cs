using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderItemRepository
    {

        public OrderItem Retrieve()
        {
            return new OrderItem();
        }
        public void Save(OrderItem orderItem)
        { }
    }
}
