using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Data
{
    public interface IFamilyService
    {
        Task<IList<Family>> GetFamiliesOfUser(int userId);
        Task<IList<Family>> GetAllFamilies();
        void AddFamily(Family family);
        void RemoveFamily(int familyId);
        void UpdateFamily(Family family);
    }
}