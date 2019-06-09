using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.ViewModel
{
   public class ProgramViewModel
    {
        public int ProgramID { get; set; }  
        public string ProgramCode { get; set; }   
        public string TotalCreditHours { get; set; } 
        public string ProgramName { get; set; }
        public int CoordinatorId { get; set; }
        public string CoordinatorInfo { get; set; }
    }
}
