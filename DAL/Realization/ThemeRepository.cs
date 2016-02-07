using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;
using Entities;

namespace DAL.Realization
{
    public class ThemeRepository: IThemeRepository
    {
        private readonly DbContext context;

        public ThemeRepository(DbContext _context)
        {
            this.context = _context;            
        }
        public IEnumerable<DalTheme> GetAll()
        {
            return context.Set<Theme>().Select(theme => new DalTheme()
            {
                Id = theme.Id,
                Name = theme.Name,
                DatePublication = theme.DatePublication,
                CountViews = theme.CountViews,
                CreatorId = theme.CreatorId,
                SectionId = theme.SectionId,
                Content = theme.Content
            });
        }

        public DalTheme GetById(int entityId)
        {
            var theme = context.Set<Theme>().Where(th => th.Id == entityId).FirstOrDefault();
            return new DalTheme()
            {
                Id = theme.Id,
                Name = theme.Name,
                DatePublication = theme.DatePublication,
                CountViews = theme.CountViews,
                CreatorId = theme.CreatorId,
                SectionId = theme.SectionId,
                Content = theme.Content
                
            };
        }

        public IEnumerable<DalTheme> GetBySectionId(int sectionId)
        {
           return context.Set<Theme>().Where(theme => theme.SectionId == sectionId).Select(theme => new DalTheme()
            {
                Id = theme.Id,
                Name = theme.Name,
                DatePublication = theme.DatePublication,
                CountViews = theme.CountViews,
                CreatorId = theme.CreatorId,
                SectionId = theme.SectionId,
                Content = theme.Content
            });
        }

    
        public  IEnumerable<DalTheme> Search(string searchString)
        {
            var result = context.Set<Theme>().Where(theme => theme.Name.Contains(searchString)).Select(theme => new DalTheme()
            {
                Id = theme.Id,
                Name = theme.Name,
                DatePublication = theme.DatePublication,
                CountViews = theme.CountViews,
                CreatorId = theme.CreatorId,
                SectionId = theme.SectionId,
                Content = theme.Content
            });
            return result;
        }
        public void Create(DalTheme entity)
        {
            var theme = new Theme()
            {
                Id = entity.Id,
                Name = entity.Name,
                DatePublication = entity.DatePublication,
                CountViews = entity.CountViews,
                CreatorId = entity.CreatorId,
                SectionId = entity.SectionId,
                Content = entity.Content
               
            };
            context.Set<Theme>().Add(theme);
        }

        public void Delete(DalTheme entity)
        {
            var theme = context.Set<Theme>().Where(th => th.Id == entity.Id).FirstOrDefault();
            if (theme != null)
            {
                context.Set<Theme>().Remove(theme);
            }
            
        }

        public void Update(DalTheme entity)
        {
            var theme = context.Set<Theme>().Where(th => th.Id == entity.Id).FirstOrDefault();
            if (theme != null)
            {
                theme.Name = entity.Name;
                theme.DatePublication = entity.DatePublication;
                theme.CountViews = entity.CountViews;
                theme.CreatorId = entity.CreatorId;
                theme.SectionId = entity.SectionId;
                theme.Content = entity.Content;
            }
        }
    }
}
