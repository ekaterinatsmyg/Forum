using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class ThemeViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display(Name = "Тема")]
        public string Name { get; set; }
        [Display(Name = "Вопрос")]
        [DataType(DataType.Date)]
        public DateTime DatePublication { get; set; }
        public long CountViews { get; set; }
        public string Content { get; set; }
        public int CreatorId { get; set; }
        public int SectionId { get; set; }
    }
}