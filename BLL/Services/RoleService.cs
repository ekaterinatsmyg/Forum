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
    public class RoleService: IRoleService
    {
        private readonly IUnitOfWork uow;
        private readonly IRoleRepository roleRepository;

        public RoleService(IUnitOfWork uow, IRoleRepository repository)
        {
            this.uow = uow;
            this.roleRepository = repository;
        }

        public RoleEntity GetRoleEntityById(int id)
        {
            return roleRepository.GetById(id).ToBllRole();
        }
        public IEnumerable<RoleEntity> GetByListId(IEnumerable<int> entitiesId)
        {
            return roleRepository.GetByListId(entitiesId).Select(role => role.ToBllRole());
        }
        public IEnumerable<RoleEntity> GetAllRoleEntities()
        {
            return roleRepository.GetAll().Select(role => role.ToBllRole());
        }

        public void CreateRole(RoleEntity role)
        {
            roleRepository.Create(role.ToDalRole());
            uow.Commit();
        }

        public void DeleteRole(RoleEntity role)
        {
            roleRepository.Delete(role.ToDalRole());
            uow.Commit();
        }

        public void UpdateRole(RoleEntity role)
        {
            roleRepository.Update(role.ToDalRole());
            uow.Commit();
        }
    }
}
