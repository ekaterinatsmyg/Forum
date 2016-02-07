using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities
{
 
    public class Theme
    {
        public Theme()
        {
            Messages = new HashSet<Message>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime DatePublication { get; set; }
        public long CountViews { get; set; }
        public int CreatorId { get; set; }
        public int SectionId { get; set; }
        public virtual Section Section { get; set; }
        public virtual User Creator { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
