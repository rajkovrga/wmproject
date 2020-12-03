using BlogModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Dto
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public Manufacture Manufacture { get; set; }
        public Supplier Supplier { get; set; }
    }
}
