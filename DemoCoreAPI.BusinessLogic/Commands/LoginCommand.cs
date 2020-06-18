using DemoCoreAPI.BusinessLogic.ViewModels;
using MediatR;

namespace DemoCoreAPI.BusinessLogic.Commands
{
    public class LoginCommand: IRequest<LoginAPIModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
