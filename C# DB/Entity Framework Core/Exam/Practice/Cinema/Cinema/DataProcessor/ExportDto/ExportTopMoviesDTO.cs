﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.DataProcessor.ExportDto
{
    public class ExportTopMoviesDTO
    {
        public string MovieName { get; set; }

        public string Rating { get; set; }

        public string TotalIncomes { get; set; }

        public List<CustomerDTO> Customers { get; set; }
    }
}
