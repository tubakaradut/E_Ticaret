using DataAccess.Entity;
using DataAccess.Map;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
 public   class ProjeContext:DbContext
    {
        public ProjeContext()
        {
            Database.Connection.ConnectionString = "server=DESKTOP-PAHPBA7;Database=E_TicaretDB;uid=sa;pwd=123456";
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category>Categories  { get; set; }
        public DbSet<SubCategory>SubCategories  { get; set; }
        public DbSet<Supplier>Suppliers  { get; set; }
        public DbSet<AppUser>AppUsers  { get; set; }
        public DbSet<Order> Orders  { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new SupplierMap());
            modelBuilder.Configurations.Add(new SubCategoryMap());
            modelBuilder.Configurations.Add(new AppUserMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
