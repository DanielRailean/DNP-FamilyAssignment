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
        Task AddFamily(Family family);
        Task RemoveFamily(int familyId);
        Task UpdateFamily(Family family);
    }
}