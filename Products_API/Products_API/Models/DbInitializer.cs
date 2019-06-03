using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products_API.Models
{
    public class DbInitializer
    {
        public static void Initialize(LibraryContext context)
        {
            // context.Database.EnsureDeleted();

            // create db if not exist
            context.Database.EnsureCreated();

            // check if the table is empty
            if (!context.Products.Any())
            {
                // if empty make an entry
                Product currProduct, currProduct2;

                currProduct = new Product()
                {
                    Name = "Laptop",
                    Categorie = "Electronics",
                    Price = 1500
                };

                currProduct2 = new Product()
                {
                    Name = "Smartphone",
                    Categorie = "Electronics",
                    Price = 1100
                };

                context.Products.Add(currProduct);
                context.Products.Add(currProduct2);
                context.SaveChanges();
            }
        }
    }
}
