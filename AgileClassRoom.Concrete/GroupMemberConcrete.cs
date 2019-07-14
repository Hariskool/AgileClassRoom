using AgileClassRoom.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AgileClassRoom.Models;

namespace AgileClassRoom.Concrete
{
    public class GroupMemberConcrete : IGroupMember
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public GroupMemberConcrete(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        
        public void InsertGroupMembers(GroupMembers group)
        {
            _context.GroupMembers.Add(group);
            _context.SaveChanges();

        }
        public bool CheckGroupMembersExits(int groupId)
        {
            var result = (from gs in _context.GroupMembers
                          where gs.groupId == groupId

                          select gs).Count();
            //
            return result > 0 ? true : false;
        }
        public bool DeleteGroupMembers(int groupMemberId)
        {
            var delresult = (from gp in _context.GroupMembers
                             where gp.groupMemberId == groupMemberId
                             select gp).FirstOrDefault();

            if (delresult != null)
            {
                _context.GroupMembers.Remove(delresult);


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

        public bool UpdateGroup(GroupMembers group)
        {

            _context.Entry(group).Property(x => x.groupMemberId).IsModified = true;
            _context.Entry(group).Property(x => x.studentId).IsModified = true;
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