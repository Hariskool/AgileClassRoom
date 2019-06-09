using AgileClassRoom.Models;
using AgileClassRoom.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.Interface
{
    public interface ISection
    {
        void InsertSection(Section section);
        bool CheckSectionExits(int sectionNo, int courseid);
        SectionViewModel GetSectionbyId(int sectionId);
        bool DeleteSection(int sectionId);
      //  bool CheckAlreadyBooked(int section);
        bool UpdateSection(Section section);
        List<SectionViewModel> GetAllSections(int userid);
    }
}
