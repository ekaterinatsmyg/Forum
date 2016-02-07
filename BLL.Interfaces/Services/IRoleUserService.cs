using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IRoleUserService
    {
        RoleUserEntity GetRoleEntityById(int id);
        IEnumerable<RoleUserEntity> GetAllRoleEntities();
        IEnumerable<RoleUserEntity> GetByUserId(int userId);
        void CreateRoleUser(RoleUserEntity roleUser);
        void DeleteRoleUser(RoleUserEntity roleUser);
        void UpdateRoleUser(RoleUserEntity roleUser);
        
    }
}
