using Microsoft.AspNetCore.Mvc;
using Repository;
using _05ClassesEntidades.ViewModels;
using Modelo;

namespace _05ClassesEntidades.Controllers
{
    public class OrderController : Controller
    {
        private readonly IWebHostEnvironment environment;
        private readonly OrderRepository _orderRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly ProductRepository _productRepository;

        public OrderController(IWebHostEnvironment environment)
        {
            this.environment = environment;
            _orderRepository = new OrderRepository();
            _customerRepository = new CustomerRepository();
            _productRepository = new ProductRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_orderRepository.RetrieveAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<SelectedItem> items = [];
            OrderViewModel viewModel = new();
            viewModel.Customers = _customerRepository.RetrieveAll();
            var products = _productRepository.RetrieveAll();

            foreach (var product in products)
            {
                items.Add(new SelectedItem() {
                    OrderItem = new() { Product = product } 
                }); 
            }
            viewModel.SelectedItems = items;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel model)
        {
            Order order = new()
            {
                Customer = _customerRepository.Retrieve(model.CustomerId!.Value),
                OrderDate = DateTime.Now
            };

            int count = 1;
            foreach (var item in model.SelectedItems!)
            {
                if (item.IsSelected)
                {
                    order.OrderItems!.Add(
                        new OrderItem()
                        {
                            Id = count,
                            Product = _productRepository.Retrieve(item.OrderItem.Product!.Id),
                            Quantity = item.OrderItem.Quantity,
                            PurchasePrice = item.OrderItem.PurchasePrice
                        }
                    );

                    count++;
                }
            }

            _orderRepository.Save(order);

            return RedirectToAction("Index");
        }
    }
}
