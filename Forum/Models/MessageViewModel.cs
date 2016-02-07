using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class MessageViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display (Name="Сообщение")]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatePublication { get; set; }
        public int SenderId { get; set; }
        public int ThemeId { get; set; }
    }
}