using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    public interface IUserController
    {
        Task<ActionResult<User>> RegisterUser([FromBody] User user);
        Task<ActionResult<User>> ValidateUser([FromQuery] string? username, [FromQuery] string? password);
        Task<ActionResult<User>> UpdateUser([FromBody] User user);
        Task<ActionResult<User>> RemoveUser([FromBody] int userId);
    }
}