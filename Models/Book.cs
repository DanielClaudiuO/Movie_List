using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Book
    {
        public Guid ID { get; set;}

        public string Name { get; set; }

        public string Author { get; set; }

        public int firstEdition { get; set; }
    }
}
