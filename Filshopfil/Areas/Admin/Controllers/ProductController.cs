using Filshopfil.DataLayer.entites.product;
using filshopfilecor.Service.Interfase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;


namespace Filshopfil.Areas.Admin.Controllers
{
    [Area("Admin")]
   [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
       
        IproductServis _productservis;
        public ProductController(IproductServis productservis)
        {
            Productservis = productservis;
        }

        public IproductServis Productservis { get => _productservis; set => _productservis = value; }

        public IActionResult Index()
        {
            var model = Productservis.GetProductforadmin();
            return View(model);
        }

        public IActionResult Createproduct()
        {
           var groups =_productservis.GetGroupForProduct();
            ViewData["groups"] = new SelectList(groups, "Value", "Text");
            return View();
        }
        [HttpPost]
        public IActionResult Createproduct(Product model,IFormFile File, IFormFile ImageFile )
        {
            _productservis.CreatPtoduct(model, File, ImageFile);    
            return RedirectToAction("Index");   
        }
        public IActionResult EditProduct(int id)
        {
            var model=_productservis.GetProductByid(id);
            var groups = _productservis.GetGroupForProduct();
            ViewData["groups"] = new SelectList(groups, "Value", "Text",model.ProductGroupId);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditProduct( Product model, IFormFile File, IFormFile ImageFile)
        {
            _productservis.EditProduct(model,File,ImageFile);  
            return RedirectToAction(nameof(Index)); 
        }
     public  IActionResult DeleteProduct (int id)
        {
            _productservis.SofteDeleteproduct(id);  
            return RedirectToAction(nameof(Index));
        }
        #region  product group
        public IActionResult GroupIndex()
        {
            var model = Productservis.GetProductGroupsforadmin();
            return View(model);
        }
        [HttpGet]
        public IActionResult CreateproductGroup(int id = 0)
        {
            ProductGroup model = new ProductGroup

            {
                ProductGroupId = id,
                GroupName = ""

            };
            if (id != 0)
            {
                model.GroupName = _productservis.Getgroup(id).GroupName;
            }


            return View(model);







        }
        [HttpPost]
        public IActionResult CreateproductGroup(ProductGroup group)
        {
            _productservis.CreateproductGroup(group);
            return RedirectToAction(nameof(GroupIndex));
        }
    }


    #endregion


   

    }
