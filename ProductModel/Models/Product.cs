using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace ProductModel.Models
{
    public class Product
    {
        static int unicId = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public string URLImage { get; set; }

        public Product() { }
     
    }

    
}
