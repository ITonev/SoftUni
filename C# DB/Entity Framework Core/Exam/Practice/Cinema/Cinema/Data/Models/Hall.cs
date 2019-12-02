using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.Data.Models
{
   public class Hall
    {
        public int Id { get; set; }

        [MinLength(3), MaxLength(20), Required]
        public string Name { get; set; }

        public bool Is4Dx { get; set; }

        public bool Is3D { get; set; }

        public ICollection<Projection> Projections { get; set; } = new HashSet<Projection>();

        public ICollection<Seat> Seats { get; set; } = new HashSet<Seat>();
    }
}
