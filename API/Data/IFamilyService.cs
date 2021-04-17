using System.Collections;
using System.Collections.Generic;
using Models;

namespace Data
{
    public interface IFamilyService
    {
        IList<Family> GetFamiliesOfUser(int userId);
        IList<Family> GetAllFamilies();
        void AddFamily(Family family);
        void RemoveFamily(int familyId);
        void UpdateFamily(Family family);
    }
}