using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AgileClassRoom.Interface;
using AgileClassRoom.Models;

namespace AgileClassRoom.Concrete
{
    public class DepartmentConcrete : IDepartment
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public DepartmentConcrete(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public bool CheckDepartmentExits(string departmentName)
        {
            var result = (from department in _context.Department
                          where department.DepartmentName == departmentName
                          select department).Count();

            return result > 0 ? true : false;
        }

        public bool DeleteDepartment(int departmentId)
        {
            var departmentdata = (from department in _context.Department
                            where department.DepartmentId == departmentId
                            select department).FirstOrDefault();

            if (departmentdata != null)
            {
                _context.Department.Remove(departmentdata);
                var result = _context.SaveChanges();

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Department GetDepartmentbyId(int departmentId)
        {
            var result = (from department in _context.Department
                          where department.DepartmentId == departmentId
                          select department).FirstOrDefault();

            return result;
        }

        public List<Department> GetAllDepartment()
        {
            var result = (from department in _context.Department
                          select department).ToList();

            return result;
        }

        public void InsertDepartment(Department department)
        {
            _context.Department.Add(department);
            _context.SaveChanges();
        }

        public bool UpdateDepartment(Department department)
        {
           _context.Entry(department).Property(x => x.DepartmentName).IsModified = true;
            _context.Entry(department).Property(x => x.Description).IsModified = true;
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
