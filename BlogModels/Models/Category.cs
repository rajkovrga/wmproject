using System;
using System.Collections.Generic;
using System.Text;

namespace BlogModels.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();

    }
}
