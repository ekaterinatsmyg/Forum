using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    
    public class User
    {
        public User()
        {
            RolesUser = new HashSet<RoleUser>();
            Themes = new HashSet<Theme>();
            Messages = new HashSet<Message>();
        }
        public  int Id { get; set; }       
        public string Name { get; set; }        
        public  string  Surname { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public  string Password { get; set; }
        [Required]
        public  string Email { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsBlocked { get; set; }
        public virtual ICollection<RoleUser> RolesUser { get; set; }
        public virtual ICollection<Theme> Themes { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public DateTime? LastUpdateDate { get; set; }

    
    }
}
