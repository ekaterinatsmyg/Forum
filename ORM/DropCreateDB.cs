using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace ORM
{
    public class DropCreateDB : DropCreateDatabaseIfModelChanges<ForumModel>
    {
        protected override void Seed(ForumModel context)
        {
            base.Seed(context);

            context.Users.Add(new User()
            {
                Id =1,
                Name = "Anton",
                Surname = "Ivanov",
                Login = "admin",
                Password = Crypto.HashPassword("123456"),
                Email = "antonivanov@gmail.com",
                IsBlocked = false

            });
            context.Users.Add(new User()
            {
                Id = 2,
                Name = "Alexey",
                Surname = "Dostoevsky",
                Login = "dostoevsky",
                Password = Crypto.HashPassword("123456"),
                Email = "alexeydostoevsky@gmail.com",
                IsBlocked = false

            });
            context.Roles.Add(new Role()
            {
                Id = 1,
                RoleOfUser = "admin"

            });
            context.Roles.Add(new Role()
            {
                Id = 2,
                RoleOfUser = "simple user"

            });
            context.RolesUser.Add(new RoleUser()
            {
                Id = 1,
                UserId = 1,
                RoleId = 1
            });
            context.RolesUser.Add(new RoleUser()
            {
                Id = 2,
                UserId = 2,
                RoleId = 2
            });

            context.Sections.Add(new Section()
                {
                    Id = 1,
                    Name = "C#",
                    DateAdded = DateTime.Now
                });

            context.Themes.Add(new Theme()
                {
                    Id = 1,
                    CreatorId = 1,
                    SectionId = 1,
                    Name = "Value type vs Reference type",
                    Content = "В чем суть отличия между ссылочными и значимыми типами данных в C#?",
                    DatePublication = DateTime.Now,
                    CountViews = 0
                });
            context.Messages.Add(new Message()
            {
                Id = 1,
                SenderId = 2,
                ThemeId = 1,
                DatePublication = DateTime.Now,
                Content = "Вот ссылочка https://habrahabr.ru/sandbox/68552/"
            });
            context.SaveChanges();
        }
    }
}
