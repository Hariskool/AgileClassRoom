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
        bool CheckEnrolmentExits(int enrolId);
        EnrolViewModel GetEnrolmentbyId(int sectionId);
        bool DeleteEnrolment(int sectionId);
        bool UpdateEnrolment(Enrolment enrolment);
        List<EnrolViewModel> GetAllEnrolment();
    }
}
