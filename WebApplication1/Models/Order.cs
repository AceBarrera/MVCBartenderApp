using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public MenuItem MenuItem { get; set; }
        public bool Complete { get; set; }
    }
}