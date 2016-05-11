using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReactLearning.Models
{
    public class Comment
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public string Author { set; get; }
        public string Email { set; get; }
        public string Telephone { set; get; }
        public string Content { set; get; }
        public int ParentId { set; get; }
    }
}