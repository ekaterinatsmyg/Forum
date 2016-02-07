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
    public class RoleRepository: IRoleRepository
    {
         private readonly DbContext context;

        public RoleRepository(DbContext _context)
        {
            this.context = _context;            
        }
        public IEnumerable<DalRole> GetAll()
        {
            return context.Set<Role>().Select(role => new DalRole()
            {
                Id = role.Id,
                RoleOfUser = role.RoleOfUser
            });
        }

        public DalRole GetById(int entityId)
        {
            var role = context.Set<Role>().Where(r => r.Id == entityId).FirstOrDefault();
            return new DalRole()
            {
                Id = role.Id,
                RoleOfUser = role.RoleOfUser
            };
        }

        public IEnumerable<DalRole> GetByListId(IEnumerable<int> entitiesId)
        {
            return context.Set<Role>().Where(role => entitiesId.Contains(role.Id))
                .Select(role => new DalRole()
                {
                    Id = role.Id,
                    RoleOfUser = role.RoleOfUser
                });

        }
      

        public void Create(DalRole entity)
        {
            var role = new Role()
            {
                Id = entity.Id,
                RoleOfUser = entity.RoleOfUser
            };
            context.Set<Role>().Add(role);
        }

        public void Delete(DalRole entity)
        {
            var role = context.Set<Role>().Where(r => r.Id == entity.Id).FirstOrDefault();
            if(role != null)
            {
                context.Set<Role>().Remove(role);
            }            
        }

        public void Update(DalRole entity)
        {
            var role = context.Set<Role>().Where(r => r.Id == entity.Id).FirstOrDefault();
            if (role != null)
            {
                role.RoleOfUser = entity.RoleOfUser;
            }
        }
    }
}
