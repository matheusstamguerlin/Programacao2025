using Modelo; // Não é a melhor alternativa, mas para poupar tepo, utilizaremos esta
using Repository;
using Microsoft.AspNetCore.Mvc;

namespace _05ClassesEntidades.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment environment;

        private ProductRepository _productRepository;

        public ProductController(IWebHostEnvironment environment)
        {
            _productRepository = new ProductRepository();
            this.environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = _productRepository.RetrieveAll();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product p)
        {
            _productRepository.Save(p);

            List<Product> products = _productRepository.RetrieveAll();

            return View("Index", products);

            // return View();
            // Se nenhum valor for especificado, ele voltará para o método que o chamou (Create)
        }

        [HttpGet]
        public IActionResult ExportDelimitatedFile()
        {
            string fileContent = string.Empty;
            foreach (Product p in CustomerData.Products)
            {
                fileContent +=
                       $"{p.Id};\n{p.ProductName};\n{p.Description};\n{p.CurrentPrice}\n\n";
            }

            var path = Path.Combine(
                environment.WebRootPath,
                "TextFiles"
            );

            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);

            var filepath = Path.Combine(
                path,
                "Produtos.txt"
            );

            if (!System.IO.File.Exists(filepath))
            {
                using StreamWriter sw = System.IO.File.CreateText(filepath);
                sw.Write(fileContent);
            }

            return View();
        }
    }
}
