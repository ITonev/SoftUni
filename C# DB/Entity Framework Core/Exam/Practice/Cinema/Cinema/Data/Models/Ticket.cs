using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.Data.Models
{
   public class Ticket
    {
        public int Id { get; set; }

        [Range(0.01, double.MaxValue), Required]
        public decimal Price { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required]
        public int ProjectionId { get; set; }
        public Projection Projection { get; set; }
    }
}
