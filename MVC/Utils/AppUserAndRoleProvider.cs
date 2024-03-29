﻿using DataAccess.Context;
using DataAccess.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MVC.Utils
{
    public class AppUserAndRoleProvider : RoleProvider
    {
        ProjeContext db = DbContextSingleton.Context;
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
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

        public override string[] GetRolesForUser(string username)
        {
            var userRoleList = from user in db.AppUsers join userandrole in db.AppUserAndRoles on user.ID equals userandrole.AppUserId join role in db.AppUserRoles on userandrole.AppUserRoleId equals role.ID where user.Username == username select role.RoleName;
            return userRoleList.ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
          throw new NotImplementedException();
            
        }

        public override bool IsUserInRole(string username, string roleName)
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
    }
}