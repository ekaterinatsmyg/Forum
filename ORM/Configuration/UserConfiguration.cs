using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ORM.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasMany(e => e.RolesUser).WithRequired(e => e.User).HasForeignKey(e => e.UserId);
            HasMany(e => e.Themes).WithRequired(e => e.Creator).HasForeignKey(e => e.CreatorId);
            HasMany(e => e.Messages).WithRequired(e => e.Sender).HasForeignKey(e => e.SenderId);
            Property(p => p.DateAdded).HasColumnType("datetime2");           
            Property(p => p.LastUpdateDate).IsOptional().HasColumnType("datetime2");
        }
    }
}
