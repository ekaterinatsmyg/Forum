using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using ORM.Configuration;
using Entities;

namespace ORM
{
    public class ForumModel: DbContext
    {
        public ForumModel(): 
            base("name = ForumModel")
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<RoleUser> RolesUser { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Theme> Themes { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new SectionConfiguration());
            modelBuilder.Configurations.Add(new ThemeConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            //modelBuilder.Entity<RoleUser>()
            //    .HasMany(e => e.Users)
            //    .WithRequired(e => e.RoleUser)
            //    .HasForeignKey(e => e.RoleUserId);

            //modelBuilder.Entity<Section>()
            //    .HasMany(e => e.Themes)
            //    .WithRequired(e => e.Section)
            //    .HasForeignKey(e => e.SectionId);

            //modelBuilder.Entity<Theme>()
            //    .HasMany(e => e.Messages)
            //    .WithRequired(e => e.Theme)
            //    .HasForeignKey(e => e.ThemeId);
               
        }

        }
}
