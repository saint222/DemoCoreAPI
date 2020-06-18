using AutoMapper;
using DemoCoreAPI.BusinessLogic.Commands;
using DemoCoreAPI.BusinessLogic.ViewModels;
using DemoCoreAPI.Data.SQLServer;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DemoCoreAPI.BusinessLogic.Handlers
{
    public class LoginHandler: IRequestHandler<LoginCommand, LoginAPIModel>
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public LoginHandler(IMapper mapper, ApiContext context)
        {
            _context = context;
            if (context == null)
                throw new ArgumentNullException("Context is null.");
            _mapper = mapper;
        }

        public async Task<LoginAPIModel> Handle(LoginCommand model, CancellationToken cancellationToken)
        {
            if (model == null)
                throw new ArgumentNullException("LoginViewModel can not be null.");
            if (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password))
                throw new ArgumentException("Email and Password can not be null/empty.");

            var hashedPassword = Utilities.Utilities.HashPassword(model.Password);
            var user = _context.Users.Where(x => x.Email == model.Email && x.Password == hashedPassword).FirstOrDefault();

            return _mapper.Map<LoginAPIModel>(user);
        }
    }
}
