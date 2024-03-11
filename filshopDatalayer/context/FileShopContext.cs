


using Filshopfil.DataLayer.entites.product;
using Filshopfil.DataLayer.entites.user;
using Filshopfil.DataLayer.order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filshopDatalayer.context
{
    public class FileShopContext : DbContext
    {
        public FileShopContext(DbContextOptions<FileShopContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProduct> UserProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            var cascadeFks = builder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFks)
                fk.DeleteBehavior = DeleteBehavior.Cascade;

            builder.Entity<Product>().HasQueryFilter(c => !c.IsDelete);
            base.OnModelCreating(builder);
        }
    }
}
