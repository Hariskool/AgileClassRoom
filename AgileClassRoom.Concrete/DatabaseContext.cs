using AgileClassRoom.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace AgileClassRoom.Concrete
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

       
        public DbSet<Role> Role { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<UsersInRoles> UsersInRoles { get; set; }
        public DbSet<Coordinator> Coordinator { get; set; }
        public DbSet<Program> Program { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Enrolment> Enrolment { get; set; }
        public DbSet<Assessment> Assessment { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet <AssignProject> AssignProject { get; set; }
        public DbSet<Annoucement> Annoucement { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<GroupMembers> GroupMembers { get; set; }

    }
}
