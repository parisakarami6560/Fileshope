
using filshopDatalayer.context;
using Filshopfil.DataLayer.entites.product;
using filshopfilecor.Service.Interfase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace filshopfilecor.Service
{
    public class Productservises : IproductServis
    {
        private readonly object file;
        FileShopContext _context;

        public Productservises(FileShopContext context)
        {
            _context = context;
        }

        

        public void CreateproductGroup(ProductGroup productgroup)
        {
            _context.Update(productgroup);
            _context.SaveChanges();
        }

        public void CreatPtoduct(Product model, IFormFile file, IFormFile img)
        {
            model.ImageName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(img.FileName);
            string imgPath = Path.Combine("wwwroot/img", model.ImageName);
            using (var stream = new FileStream(imgPath, FileMode.Create))
            {
                img.CopyTo(stream);
            }

            model.FileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
            string filePath = Path.Combine("wwwroot/files", model.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            _context.Add(model);
            _context.SaveChanges();
        }

        public void EditProduct(Product product, IFormFile file, IFormFile img)
        {
            if(file !=null)
            {
                string Lastpath= Path.Combine("wwwroot/files", product.FileName);

                File.Delete(Lastpath);  
                product.FileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                string filePath = Path.Combine("wwwroot/files", product.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            if(img != null)
            {
                string Lastpath = Path.Combine("wwwroot/img", product.ImageName); 

                File.Delete(Lastpath);

                product.ImageName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(img.FileName);
                string imgPath = Path.Combine("wwwroot/img",product.ImageName);
                using (var stream = new FileStream(imgPath, FileMode.Create))
                {
                    img.CopyTo(stream);
                }


            }
            _context.Update(product);
            _context.SaveChanges();   
        }

        public ProductGroup Getgroup(int id)
        {
            return _context.ProductGroups.Find(id);
        }

        public List<SelectlistItem> GetGroupForProduct()
        {
            return _context.ProductGroups.Select(c => new SelectlistItem
            {
                Value = c.ProductGroupId.ToString(),
                Text = c.GroupName

            }).ToList();
        }

        public Product GetProductByid(int productId)
        {
            return _context.Products.Find(productId);
        }

        public Product GetproductForshow(int productid)
        {
            return _context.Products.Include(c => c.ProductGroup).SingleOrDefault(c => c.ProductId == productid);
        }

        public void SofteDeleteproduct(int productId)
        {
            var product = _context.Products.Find(productId);
            product.IsDelete=true;
            _context.SaveChanges();     
        }

        IEnumerable<Product> IproductServis.GetProductforadmin()
        {
            return (IEnumerable<Product>)_context.Products;
        }

        IEnumerable<ProductGroup> IproductServis.GetProductGroupsforadmin()
        {
            return (IEnumerable<ProductGroup>)_context.ProductGroups;
        }
    }
}
