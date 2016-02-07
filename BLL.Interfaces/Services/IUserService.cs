using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IUserService
    {
        UserEntity GetUserEntityById(int id);
        IEnumerable<UserEntity> GetAllUserEntities();
        IEnumerable<UserEntity> GetAllSimpleUsers();
        void BlockUser(int id);
        IEnumerable<UserEntity> GetBlockedUsers();
        void UnBlockUser(int id);
        void CreateUser(UserEntity user);
        void DeleteUser(UserEntity user);
        void UpdateUser(UserEntity user);
        UserEntity GetUserByLogin(string userName);
    }
}
