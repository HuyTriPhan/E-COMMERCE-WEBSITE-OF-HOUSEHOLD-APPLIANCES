using DoGiaDungPN.Models;
using DoGiaDungPN.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DoGiaDungPN.Controllers
{
	public class HomeController : Controller
	{
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(IProductRepository productRepository, ICategoryRepository categoryRepository)
		{
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index(string query)
        {
            IEnumerable<Product> products;

            if (string.IsNullOrEmpty(query))
            {
                // Nếu không có từ khóa tìm kiếm, hiển thị toàn bộ sản phẩm
                products = await _productRepository.GetAllAsync();
            }
            else
            {
                // Nếu có từ khóa tìm kiếm, tìm kiếm sản phẩm dựa trên query
                products = await _productRepository.SearchAsync(query);
            }

            var categories = await _categoryRepository.GetAllAsync();
            ViewData["Categories"] = categories;

            return View(products);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product); // Tr? v? view Details v?i m?t ??i t??ng Product c? th?
        
        }
    }
}
