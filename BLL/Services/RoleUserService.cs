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
    public class RoleUserService : IRoleUserService
    {
        private readonly IUnitOfWork uow;
        private readonly IRoleUserRepository roleRepository;

         public RoleUserService(IUnitOfWork uow, IRoleUserRepository repository)
        {
            this.uow = uow;
            this.roleRepository = repository;
        }
       

        public RoleUserEntity GetRoleEntityById(int id)
        {
            return roleRepository.GetById(id).ToBllRoleUser();
        }

        public IEnumerable<RoleUserEntity> GetAllRoleEntities()
        {
            return roleRepository.GetAll().Select(roleUser => roleUser.ToBllRoleUser());
        }
        public IEnumerable<RoleUserEntity> GetByUserId(int userId)
        {
            return roleRepository.GetByUserId(userId).Select(roleUser => roleUser.ToBllRoleUser());
        }

        public void CreateRoleUser(RoleUserEntity roleUser)
        {
            roleRepository.Create(roleUser.ToDalRoleUser());
            uow.Commit();
        }

        public void DeleteRoleUser(RoleUserEntity roleUser)
        {
            roleRepository.Delete(roleUser.ToDalRoleUser());
            uow.Commit();
        }

        public void UpdateRoleUser(RoleUserEntity roleUser)
        {
            roleRepository.Update(roleUser.ToDalRoleUser());
            uow.Commit();
        }
    }
}
