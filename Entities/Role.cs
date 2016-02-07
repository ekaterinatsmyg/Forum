using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Entities
{
    public class Role
    {

        public int Id { get; set; }
        [Required]
        public string RoleOfUser { get; set; }
        public virtual ICollection<RoleUser> RolesUser { get;  set;}
    }
}
