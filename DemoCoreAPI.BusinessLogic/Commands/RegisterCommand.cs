using DemoCoreAPI.BusinessLogic.ViewModels;
using MediatR;

namespace DemoCoreAPI.BusinessLogic.Commands
{
    public class RegisterCommand: IRequest<RegisterApiModel>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
