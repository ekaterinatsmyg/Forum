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
        
    public class UserService: IUserService
    {
        private readonly IUnitOfWork uow;
        private readonly IUserRepository userRepository;

        public UserService(IUnitOfWork uow, IUserRepository repository)
        {
            this.uow = uow;
            this.userRepository = repository;
        }

        public UserEntity GetUserEntityById(int id)
        {
            return userRepository.GetById(id).ToBllUser();
        }

        public IEnumerable<UserEntity> GetAllUserEntities()
        {
            return userRepository.GetAll().Select(user => user.ToBllUser());
        }

        public IEnumerable<UserEntity> GetAllSimpleUsers()
        {
            return userRepository.GetAllBesidesAdmin().Select(user => user.ToBllUser());
        }
        public IEnumerable<UserEntity> GetBlockedUsers()
        {
            return userRepository.GetBlockedUsers().Select(user => user.ToBllUser());
        }
        public void UnBlockUser(int id)
        {
            userRepository.UnBlockUser(id);
            uow.Commit();
        }
        public void BlockUser (int id)
        {
            userRepository.BlockUser(id);
            uow.Commit();
        }
        public void CreateUser(UserEntity user)
        {
            userRepository.Create(user.ToDalUser());
            uow.Commit();
        }

        public void DeleteUser(UserEntity user)
        {
            userRepository.Delete(user.ToDalUser());
            uow.Commit();
        }

        public void UpdateUser(UserEntity user)
        {
            userRepository.Update(user.ToDalUser());
            uow.Commit();
        }

        public UserEntity GetUserByLogin(string userName)
        {
           return userRepository.GetByLogin(userName).ToBllUser();
        }
    }
}
