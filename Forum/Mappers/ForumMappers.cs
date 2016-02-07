using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Forum.Models;
using BLL.Interface.Entities;

namespace Forum.Mappers
{
    public static class ForumMappers
    {
        public static UserEntity ToBllUser(this RegistrationViewModel model)
        {
            if (model != null)
            {
                return new UserEntity()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Surname = model.Surname,
                    Login = model.Login,
                    Password = model.Password,
                    Email = model.Email,
                    DateAdded = model.DateAdded,
                };
            }
            return null;
        }

        public static SignInViewModel ToModelUser(this UserEntity entity)
        {
            if (entity != null)
            {
                return new SignInViewModel()
                {
                    Login = entity.Login,
                    Password = entity.Password
                };
            }
            return null;
        }


        public static SectionEntity ToBllSection(this SectionViewModel model)
        {
            if (model != null)
            {
                return new SectionEntity()
                {
                    Id = model.Id,
                    Name = model.Name,
                    DateAdded = model.DateAdded
                };
            }
            return null;
        }

        public static SectionViewModel ToModelSection(this SectionEntity entity)
        {
            if (entity != null)
            {
                return new SectionViewModel()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    DateAdded = entity.DateAdded
                };
            }
            return null;
        }
        public static ThemeViewModel ToModelTheme(this ThemeEntity entity)
        {
            if (entity != null)
            {
                return new ThemeViewModel()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    DatePublication = entity.DatePublication,
                    CountViews = entity.CountViews,
                    CreatorId = entity.CreatorId,
                    SectionId = entity.SectionId,
                    Content = entity.Content
                };
            }
            return null;
        }
        public static ThemeEntity ToBllTheme(this ThemeViewModel model)
        {
            if (model != null)
            {
                return new ThemeEntity()
                {
                    Id = model.Id,
                    Name = model.Name,
                    DatePublication = model.DatePublication,
                    CountViews = model.CountViews,
                    CreatorId = model.CreatorId,
                    SectionId = model.SectionId,
                    Content = model.Content
                };
            }
            return null;
        }


        public static MessageViewModel ToModelMessage (this MessageEntity entity)
        {
            if (entity != null)
            {
                return new MessageViewModel()
                {
                    Id = entity.Id,
                    Content = entity.Content,
                    DatePublication = entity.DatePublication,
                    SenderId = entity.SenderId,
                    ThemeId = entity.ThemeId

                };
            }
            return null;
        }

        public static MessageEntity ToBllMessage(this MessageViewModel model)
        {
            if (model != null)
            {
                return new MessageEntity()
                {
                    Id = model.Id,
                    Content = model.Content,
                    DatePublication = model.DatePublication,
                    SenderId = model.SenderId,
                    ThemeId = model.ThemeId

                };
            }
            return null;
        }
    }
}