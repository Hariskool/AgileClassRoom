using AgileClassRoom.Interface;
using AgileClassRoom.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AgileClassRoom.ViewModel;

namespace AgileClassRoom.Concrete
{
    public class CoordinatorConcrete : ICoordinator
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;
        public CoordinatorConcrete(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public void InsertCoordinator(Coordinator coordinator)
        {
            _context.Coordinator.Add(coordinator);
            _context.SaveChanges();

        }
        public bool CheckCoordinatorExits(string coordinatorEmail)
        {
            var result = (from coordinator in _context.Coordinator
                          join u in _context.Users on coordinator.UserId equals u.UserId
                          where u.EmailId==coordinatorEmail
                          select coordinator).Count();

            return result > 0 ? true : false;
        }
        
        public CoordinatorViewModel GetCoordinatorbyId(int coordinatorId)
        {
            var result = (from coordinator in _context.Coordinator
                          join user in _context.Users on coordinator.UserId equals user.UserId
                          join department in _context.Department on coordinator.DepartmentId equals department.DepartmentId
                          where coordinator.CoordinatorId == coordinatorId

                          select new CoordinatorViewModel
                          {
                             CoordinatorId=coordinator.CoordinatorId,
                             UserId = user.UserId   ,
                             UserName = user.UserName,
                             FullName = user.FullName,
                             EmailId = user.EmailId,
                             Contactno = user.Contactno,
                             Status =user.Status,
                             Password= EncodingLib.DecryptText(user.Password),
                             DepartmentId = department.DepartmentId,
                             DepartmentName =department.DepartmentName
    }).FirstOrDefault();

            return result;
        }
        public bool DeleteCoordinator(int coordinatorId)
        {
            var coordinator = (from coord in _context.Coordinator
                              where coord.CoordinatorId == coordinatorId
                               select coord).FirstOrDefault();
            var user = (from users in _context.Users
                        join coord in _context.Coordinator on users.UserId equals coord.UserId
                        where coord.CoordinatorId == coordinatorId
                        select users).FirstOrDefault();
            if (coordinator != null)
            {
                _context.Coordinator.Remove(coordinator);
                _context.Users.Remove(user);

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
       
        public bool UpdateCoordinator(Coordinator coordinator)
        {
          
            _context.Entry(coordinator).Property(x => x.DepartmentId).IsModified = true;
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
        public int GetCoordinatorId(int id)
        {
            var result = (from coordinator in _context.Coordinator
                          where coordinator.UserId == id
                          select coordinator.CoordinatorId).FirstOrDefault();
            return Convert.ToInt32(result);

        }
        public int GetCoordinatorDepartmentId(int id)
        {
            var result = (from coordinator in _context.Coordinator
                          where coordinator.CoordinatorId == id
                          select coordinator.DepartmentId).FirstOrDefault();
            return Convert.ToInt32(result);

        }
        public List<CoordinatorViewModel> GetAllCoordinator()
        {
            var result = (from coordinator in _context.Coordinator
                          join user in _context.Users on coordinator.UserId equals user.UserId
                          join department in _context.Department on coordinator.DepartmentId equals department.DepartmentId
                          select new CoordinatorViewModel
                          {
                              CoordinatorId=coordinator.CoordinatorId,
                              UserId = user.UserId,
                              UserName = user.UserName,
                              FullName = user.FullName,
                              EmailId = user.EmailId,
                              Contactno = user.Contactno,
                              Status = user.Status,
                              Password = EncodingLib.DecryptText(user.Password),
                              DepartmentId = department.DepartmentId,
                              DepartmentName = department.DepartmentName
                          }
                          ).ToList();

            return result;
        }
    }
}
