using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using BLL.Interface.Entities;

namespace BLL.Mappers
{
    public static class RoleEntityMapper
    {
        public static DalRole ToDalRole(this RoleEntity roleEntity)
        {
            if (roleEntity != null)
            {
                return new DalRole()
                {
                    Id = roleEntity.Id,
                    RoleOfUser = roleEntity.RoleOfUser
                };
            }
            return null;
        }

        public static RoleEntity ToBllRole(this DalRole dalRole)
        {
            if (dalRole != null)
            {
                return new RoleEntity()
                {
                    Id = dalRole.Id,
                    RoleOfUser = dalRole.RoleOfUser
                };
            } 
            return null;
        }
    }
}
