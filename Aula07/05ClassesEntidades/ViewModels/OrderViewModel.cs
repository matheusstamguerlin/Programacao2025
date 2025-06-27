using Modelo;

namespace _05ClassesEntidades.ViewModels
{
    public class OrderViewModel
    {
        public int? CustomerId { get; set; }
        public List<Customer> Customers { get; set; } = [];
        public List<SelectedItem>? SelectedItems { get; set; }
    }

    public class SelectedItem
    {
        public bool IsSelected { get; set; } = false;
        public OrderItem OrderItem { get; set; } = null!;
    }
}
