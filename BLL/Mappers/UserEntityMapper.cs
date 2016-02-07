using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using BLL.Interface.Entities;

namespace BLL.Mappers
{
    public static class UserEntityMapper
    {
        public static DalUser ToDalUser(this UserEntity userEntity)
        {
            if (userEntity != null)
            {
                return new DalUser()
                {
                    Id = userEntity.Id,
                    Name = userEntity.Name,
                    Surname = userEntity.Surname,                   
                    Login = userEntity.Login,
                    Password = userEntity.Password,
                    Email = userEntity.Email,
                    DateAdded = userEntity.DateAdded,
                    LastUpdateDate = userEntity.LastUpdateDate,
                    IsBlocked = userEntity.IsBlocked
                };
            }
            return null;
        }

        public static UserEntity ToBllUser(this DalUser dalUser)
        {
            if (dalUser != null)
            {
                return new UserEntity()
                {
                    Id = dalUser.Id,
                    Name = dalUser.Name,
                    Surname = dalUser.Surname,
                    Login = dalUser.Login,
                    Password = dalUser.Password,
                    Email = dalUser.Email,
                    DateAdded = dalUser.DateAdded,
                    LastUpdateDate = dalUser.LastUpdateDate,
                    IsBlocked = dalUser.IsBlocked
                };
            }
            return null;
        }
    }
}
