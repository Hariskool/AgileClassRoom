using AgileClassRoom.Models;
using AgileClassRoom.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.Interface
{
    public interface IResult
    {
        void InsertResult(Result course);
        bool CheckResultExits(string courseCode);
        ResultViewModel GetResultbyId(int courseId);
        bool DeleteResult(int courseId);
        bool UpdateResult(Result course);
      
    }
}
