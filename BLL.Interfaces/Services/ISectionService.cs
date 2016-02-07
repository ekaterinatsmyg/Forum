using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface ISectionService
    {
        SectionEntity GetSectionEntityById(int id);
        IEnumerable<SectionEntity> GetAllSectionEntities();
        void CreateSection(SectionEntity section);
        void DeleteSection(SectionEntity section);
        void UpdateSection(SectionEntity section);
        
    }
}
