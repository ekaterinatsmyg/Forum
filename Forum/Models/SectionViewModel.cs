using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class SectionViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Название секции")]
        [MaxLength(35, ErrorMessage = "Название секции не может содержать больше, чем 35 символом")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
    }
}