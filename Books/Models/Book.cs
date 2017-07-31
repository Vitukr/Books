using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }        
        public string Passage { get; set; }
        public int AuthorRefId { get; set; }
        [ForeignKey("AuthorRefId")]
        public virtual Author Author { get; set; }
    }
}
