using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using BLL.Interface.Entities;

namespace BLL.Mappers
{
    public static class SectionMappers
    {
        public static DalSection ToDalSection(this SectionEntity sectionEntity)
        {
            if (sectionEntity != null)
            {
                return new DalSection()
                {
                    Id = sectionEntity.Id,
                    Name = sectionEntity.Name,
                    DateAdded = sectionEntity.DateAdded
                };
            }
            return null;
        }

        public static SectionEntity ToBllSection(this DalSection dalSection)
        {
            if (dalSection != null)
            {
                return new SectionEntity()
                {
                    Id = dalSection.Id,
                    Name = dalSection.Name,
                    DateAdded = dalSection.DateAdded
                };
            }
            return null;
        }
    }
}
