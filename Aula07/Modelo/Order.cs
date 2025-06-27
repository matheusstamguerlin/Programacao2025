namespace Modelo
{
    public class Order
    {
        #region Atributos
        public int Id { get; set; }
        public Customer? Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public Address? ShippingAddress { get; set; }
        public List<OrderItem>? OrderItems { get; set; }
        #endregion

        public Order() // Construtor 
        { 
            OrderDate = DateTime.Now;
            OrderItems = new List<OrderItem>();
        }
        public Order(int orderId) : this() // esta função chama o construtor sem parâmetros
        {
            this.Id = orderId;
        }

        public Order(Address address) : this() // esta função chama o construtor sem parâmetros
        {
            ShippingAddress = address;
        }
        public bool Validate()
        {
            bool isValid = true;

            isValid = this.Customer != null &&
            this.OrderDate != DateTime.MinValue && 
            this.Id > 0 &&
            ShippingAddress != null &&
            OrderItems != null;

            return isValid;
        }

        public Order Retrieve(int orderId)
        {
            return new Order();
        }
    }
}
