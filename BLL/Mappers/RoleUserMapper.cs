using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using BLL.Interface.Entities;

namespace BLL.Mappers
{
    public static class RoleUserMapper
    {
        public static DalRoleUser ToDalRoleUser(this RoleUserEntity roleEntity)
        {
            if (roleEntity != null)
            {
                return new DalRoleUser()
                {
                    Id = roleEntity.Id,
                    UserId = roleEntity.UserId,
                    RoleId = roleEntity.RoleId
                };
            }
            return null;
        }

        public static RoleUserEntity ToBllRoleUser(this DalRoleUser dalRoleUser)
        {
            if (dalRoleUser != null)
            {
                return new RoleUserEntity()
                {
                    Id = dalRoleUser.Id,
                    UserId = dalRoleUser.UserId,
                    RoleId = dalRoleUser.RoleId
                };
            }
            return null;
        }
    }
}
