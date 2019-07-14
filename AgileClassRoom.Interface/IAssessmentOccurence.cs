using AgileClassRoom.Models;
using AgileClassRoom.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.Interface
{
    public interface IAssessmentOccurence
    {
        void InsertAssessmentOccurence(AssessmentOccurence assessment);
        bool CheckAssessmentOccurenceExits(string assessment);
        AssessmentOccurenceViewModel GetAssessmentOccurencebyId(int assessmentId);
        bool DeleteAssessmentOccurence(int annoucementId);
        bool UpdateAssessmentOccurence(AssessmentOccurence assessment);
        List<AssessmentOccurenceViewModel> GetAllAssessmentOccurence(int userId);
    }
}
