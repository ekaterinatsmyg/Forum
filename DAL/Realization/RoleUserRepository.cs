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
    public class RoleUserRepository: IRoleUserRepository
    {
         private readonly DbContext context;

        public RoleUserRepository(DbContext _context)
        {
            this.context = _context;            
        }
        public IEnumerable<DalRoleUser> GetAll()
        {
            return context.Set<RoleUser>().Select(role => new DalRoleUser()
            {
                Id = role.Id,
                RoleId = role.RoleId,  
                UserId = role.UserId
            });
        }

        public DalRoleUser GetById(int entityId)
        {
            var role = context.Set<RoleUser>().Where(r => r.Id == entityId).FirstOrDefault();
            return new DalRoleUser()
            {
                Id = role.Id,
                RoleId = role.RoleId,
                UserId = role.UserId
            };
        }
      

        public void Create(DalRoleUser entity)
        {
            var role = new RoleUser()
            {
                Id = entity.Id,
                RoleId = entity.RoleId,
                UserId = entity.UserId
            };
            context.Set<RoleUser>().Add(role);
        }
        public IEnumerable<DalRoleUser> GetByUserId(int userId)
        {
            return context.Set<RoleUser>().Where(role => role.UserId == userId).Select(role => new DalRoleUser()
            {
                Id = role.Id,
                RoleId = role.RoleId,
                UserId = role.UserId
            });
        }

        public void Delete(DalRoleUser entity)
        {
            var role = context.Set<RoleUser>().Where(r => r.Id == entity.Id).FirstOrDefault();
            if(role != null)
            {
                context.Set<RoleUser>().Remove(role);
            }            
        }

        public void Update(DalRoleUser entity)
        {
            var role = context.Set<RoleUser>().Where(r => r.Id == entity.Id).FirstOrDefault();
            if (role != null)
            {
                role.UserId = entity.UserId;
                role.RoleId = entity.RoleId;
            }
        }
    }
}
