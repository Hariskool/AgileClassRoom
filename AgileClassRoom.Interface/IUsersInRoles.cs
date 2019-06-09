using AgileClassRoom.Models;
using AgileClassRoom.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgileClassRoom.Interface
{
   
    public interface IUsersInRoles
    {
        bool AssignRole(UsersInRoles usersInRoles);
        bool CheckRoleExists(UsersInRoles usersInRoles);
        bool RemoveRole(UsersInRoles usersInRoles);
        List<AssignRolesViewModel> GetAssignRoles();
    }
}
