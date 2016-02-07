using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ORM.Configuration
{
    public class RoleUserConfiguration: EntityTypeConfiguration<RoleUser>
    {
        public RoleUserConfiguration()
        {
            
        }
    }
}
