using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Services;
using DAL.Interface.DTO;
using BLL.Interface.Entities;
using DAL.Interface.Interfaces;
using BLL.Mappers;

namespace BLL.Services
{
    public class ThemeService : IThemeService
    {
        private readonly IUnitOfWork uow;
        private readonly IThemeRepository themeRepository;

        public ThemeService(IUnitOfWork uow, IThemeRepository repository)
        {
            this.uow = uow;
            this.themeRepository = repository;
        }

        public ThemeEntity GetThemeEntityById(int id)
        {
            return themeRepository.GetById(id).ToBllTheme();
        }

        public IEnumerable<ThemeEntity> GetAllThemeEntities()
        {
            return themeRepository.GetAll().Select(theme => theme.ToBllTheme());
        }
        public IEnumerable<ThemeEntity> SearchThemes (string searchString)
        {
            return themeRepository.Search(searchString).Select(theme => theme.ToBllTheme());
        }
        public IEnumerable<ThemeEntity> GetBySectionId(int sectionId)
        {
            return themeRepository.GetBySectionId(sectionId).Select(theme => theme.ToBllTheme());
        }

        public void CreateTheme(ThemeEntity theme)
        {
            themeRepository.Create(theme.ToDalTheme());
            uow.Commit();
        }

        public void DeleteTheme(ThemeEntity theme)
        {
            themeRepository.Delete(theme.ToDalTheme());
            uow.Commit();
        }

        public void UpdateTheme(ThemeEntity theme)
        {
            themeRepository.Update(theme.ToDalTheme());
            uow.Commit();
        }
    }
}
