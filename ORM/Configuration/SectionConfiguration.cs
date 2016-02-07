using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ORM.Configuration
{
    public class SectionConfiguration: EntityTypeConfiguration<Section>
    {
        public SectionConfiguration()
        {
            HasMany(e => e.Themes).WithRequired(e => e.Section).HasForeignKey(e => e.SectionId);
            Property(p => p.DateAdded).HasColumnType("datetime2");
        }
    }
}
