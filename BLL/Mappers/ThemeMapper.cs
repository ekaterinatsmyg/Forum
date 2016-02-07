using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using BLL.Interface.Entities;

namespace BLL.Mappers
{
    public static class ThemeMapper
    {
        public static DalTheme ToDalTheme(this ThemeEntity themeEntity)
        {
            if (themeEntity != null)
            {
                return new DalTheme()
                {
                    Id = themeEntity.Id,
                    Name = themeEntity.Name,
                    DatePublication = themeEntity.DatePublication,
                    CountViews = themeEntity.CountViews,
                    CreatorId = themeEntity.CreatorId,
                    SectionId = themeEntity.SectionId,
                    Content = themeEntity.Content
                };
            }
            return null;
        }

        public static ThemeEntity ToBllTheme(this DalTheme dalTheme)
        {
            if (dalTheme != null)
            {
                return new ThemeEntity()
                {
                Id = dalTheme.Id,
                Name = dalTheme.Name,
                DatePublication = dalTheme.DatePublication,
                CountViews = dalTheme.CountViews,
                CreatorId = dalTheme.CreatorId,
                SectionId = dalTheme.SectionId,
                Content = dalTheme.Content
                };
            }
            return null;
        }
    }
}
