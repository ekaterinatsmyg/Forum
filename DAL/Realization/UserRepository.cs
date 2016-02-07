using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;
using Entities;

namespace DAL.Realization
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(DbContext _context)
        {
            this.context = _context;
        }

        public IEnumerable<DalUser> GetAll()
        {
            return context.Set<User>().Select(user => new DalUser()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Login = user.Login,
                Password = user.Password,
                Email = user.Email,
                IsBlocked = user.IsBlocked
            });
        }
        public DalUser GetById(int entityId)
        {
            var user = context.Set<User>().Where(u => u.Id == entityId).FirstOrDefault();
            return new DalUser()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Login = user.Login,
                Password = user.Password,
                Email = user.Email,
                IsBlocked = user.IsBlocked
            };
        }

        public IEnumerable<DalUser> GetBlockedUsers()
        {
            return context.Set<User>().Where(user => user.IsBlocked != false).Select(user => new DalUser()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Login = user.Login,
                Password = user.Password,
                Email = user.Email,
                IsBlocked = user.IsBlocked
            });
        }
        public void UnBlockUser(int id)
        {
            var user = context.Set<User>().Where(u => u.Id == id).FirstOrDefault();
            if (user != null)
            {
                user.IsBlocked = false;
            }
        }
        public IEnumerable<DalUser> GetAllBesidesAdmin()
        {
            return (from user in context.Set<User>()
                    join userRole in context.Set<RoleUser>()
                    on user.Id equals userRole.UserId
                    where userRole.RoleId != 1 && user.IsBlocked == false
                    select user).Select(user => new DalUser()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Login = user.Login,
                Password = user.Password,
                Email = user.Email,
                IsBlocked = user.IsBlocked
            });

        }
       
        public void Create(DalUser entity)
        {
            var user = new User()
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                Login = entity.Login,
                Password = entity.Password,
                Email = entity.Email,
                IsBlocked = entity.IsBlocked,
                LastUpdateDate = entity.DateAdded
            };
           
            context.Set<User>().Add(user);
          
        }
        public void Delete(DalUser entity)
        {
            var user = context.Set<User>().Where(u => u.Id == entity.Id).FirstOrDefault();
            var userRoles = context.Set<RoleUser>().Where(role => role.UserId == user.Id);
            if (userRoles != null)
            {
                foreach (var userRole in userRoles)
                {
                    context.Set<RoleUser>().Remove(userRole);
                }
            }
            if (user != null)
            {
                context.Set<User>().Remove(user);
            }

        }
        public void Update(DalUser entity)
        {
            var user = context.Set<User>().Where(u => u.Id == entity.Id).FirstOrDefault();
            if (user != null)
            {
                user.Name = entity.Name;
                user.Surname = entity.Surname;
                user.Login = entity.Login;
                user.Password = entity.Password;
                user.Email = entity.Email;
                user.DateAdded = entity.DateAdded;
                user.IsBlocked = entity.IsBlocked;
                user.LastUpdateDate = DateTime.Now;            

            }
        }

        public DalUser GetByLogin(string login)
        {
            var user = context.Set<User>().Where(u => u.Login == login).FirstOrDefault();
            if (user != null)
            {
                return new DalUser()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Login = user.Login,
                    Password = user.Password,
                    Email = user.Email,
                    DateAdded = user.DateAdded,
                    IsBlocked = user.IsBlocked
                };
            }
            return null;
        }

        public void BlockUser(int id)
        {
            var user = context.Set<User>().Where(u => u.Id == id).FirstOrDefault();
            if (user != null)
            {
                user.IsBlocked = true;
            }

        }

    }
}
