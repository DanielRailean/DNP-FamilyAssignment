using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    public interface IFamilyController
    {
        Task<ActionResult<IList<Family>>> GetFamiliesOfUser(int userId);
        Task<ActionResult<Family>> AddFamily(Family family);
        Task<ActionResult<Family>> RemoveFamily(int familyId);
        Task<ActionResult<Family>> UpdateFamily(Family family);
    }
}