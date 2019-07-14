using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.ViewModel
{
    public class AnnoucementViewModel
    {
        public int annoucementId { get; set; }
        public DateTime? expireDate { get; set; }
        public string description { get; set; }
        public int sectionId { get; set; }
        public int sectionNo { get; set; }
        public string CourseName { get; set; }

    }
}
