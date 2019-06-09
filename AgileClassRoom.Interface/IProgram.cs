using AgileClassRoom.Models;
using AgileClassRoom.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.Interface
{
    public interface IProgram
    {
        void InsertProgram(Program program);
        bool CheckProgramExits(string programCode, string programName);
        ProgramViewModel GetProgrambyId(int ProgramId);
        bool DeleteProgram(int programId);
        bool UpdateProgram(Program program);
        List<ProgramViewModel> GetAllPrograms();
        List<ProgramViewModel> GetAllProgramsOfCoordinator(int id);

    }
}
