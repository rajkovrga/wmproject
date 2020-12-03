using System;
using System.Collections.Generic;
using System.Text;

namespace BlogModels.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ManufactureId { get; set; }
        public Manufacture Manufacture { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
