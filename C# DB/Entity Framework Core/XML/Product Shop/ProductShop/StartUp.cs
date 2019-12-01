using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //var users = File.ReadAllText(@"./../../../Datasets/users.xml");
            //var categories = File.ReadAllText(@"./../../../Datasets/categories.xml");
            //var products = File.ReadAllText(@"./../../../Datasets/products.xml");
            //var categoriesProducts = File.ReadAllText(@"./../../../Datasets/categories-products.xml");

            using (var db = new ProductShopContext())
            {
                Console.WriteLine(GetCategoriesByProductsCount(db));
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<ImportUsersDTO>), new XmlRootAttribute("Users"));

            var usersDTO = (List<ImportUsersDTO>)serializer.Deserialize(new StringReader(inputXml));

            var users = new List<User>();

            foreach (var user in usersDTO)
            {
                var userToAdd = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Age = user.Age
                };

                users.Add(userToAdd);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ImportProductsDTO>), new XmlRootAttribute("Products"));

            var productsDTO = (List<ImportProductsDTO>)xmlSerializer.Deserialize(new StringReader(inputXml));

            var products = new List<Product>();

            foreach (var item in productsDTO)
            {
                var prod = new Product
                {
                    Name = item.Name,
                    Price = item.Price,
                    SellerId = item.SellerId,
                    BuyerId = item.BuyerId
                };

                products.Add(prod);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";

        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryDTO[]), new XmlRootAttribute("Categories"));

            var categoriesDTO = (ImportCategoryDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categories = new List<Category>();

            foreach (var item in categoriesDTO.Where(x => x.Name != null))
            {
                var category = new Category
                {
                    Name = item.Name
                };

                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDTO[]), new XmlRootAttribute("CategoryProducts"));

            var categoriesDTO = (ImportCategoryProductDTO[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categoryProducts = new List<CategoryProduct>();

            var products = context.Products.ToList();

            var categories = context.Categories.ToList();


            foreach (var item in categoriesDTO)
            {
                if (categories.Any(x => x.Id == item.CategoryId)
                    && products.Any(x => x.Id == item.ProductId))
                {
                    var catProd = new CategoryProduct
                    {
                        CategoryId = item.CategoryId,
                        ProductId = item.ProductId
                    };

                    categoryProducts.Add(catProd);
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();


            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new ExportProductsInRangeDTO
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = $"{x.Buyer.FirstName} {x.Buyer.LastName}"
                })
                .OrderBy(x => x.Price)
                .Take(10)
                .ToList();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ExportProductsInRangeDTO>), new XmlRootAttribute("Products"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            var sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(x => x.ProductsSold.Any(z => z.Buyer != null))
                .Select(x => new UsersWithSoldProductsDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,

                    SoldProducts = x.ProductsSold.Select(y => new ExportSoldProductsDTO
                    {
                        Name = y.Name,
                        Price = y.Price,
                    })
                        .ToList()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToList();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<UsersWithSoldProductsDTO>), new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            var sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new ExportCategoriesByProductDTO
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count(),
                    AveragePrice = c.CategoryProducts.Average(x => x.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(x => x.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToList();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ExportCategoriesByProductDTO>), new XmlRootAttribute("Categories"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            var sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}