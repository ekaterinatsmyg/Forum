using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.Threading.Tasks;
using Entities;

namespace ORM.Configuration
{
    public class RoleConfiguration: EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            HasMany(e => e.RolesUser).WithRequired(e => e.Role).HasForeignKey(e => e.RoleId);
        }
    }
}
