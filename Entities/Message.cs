using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities
{
   
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DatePublication { get; set; }
        public int SenderId { get; set; }
        public int ThemeId { get; set; }
        public virtual Theme Theme { get; set; }
        public virtual User Sender { get; set; }

     }
}
