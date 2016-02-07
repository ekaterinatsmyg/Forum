using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;
using Entities;

namespace DAL.Realization
{
    public class SectionRepository: ISectionRepository
    {
        private readonly DbContext context;

        public SectionRepository(DbContext _context)
        {
            this.context = _context;            
        }


        public IEnumerable<DalSection> GetAll()
        {
            return context.Set<Section>().Select(section => new DalSection() 
            {
                Id = section.Id,
                Name = section.Name,
                DateAdded = section.DateAdded
            });
        }

        public DalSection GetById(int entityId)
        {
            var section = context.Set<Section>().Where(s => s.Id == entityId).FirstOrDefault();
            return new DalSection()
            {
                Id = section.Id,
                Name = section.Name,
                DateAdded = section.DateAdded                
            };
        }

      

        public void Create(DalSection entity)
        {
            var section = new Section()
            {
                Id = entity.Id,
                Name = entity.Name,
                DateAdded = entity.DateAdded
            };
            context.Set<Section>().Add(section);
        }

        public void Delete(DalSection entity)
        {
            var section = context.Set<Section>().Where(s => s.Id == entity.Id).FirstOrDefault();
            if (section != null)
            {
                context.Set<Section>().Remove(section);
            }
        }

        public void Update(DalSection entity)
        {
            var section = context.Set<Section>().Where(s => s.Id == entity.Id).FirstOrDefault();
            if (section != null)
            {
                section.Name = entity.Name;
                section.DateAdded = entity.DateAdded;
            }
        }
    }
}
