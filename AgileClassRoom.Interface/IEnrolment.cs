using AgileClassRoom.Models;
using AgileClassRoom.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.Interface
{
    public interface IEnrolment
    {
        void InsertEnrolment(Enrolment enrolment);
        bool CheckEnrolmentExits(int studentId,int sectionId);
        EnrolViewModel GetEnrolmentbyId(int enrolId);
        bool DeleteEnrolment(int enrolId);
        bool UpdateEnrolment(Enrolment enrolment);
        List<EnrolViewModel> GetAllEnrolment(int userId);
    }
}
