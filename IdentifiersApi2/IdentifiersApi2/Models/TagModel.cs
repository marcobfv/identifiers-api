
using System;

namespace IdentifiersApi2.Models
{
    public class TagModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}