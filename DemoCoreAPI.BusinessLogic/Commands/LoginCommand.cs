using DemoCoreAPI.BusinessLogic.ViewModels;
using MediatR;

namespace DemoCoreAPI.BusinessLogic.Commands
{
    public class LoginCommand: IRequest<LoginApiModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
