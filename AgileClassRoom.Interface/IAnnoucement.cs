using AgileClassRoom.Models;
using AgileClassRoom.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.Interface
{
    public interface IAnnoucement
    {
        void InsertAnnoucement(Annoucement annoucement);
       // bool CheckAnnoucementExits(string courseCode);
        AnnoucementViewModel GetAnnoucementbyId(int annoucemntId);
        bool DeleteAnnoucement(int annoucementId);
        bool UpdateAnnoucement(Annoucement annoucement);
        List<AnnoucementViewModel> GetAllAnnoucements(int userId);
    }
}
