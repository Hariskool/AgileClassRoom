using AgileClassRoom.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.Interface
{
    public interface IRole
    {
        void InsertRole(Role role);
        bool CheckRoleExits(string roleName);
        Role GetRolebyId(int roleId);
        bool DeleteRole(int roleId);
        bool UpdateRole(Role role);
        List<Role> GetAllRole();
    }
}