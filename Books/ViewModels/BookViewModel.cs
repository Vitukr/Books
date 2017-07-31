using Books.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Books.ViewModels
{
    public class BookViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        public string Passage { get; set; }
        [Required]
        [Display(Name = "Author")]
        public int AuthorRefId { get; set; }
        public Author Author { get; set; }
    }
}
