using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AddressRepository
    {
        public Address Retrieve()
        {
            return new Address();
        }
        public void Save(Address address)
        { }
    }
}
