namespace DataAccess.Migrations
{
    using DataAccess.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.Context.ProjeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataAccess.Context.ProjeContext context)
        {

            //todo: her bir ürüne ait görseller için UI katmanı içerisinde Content/product isminde klasör oluşturulup içerisine varsayılan görseller eklenecek.


            //Categories
            List<Category> categories = new List<Category>()
            {
                new Category{ID=Guid.NewGuid(),CategoryName="Teknoloji",Description="Teknolojik ürünler"},
                new Category{ID=Guid.NewGuid(),CategoryName="Giyim",Description="Yazlık kışlık son moda giyim ürünleri"},
                new Category{ID=Guid.NewGuid(),CategoryName="Kitap",Description="Tarih, Edebiyat, Kişisel Gelişim vs..."},
                new Category{ID=Guid.NewGuid(),CategoryName="Kozmetik",Description="Sağlık ürünleri"}
            };
            if (!context.Categories.Any())
            {
                foreach (var category in categories)
                {
                    context.Categories.Add(category);
                    context.SaveChanges();
                }
            }

            //SubCategories
            List<SubCategory> subCategories = new List<SubCategory>()
            {
                new SubCategory{
                    ID=Guid.NewGuid(),
                    SubCategoryName="Bilgisayar",
                    CategoryId=categories.FirstOrDefault(x=>x.CategoryName=="Teknoloji").ID,

                },
                new SubCategory{
                    ID=Guid.NewGuid(),
                    SubCategoryName="Televizyon",
                    CategoryId=categories.FirstOrDefault(x=>x.CategoryName=="Teknoloji").ID,

                },
                new SubCategory{
                    ID=Guid.NewGuid(),
                    SubCategoryName="Telefon",
                    CategoryId=categories.FirstOrDefault(x=>x.CategoryName=="Teknoloji").ID,

                },
                new SubCategory{
                    ID=Guid.NewGuid(),
                    SubCategoryName="Tshirt",
                    CategoryId=categories.FirstOrDefault(x=>x.CategoryName=="Giyim").ID,

                },
                new SubCategory{
                    ID=Guid.NewGuid(),
                    SubCategoryName="Ayakkabı",
                    CategoryId=categories.FirstOrDefault(x=>x.CategoryName=="Giyim").ID,

                },
                new SubCategory{
                    ID=Guid.NewGuid(),
                    SubCategoryName="Jean",
                    CategoryId=categories.FirstOrDefault(x=>x.CategoryName=="Giyim").ID,

                },
                new SubCategory{
                    ID=Guid.NewGuid(),
                    SubCategoryName="Roman",
                    CategoryId=categories.FirstOrDefault(x=>x.CategoryName=="Kitap").ID,

                },
                new SubCategory{
                    ID=Guid.NewGuid(),
                    SubCategoryName="Edebiyat",
                    CategoryId=categories.FirstOrDefault(x=>x.CategoryName=="Kitap").ID,

                },
                new SubCategory{
                    ID=Guid.NewGuid(),
                    SubCategoryName="Felsefe",
                    CategoryId=categories.FirstOrDefault(x=>x.CategoryName=="Kitap").ID,

                },
                new SubCategory{
                    ID=Guid.NewGuid(),
                    SubCategoryName="Parfüm",
                    CategoryId=categories.FirstOrDefault(x=>x.CategoryName=="Kozmetik").ID,

                },
                new SubCategory{
                    ID=Guid.NewGuid(),
                    SubCategoryName="Eyeliner",
                    CategoryId=categories.FirstOrDefault(x=>x.CategoryName=="Kozmetik").ID,

                },
                new SubCategory{
                    ID=Guid.NewGuid(),
                    SubCategoryName="Ruj",
                    CategoryId=categories.FirstOrDefault(x=>x.CategoryName=="Kozmetik").ID,

                }
            };

            if (!context.SubCategories.Any())
            {
                foreach (var subCategory in subCategories)
                {
                    context.SubCategories.Add(subCategory);
                    context.SaveChanges();
                }
            }

            List<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier{ID=Guid.NewGuid(),CompanyName="Özkardeşler",Address="İstanbul"},
                new Supplier{ID=Guid.NewGuid(),CompanyName="Demir Lojistik",Address="İstanbul"},
                new Supplier{ID=Guid.NewGuid(),CompanyName="Kuzey Yeli",Address="İstanbul"},
                new Supplier{ID=Guid.NewGuid(),CompanyName="Ikura ve Chang Kardeşler Tedarik",Address="İstanbul"},
            };

            //Suppliers
            if (!context.Suppliers.Any())
            {
                foreach (var supplier in suppliers)
                {
                    context.Suppliers.Add(supplier);
                    context.SaveChanges();
                }
            }

            //Products
            List<Product> products = new List<Product>()
            {
                new Product{
                    ID=Guid.NewGuid(),
                    ProductName="MSI",
                    SubCategoryId=subCategories.FirstOrDefault(x=>x.SubCategoryName=="Bilgisayar").ID,
                    SupplierId=suppliers.FirstOrDefault(x=>x.CompanyName=="Özkardeşler").ID,
                    UnitPrice=15000,
                    UnitsInStock=50,
                    ProductImagePath="/Content/product/msi_computer.png"},
                 new Product{
                     ID=Guid.NewGuid(),
                     ProductName="Arçelik LED",
                     SubCategoryId=subCategories.FirstOrDefault(x=>x.SubCategoryName=="Televizyon").ID,
                     SupplierId=suppliers.FirstOrDefault(x=>x.CompanyName=="Demir Lojistik").ID,
                     UnitPrice=20000,
                     UnitsInStock=150,
                     ProductImagePath="/Content/product/arcelik_led.png"},
                 new Product{
                     ID=Guid.NewGuid(),
                     ProductName="IPhone 13 Pro Max",
                     SubCategoryId=subCategories.FirstOrDefault(x=>x.SubCategoryName=="Telefon").ID,
                     SupplierId=suppliers.FirstOrDefault(x=>x.CompanyName=="Kuzey Yeli").ID,
                     UnitPrice=30000,
                     UnitsInStock=150,
                     ProductImagePath="/Content/product/iphone_13.png"}
            };
            if (!context.Products.Any())
            {
                foreach (var product in products)
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }
            }

            ////AppUser
            //List<AppUser> userList = new List<AppUser>()
            //{
            //    new AppUser{ID=Guid.NewGuid(),Username="admin",Password="1234",Email="admin@admin.com"}
            //};

            //foreach (var user in userList)
            //{
            //    context.AppUsers.Add(user);
            //    context.SaveChanges();
            //}
        }
    }
}
