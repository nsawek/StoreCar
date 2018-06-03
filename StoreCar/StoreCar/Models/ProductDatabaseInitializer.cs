using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StoreCar.Models
{
    public class ProductDatabaseInitializer : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetProducts().ForEach(p => context.Products.Add(p));
        }

        private static List<Category> GetCategories()
        {
            var categories = new List<Category> {
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Audi"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Ford"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "BMW"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "VW"
                },
                new Category
                {
                    CategoryID = 5,
                    CategoryName = "Skoda"
                },
            };

            return categories;
        }

        private static List<Product> GetProducts()
        {
            var products = new List<Product> {
             
                new Product
                {
                    ProductID = 1,
                    ProductName = "Audi A2",
                    Description = "W sam raz na miasto.",
                    ImagePath="a2.jpg",
                    UnitPrice = 8600,
                     CategoryID = 1
               },
                
                
                new Product
                {
                    ProductID = 3,
                    ProductName = "Ford Focus",
                    Description = "W sam raz na miasto",
                    ImagePath="f2.jpg",
                    UnitPrice = 78500 ,
                    CategoryID = 2
                },
               
                new Product
                {
                    ProductID = 6,
                    ProductName = "BMW-X3",
                    Description = "W sam raz na miasto",
                    ImagePath="bmw1.jpg",
                    UnitPrice = 65000,
                    CategoryID = 3
                },
                new Product
                {
                    ProductID = 8,
                    ProductName = "VW Passat B6",
                    Description = "W sam raz na miasto",
                    ImagePath="vw1.jpg",
                    UnitPrice = 45000,
                    CategoryID = 4
                },
                new Product
                {
                    ProductID = 55,
                    ProductName = "Skoda Octavia",
                    Description = "W sam raz na miasto",
                    ImagePath="s1.jpg",
                    UnitPrice = 62000,
                    CategoryID = 5
                }
            };

            return products;
        }
    }
}