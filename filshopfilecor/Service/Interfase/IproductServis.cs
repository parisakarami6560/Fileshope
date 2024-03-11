
using Filshopfil.DataLayer.entites.product;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace filshopfilecor.Service.Interfase
{
    public interface IproductServis
    {
        public IEnumerable<Product> GetProductforadmin();
        public IEnumerable<ProductGroup> GetProductGroupsforadmin();
        void CreateproductGroup(ProductGroup productgroup);
        ProductGroup Getgroup (int id);
        List<SelectlistItem> GetGroupForProduct();
        Product GetproductForshow(int productid);  

        void CreatPtoduct(Product model, IFormFile file, IFormFile img);
        Product GetProductByid(int productId);
        void EditProduct(Product product, IFormFile file, IFormFile img);  
        void SofteDeleteproduct(int productId); 
    }
}
