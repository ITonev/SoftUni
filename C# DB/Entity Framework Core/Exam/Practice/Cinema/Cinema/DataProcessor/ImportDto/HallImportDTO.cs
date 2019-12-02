using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.DataProcessor.ImportDto
{
    public class HallImportDTO
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Is4Dx")]
        public bool Is4Dx { get; set; }

        [JsonProperty("Is3D")]
        public bool Is3D { get; set; }

        [JsonProperty("Seats")]
        [Range(1, int.MaxValue)]
        public int SeatsCount { get; set; }
    }
}
