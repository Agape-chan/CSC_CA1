using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Category { get; set; }
        [Required]
        [Range(0, 100)]
        public decimal Price { get; set; }
    }
}