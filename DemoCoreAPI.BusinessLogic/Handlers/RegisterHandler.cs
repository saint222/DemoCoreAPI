using AutoMapper;
using DemoCoreAPI.BusinessLogic.Commands;
using DemoCoreAPI.BusinessLogic.Errors;
using DemoCoreAPI.BusinessLogic.ViewModels;
using DemoCoreAPI.Data.SQLServer;
using DemoCoreAPI.DomainModels.Models;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DemoCoreAPI.BusinessLogic.Handlers
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, RegisterAPIModel>
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public RegisterHandler(IMapper mapper, ApiContext context)
        {
            _context = context;
            if (context == null)
                throw new ArgumentNullException("Context is null.");
            _mapper = mapper;
        }

        public async Task<RegisterAPIModel> Handle(RegisterCommand model, CancellationToken cancellationToken)
        {
            if (model == null)
                throw new ArgumentNullException("RegisterViewModel can not be null.");
            if (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password))
                throw new ArgumentException("Email and Password can not be null/empty.");
            var isMatch = Utilities.Utilities.ComparePasswords(model);
            if (!isMatch)
                throw new PasswordMismatchException("Passwords don't match!");
            var exists = _context.Users.Where(x => x.Email == model.Email).Any();
            if (exists)
                throw new EmailDuplicateException("User with such email already exists.");

            model.Password = Utilities.Utilities.HashPassword(model.Password);
            var user = _mapper.Map<UserDb>(model);
            _context.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<RegisterAPIModel>(user);
        }
    }
}
