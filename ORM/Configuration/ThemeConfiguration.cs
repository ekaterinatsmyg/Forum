using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ORM.Configuration
{
    public class ThemeConfiguration: EntityTypeConfiguration<Theme>
    {
        public ThemeConfiguration()
        {
            HasMany(e => e.Messages).WithRequired(e => e.Theme).HasForeignKey(e => e.ThemeId).WillCascadeOnDelete(false);
            Property(p => p.DatePublication).HasColumnType("datetime2");
        }
    }
}
