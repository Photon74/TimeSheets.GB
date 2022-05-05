using System.Threading.Tasks;

using TimeSheets.GB.Controllers.Models;
using TimeSheets.GB.Controllers.Models.Responses;

namespace TimeSheets.GB.Services.Interfaces
{
    public interface IUserService : IService<UserDto>
    {
        TokenResponse Authenticate(string username, string password);

        string RefreshToken(string token);
    }
}
