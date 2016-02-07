using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities
{
  
    public class Section
    {
        public Section()
        {
            Themes = new HashSet<Theme>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public virtual ICollection<Theme> Themes { get; set; }
    }
}
