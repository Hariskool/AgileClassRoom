using AgileClassRoom.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.Interface
{
   public interface IDepartment
    {
        void InsertDepartment(Department department);
        bool CheckDepartmentExits(string departmentName);
        Department GetDepartmentbyId(int departmentId);
        bool DeleteDepartment(int departmentId);
        bool UpdateDepartment(Department department);
        List<Department> GetAllDepartment();
    }
}
