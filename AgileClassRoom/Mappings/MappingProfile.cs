using AgileClassRoom.Models;
using AgileClassRoom.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileClassRoom.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Role, RoleViewModel>()
                   .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.RoleName))
                   .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
            CreateMap<Department, DepartmentViewModel>()
                   .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.DepartmentName))
                   .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            CreateMap<UsersViewModel, Users>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Contactno, opt => opt.MapFrom(src => src.Contactno))
                .ForMember(dest => dest.EmailId, opt => opt.MapFrom(src => src.EmailId))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
            CreateMap<CoordinatorViewModel, Users>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Contactno, opt => opt.MapFrom(src => src.Contactno))
                .ForMember(dest => dest.EmailId, opt => opt.MapFrom(src => src.EmailId))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                 .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
            CreateMap<ProgramViewModel, AgileClassRoom.Models.Program>()
                .ForMember(dest => dest.ProgramID, opt => opt.MapFrom(src => src.ProgramID))
                .ForMember(dest => dest.ProgramName, opt => opt.MapFrom(src => src.ProgramName))
                .ForMember(dest => dest.ProgramCode, opt => opt.MapFrom(src => src.ProgramCode))
                .ForMember(dest => dest.TotalCreditHours, opt => opt.MapFrom(src => src.TotalCreditHours))
                .ForMember(dest => dest.CoordinatorId, opt => opt.MapFrom(src => src.CoordinatorId));

            CreateMap<CoordinatorViewModel, Coordinator>()
                 .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                 .ForMember(dest => dest.CoordinatorId, opt => opt.MapFrom(src => src.CoordinatorId))
                 .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId));

            CreateMap<CourseViewModel, Course>()
          .ForMember(dest => dest.CourseID, opt => opt.MapFrom(src => src.CourseID))
          .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.CourseName))
          .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
          .ForMember(dest => dest.ProgramID, opt => opt.MapFrom(src => src.ProgramID))
          .ForMember(dest => dest.CreditHours, opt => opt.MapFrom(src => src.CreditHours))
          .ForMember(dest => dest.CourseCode, opt => opt.MapFrom(src => src.CourseCode));

            CreateMap<TeacherViewModel, Teacher>()
          .ForMember(dest => dest.TeacherID, opt => opt.MapFrom(src => src.TeacherId))
          .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
          .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
          .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserId));

            CreateMap<TeacherViewModel, Users>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Contactno, opt => opt.MapFrom(src => src.Contactno))
                .ForMember(dest => dest.EmailId, opt => opt.MapFrom(src => src.EmailId))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                 .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
            CreateMap<StudentViewModel, Student>()
          .ForMember(dest => dest.StudentID, opt => opt.MapFrom(src => src.StudentId))
          .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
          .ForMember(dest => dest.Cgpa, opt => opt.MapFrom(src => src.Cgpa))
          .ForMember(dest => dest.Semester, opt => opt.MapFrom(src => src.Semester))
          .ForMember(dest => dest.DepartmentID, opt => opt.MapFrom(src => src.DepartmentId))
          .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserId));

            CreateMap<StudentViewModel, Users>()
       .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
       .ForMember(dest => dest.Contactno, opt => opt.MapFrom(src => src.Contactno))
       .ForMember(dest => dest.EmailId, opt => opt.MapFrom(src => src.EmailId))
       .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
       .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
        .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
       .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<CourseViewModel, Course>()
          .ForMember(dest => dest.CourseID, opt => opt.MapFrom(src => src.CourseID))
          .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.CourseName))
          .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
          .ForMember(dest => dest.ProgramID, opt => opt.MapFrom(src => src.ProgramID))
          .ForMember(dest => dest.CreditHours, opt => opt.MapFrom(src => src.CreditHours))
          .ForMember(dest => dest.CourseCode, opt => opt.MapFrom(src => src.CourseCode));

            CreateMap<NotificationViewModel, Notification>()
                            .ForMember(dest => dest.NotificationId, opt => opt.MapFrom(src => src.NotificationId))
                            .ForMember(dest => dest.Createddate, opt => opt.MapFrom(src => src.Createddate))
                            .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message));
            CreateMap<ProjectViewModel, Project>()
                           .ForMember(dest => dest.projectId, opt => opt.MapFrom(src => src.projectId))
                           .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
                           .ForMember(dest => dest.IssueDate, opt => opt.MapFrom(src => src.IssueDate))
                           .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                           .ForMember(dest => dest.description, opt => opt.MapFrom(src => src.description))
                           .ForMember(dest => dest.assessmentId, opt => opt.MapFrom(src => src.assessmentId));
            CreateMap<AssignProjectViewModel, AssignProject>()
                          .ForMember(dest => dest.projectId, opt => opt.MapFrom(src => src.projectId))
                         .ForMember(dest => dest.courseId, opt => opt.MapFrom(src => src.courseId))
                          .ForMember(dest => dest.sectionId, opt => opt.MapFrom(src => src.sectionId));

            CreateMap<AnnoucementViewModel, Annoucement>()
                            .ForMember(dest => dest.annoucementId, opt => opt.MapFrom(src => src.annoucementId))
                            .ForMember(dest => dest.sectionId, opt => opt.MapFrom(src => src.sectionId))
                            .ForMember(dest => dest.expireDate, opt => opt.MapFrom(src => src.expireDate))
                            .ForMember(dest => dest.description, opt => opt.MapFrom(src => src.description));

            CreateMap<EnrolViewModel, Enrolment>()
                          .ForMember(dest => dest.EnrolmentID, opt => opt.MapFrom(src => src.EnrolmentID))
                          .ForMember(dest => dest.SectionID, opt => opt.MapFrom(src => src.SectionID))
                          .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                          .ForMember(dest => dest.StudentID, opt => opt.MapFrom(src => src.StudentID));
            CreateMap<SectionViewModel, Section>()
                          .ForMember(dest => dest.SectionID, opt => opt.MapFrom(src => src.SectionID))
                          .ForMember(dest => dest.SectionNo, opt => opt.MapFrom(src => src.SectionNo))
                          .ForMember(dest => dest.CourseID, opt => opt.MapFrom(src => src.CourseID))
                          .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                          .ForMember(dest => dest.TeacherID, opt => opt.MapFrom(src => src.TeacherID));


        }
    }
}
