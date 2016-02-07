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
    public class SectionService: ISectionService
    {
        private readonly IUnitOfWork uow;
        private readonly ISectionRepository sectionRepository;

        public SectionService(IUnitOfWork uow, ISectionRepository repository)
        {
            this.uow = uow;
            this.sectionRepository = repository;
        }


        public SectionEntity GetSectionEntityById(int id)
        {
            return sectionRepository.GetById(id).ToBllSection();
        }

        public IEnumerable<SectionEntity> GetAllSectionEntities()
        {
            return sectionRepository.GetAll().Select(section => section.ToBllSection());
        }

        public void CreateSection(SectionEntity section)
        {
            sectionRepository.Create(section.ToDalSection());
            uow.Commit();
        }

        public void DeleteSection(SectionEntity section)
        {
            sectionRepository.Delete(section.ToDalSection());
            uow.Commit();
        }

        public void UpdateSection(SectionEntity section)
        {
            sectionRepository.Update(section.ToDalSection());
            uow.Commit();
        }
    }
}
