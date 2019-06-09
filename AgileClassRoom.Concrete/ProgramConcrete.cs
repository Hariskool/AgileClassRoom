using AgileClassRoom.Interface;
using AgileClassRoom.Models;
using AgileClassRoom.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.Concrete
{
   public class ProgramConcrete : IProgram
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;
        public ProgramConcrete(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public void InsertProgram(Program program)
        {
            _context.Program.Add(program);
            _context.SaveChanges();
        }
        public bool CheckProgramExits(string programCode, string programName)
        {
            var result = (from program in _context.Program
                          where program.ProgramCode == programCode
                          select program).Count();
            var result2 = (from program in _context.Program
                          where program.ProgramName == programName
                          select program).Count();
            return result > 0 || result2 > 0 ? true : false;


        }
       public List<ProgramViewModel> GetAllProgramsOfCoordinator(int id)
        {
            var result = (from program in _context.Program
                          join coordinator in _context.Coordinator on program.CoordinatorId equals coordinator.CoordinatorId
                          join user in _context.Users on coordinator.UserId equals user.UserId
                          where coordinator.CoordinatorId == id
                          select new ProgramViewModel
                          {
                              ProgramID = program.ProgramID,
                              ProgramCode = program.ProgramCode,
                              TotalCreditHours = program.TotalCreditHours,
                              ProgramName = program.ProgramName,
                              CoordinatorId = coordinator.CoordinatorId,
                              CoordinatorInfo = user.FullName
                          }
                          ).ToList();
            return result;


        }
        public ProgramViewModel GetProgrambyId(int ProgramId)
        {
            var result = (from program in _context.Program
                          join coordinator in _context.Coordinator on program.CoordinatorId equals coordinator.CoordinatorId
                          join user in _context.Users on coordinator.UserId equals user.UserId
                          where program.ProgramID == ProgramId
                          select new ProgramViewModel
                          {
                              ProgramID = program.ProgramID,
                              ProgramCode = program.ProgramCode,
                              TotalCreditHours = program.TotalCreditHours,
                              ProgramName = program.ProgramName,
                              CoordinatorId = coordinator.CoordinatorId,
                              CoordinatorInfo = user.FullName
                          }
                          ).FirstOrDefault();
            return result;

                          }
        public bool DeleteProgram(int programId)
        {
            var program = (from prog in _context.Program
                               where prog.ProgramID == programId
                           select prog).FirstOrDefault();
            if (program != null)
            {
                _context.Program.Remove(program);
               

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
        public bool UpdateProgram(Program program)
        {
            _context.Entry(program).Property(x => x.ProgramName).IsModified = true;
            _context.Entry(program).Property(x => x.ProgramCode).IsModified = true;
            _context.Entry(program).Property(x => x.TotalCreditHours).IsModified = true;
            if (CheckProgramExits(program.ProgramCode, program.ProgramName))
            {
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
        public List<ProgramViewModel> GetAllPrograms()
        {
            var result = (from program in _context.Program
                          join coordinator in _context.Coordinator on program.CoordinatorId equals coordinator.CoordinatorId
                          join user in _context.Users on coordinator.UserId equals user.UserId
                          select new ProgramViewModel
                          {
                              ProgramID = program.ProgramID,
                              ProgramCode = program.ProgramCode,
                              TotalCreditHours = program.TotalCreditHours,
                              ProgramName = program.ProgramName,
                              CoordinatorId = coordinator.CoordinatorId,
                              CoordinatorInfo = user.FullName
                          }
                          ).ToList();
            return result;
        }
       
    }
}
