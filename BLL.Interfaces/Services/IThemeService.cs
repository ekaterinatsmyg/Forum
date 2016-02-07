using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IThemeService
    {
        ThemeEntity GetThemeEntityById(int id);
        IEnumerable<ThemeEntity> GetAllThemeEntities();
        IEnumerable<ThemeEntity> GetBySectionId(int sectionId);
        IEnumerable<ThemeEntity> SearchThemes (string searchString);
        void CreateTheme(ThemeEntity theme);
        void DeleteTheme(ThemeEntity theme);
        void UpdateTheme(ThemeEntity theme);
    }
}
