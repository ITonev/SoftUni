using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new ProductShopContext())
            {
                var jsonString = File.ReadAllText(@"C:\Users\lolsh.PRETORIAN\OneDrive\Documents\GitHub Projects\SoftUni\C# DB\Entity Framework Core\JSON\Resources\ProductShop\categories-products.json");

                Console.WriteLine(GetUsersWithProducts(db));
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var product = JsonConvert.DeserializeObject<Product[]>(inputJson);
            context.Products.AddRange(product);
            var count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                .Where(c => c.Name != null);
            context.Categories.AddRange(categories);
            var count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);
            context.CategoryProducts.AddRange(categoriesProducts);
            var count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price,
                    seller = x.Seller.FirstName + " " + x.Seller.LastName
                })
                .OrderBy(x => x.price);

            var jsonExport = JsonConvert.SerializeObject(products, Formatting.Indented);

            return jsonExport;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(a => a.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                                    .Where(a => a.Buyer != null)
                                    .Select(p => new
                                    {
                                        name = p.Name,
                                        price = p.Price,
                                        buyerFirstName = p.Buyer.FirstName,
                                        buyerLastName = p.Buyer.LastName
                                    })
                                    .ToList()
                })
                .OrderBy(u => u.lastName)
                .ThenBy(u => u.firstName)
                .ToList();

            var jsonExport = JsonConvert.SerializeObject(users, Formatting.Indented);

            return jsonExport;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count(),
                    averagePrice = c.CategoryProducts.Average(a => a.Product.Price).ToString("f2"),
                    totalRevenue = c.CategoryProducts.Sum(a => a.Product.Price).ToString("f2")
                })
                .OrderByDescending(c => c.productsCount);

            var jsonExport = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return jsonExport;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var userCollection = context
                .Users
                .Where(x => x.ProductsSold.Any(a=>a.Buyer!=null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new
                    {
                        count = x.ProductsSold
                                .Where(e=>e.Buyer != null)
                                .Count(),
                        products = x.ProductsSold
                                    .Where(d=>d.Buyer != null)
                                    .Select(p => new
                                    {
                                        name = p.Name,
                                        price = p.Price
                                    })
                                    .ToList()
                    }
                })
                .OrderByDescending(x=>x.soldProducts.count)
                .ToList();

            var users = new
            {
                usersCount = userCollection.Count(),
                users = userCollection
            };

            var jsonExport = JsonConvert.SerializeObject(users, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            return jsonExport;
        }

    }
}