using AgileClassRoom.Models;
using AgileClassRoom.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.Interface
{
    public interface IAssessment
    {
        void InsertAssessment(Assessment assessment);
        bool CheckAssessmentExits(string assessment);
        AssessmentViewModel GetAssessmentbyId(int assessmentId);
        bool DeleteAssessment(int annoucementId);
        bool UpdateAssessment(Assessment assessment);
        List<AssessmentViewModel> GetAllAssessments(int userId);
    }
}
