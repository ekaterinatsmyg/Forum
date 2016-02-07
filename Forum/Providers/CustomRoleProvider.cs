using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interface.Services;
using BLL.Interface.Entities;

namespace Forum.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public IUserService UserService
        {
            get { return (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService)); }
        }

        public IRoleService RoleService
        {
            get { return (IRoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleService)); }
        }

        public IRoleUserService RoleUserService
        {
            get { return (IRoleUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleUserService)); }
        }

        public override bool IsUserInRole(string userName, string roleName)
        {
            UserEntity user = UserService.GetUserByLogin(userName);
            if (user == null)
            {
                return false;
            }
            var userRolesId = RoleUserService.GetByUserId(user.Id).Select(role => role.RoleId);
            IEnumerable<RoleEntity> userRoles = RoleService.GetByListId(userRolesId);

            if (userRoles == null) 
            {
                return false;
            }
            foreach (var userRole in userRoles)
            {
                if (userRole.RoleOfUser == roleName)
                {
                    return true;
                }
            }

            return false;
        }

        public override string[] GetRolesForUser(string userName)
        {
            List<string> roles = new List<string>();
            UserEntity user = UserService.GetUserByLogin(userName);
            if (user == null)
            {
                return roles.ToArray();
            }
            var userRolesId = RoleUserService.GetByUserId(user.Id).Select(role => role.RoleId);
            var userRoles = RoleService.GetByListId(userRolesId);
            if (userRoles != null)
            {
                foreach (var userRole in userRoles)
                {
                    roles.Add(userRole.RoleOfUser);
                }
            }
            return roles.ToArray();
            
        }

        public override void CreateRole(string roleName)
        {
            var newRole = new RoleEntity() { RoleOfUser = roleName };
            RoleService.CreateRole(newRole);
        }


        #region Stab
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

       

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}