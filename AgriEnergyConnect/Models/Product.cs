using System;
using System.ComponentModel.DataAnnotations;

namespace AgriEnergyConnect.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }

        public int? FarmerId { get; set; }
        public Farmer? Farmer { get; set; } = null!;
    }
}
