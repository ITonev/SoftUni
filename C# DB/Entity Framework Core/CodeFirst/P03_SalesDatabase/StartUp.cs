using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data;
using P03_SalesDatabase.Data.Models;
using System;

namespace P03_SalesDatabase
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new SalesContext())
            {
                db.Database.Migrate();

                db.Sales.Add(new Sale
                {
                    Customer = new Customer
                    {
                        Name = "Ivan",
                        Email = "goshko@abv.bg",
                        CreditCardNumber = "5487569745511786"
                    },

                    Product = new Product
                    {
                        Name = "Govejdo",
                        Quantity = 12,
                        Price = 6,
                        Description = "Very Good govejdo"
                    },

                    Store = new Store 
                    {
                        Name = "Mesarnicata na Gosho",
                    }
                });

                db.SaveChanges();
            }
        }
    }
}
