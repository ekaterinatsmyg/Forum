using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class SearchViewModel
    {
        [MaxLength(35, ErrorMessage = "Слишком много символов")]
        public string SearchString { get; set; }
    }
}