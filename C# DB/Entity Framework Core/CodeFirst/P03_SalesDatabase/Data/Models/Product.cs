using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P03_SalesDatabase.Data.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public string Description { get; set; } = "No Description";

        public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();

    }
}
