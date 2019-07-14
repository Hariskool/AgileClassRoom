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
    public class GroupConcrete: IGroup
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public GroupConcrete(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public void InsertGroup(Groups group)
        {
            _context.Groups.Add(group);
            _context.SaveChanges();

        }
        public bool CheckGroupExits(int groupNo)
        {
            var result = (from gs in _context.Groups
                          where gs.groupNo == groupNo

                          select gs).Count();
            //
            return result > 0 ? true : false;
        }

        public GroupViewModel GetGroupbyId(int groupId)
        {
            var groupResult = (from gm in _context.GroupMembers
                               where gm.groupId == groupId
                               select gm).ToList();
            var result = (from gs in _context.Groups
                          join groupmembers in _context.GroupMembers on gs.groupId equals groupmembers.groupId

                          where gs.groupId == groupId
                          select new GroupViewModel
                          {
                              groupId = gs.groupId,
                              groupNo = gs.groupNo,
                              sectionId = gs.sectionId,
                              createdBy = gs.createdBy,
                              groupMembers = groupResult.Select(r => new GroupMembers
                              {
                                  groupId = r.groupId,
                                  studentId = r.studentId,
                                  groupMemberId = r.groupMemberId
                              }),
                              totalMember = gs.totalMember,
                              

                          }).FirstOrDefault();

            return result;
        }
        public bool DeleteGroup(int groupid)
        {
            var delresult = (from gp in _context.Groups
                             where gp.groupId == groupid
                             select gp).FirstOrDefault();

            if (delresult != null)
            {
                _context.Groups.Remove(delresult);


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

        public bool UpdateGroup(Groups group)
        {

            _context.Entry(group).Property(x => x.groupNo).IsModified = true;
            _context.Entry(group).Property(x => x.totalMember).IsModified = true;
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
        public List<GroupViewModel> GetAllGroups(int userId)
        {
            var findUser = (from teacher in _context.Teacher
                            join user in _context.Users on teacher.UserID equals user.UserId
                            where user.UserId == userId
                            select teacher.TeacherID).FirstOrDefault();
            int techId = Convert.ToInt32(findUser);

            var groupResult = (from gm in _context.GroupMembers
                             
                               select gm).ToList();
            var result = (from gs in _context.Groups
                           

                          where gs.createdBy == techId
                          select new GroupViewModel
                          {
                              groupId = gs.groupId,
                              groupNo = gs.groupNo,
                              sectionId = gs.sectionId,
                              createdBy = gs.createdBy,
                              groupMembers = groupResult.Where(x => x.groupId == gs.groupId)
                              .Select(r => new GroupMembers
                              {
                                  groupId = r.groupId,
                                  studentId = r.studentId,
                                  groupMemberId = r.groupMemberId
                              }),
                              totalMember = gs.totalMember,


                          }).ToList();
            return result;
        }
    }
}