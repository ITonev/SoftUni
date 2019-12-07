using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeesDTO
    {
        [MinLength(3), MaxLength(40), Required, RegularExpression(@"[A-Za-z0-9]+")]
        public string Username { get; set; }

        [EmailAddress, Required]
        public string Email { get; set; }

        [RegularExpression(@"\d{3}-\d{3}-\d{4}"), Required]
        public string Phone { get; set; }

        public List<int> Tasks { get; set; } = new List<int>();
    }
}
