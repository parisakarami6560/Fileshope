using filshopfilecor.Service.Interfase;
using Microsoft.AspNetCore.Mvc;

namespace Filshopfil.Controllers
{
    public class ProductController : Controller
    {
        IproductServis _productservis;
        public ProductController(IproductServis productservis)
        {
            _productservis = productservis; 
        }
        public IActionResult ShowProduct(int id)
        {
            var model = _productservis.GetproductForshow(id);
            if(model == null)
            {
                return NotFound();  
            }
            return View( );
        }

        public IActionResult Product()
        {
            return View();
        }
    }
}
