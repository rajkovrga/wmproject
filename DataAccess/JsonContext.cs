using BlogModels.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataAccess
{
    public class JsonContext
    {

        public JsonContext()
        {
            using (var reader = new StreamReader(@"../DataAccess/posts.json"))
            {
                var r = reader.ReadToEnd();
                Posts = JsonConvert.DeserializeObject<List<Post>>(r);
            }
            using (var reader = new StreamReader(@"../DataAccess/categories.json"))
            {
                var r = reader.ReadToEnd();
                Categories = JsonConvert.DeserializeObject<List<Category>>(r);
            }
            using (var reader = new StreamReader(@"../DataAccess/manufactures.json"))
            {
                var r = reader.ReadToEnd();
                Manufactures = JsonConvert.DeserializeObject<List<Manufacture>>(r);
            }
            using (var reader = new StreamReader(@"../DataAccess/suppliers.json"))
            {
                var r = reader.ReadToEnd();
                Suppliers = JsonConvert.DeserializeObject<List<Supplier>>(r);
            }
        }

        public List<Category> Categories { get; set; }
        public List<Manufacture> Manufactures { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public List<Post> Posts { get; set; }
    }
}
