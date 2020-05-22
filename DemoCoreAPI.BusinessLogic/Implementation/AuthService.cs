using AutoMapper;
using DemoCoreAPI.BusinessLogic.Errors;
using DemoCoreAPI.BusinessLogic.Interfaces;
using DemoCoreAPI.BusinessLogic.ViewModels;
using DemoCoreAPI.Data;
using DemoCoreAPI.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DemoCoreAPI.BusinessLogic.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<UserDb> _repo;
        private readonly IMapper _mapper;
        public AuthService(IRepository<UserDb> repo, IMapper mapper)
        {
            _repo = repo;
            if (repo == null)
                throw new ArgumentNullException("Repo is null.");
            _mapper = mapper;
        }
        public LoginAPIModel Login(LoginBindingModel model)
        {
            if (model == null)
                throw new ArgumentNullException("LoginViewModel can not be null.");
            if (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password))
                throw new ArgumentException("Email and Password can not be null/empty.");

            var hashedPassword = HashPassword(model.Password);
            var user = _repo.Where(x => x.Email == model.Email && x.Password == hashedPassword).FirstOrDefault();

            return _mapper.Map<LoginAPIModel>(user);
        }

        public RegisterAPIModel Register(RegisterBindingModel model)
        {
            if (model == null)
                throw new ArgumentNullException("RegisterViewModel can not be null.");
            if (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password))
                throw new ArgumentException("Email and Password can not be null/empty.");
            var isMatch = ComparePasswords(model);
            if (!isMatch)
                throw new PasswordMismatchException("Passwords don't match!");
            var exists = _repo.Where(x => x.Email == model.Email).Any();
            if (exists)
                throw new EmailDuplicateException("User with such email already exists.");

            model.Password = HashPassword(model.Password);
            var user = _mapper.Map<UserDb>(model);
            _repo.Add(user);
            _repo.SaveChanges();
            return _mapper.Map<RegisterAPIModel>(user);
        }

        private string HashPassword(string password)
        {
            return UseHash256(Encoding.UTF8.GetBytes(password));
        }

        private string UseHash256(byte[] input)
        {
            using (var algo = HashAlgorithm.Create("sha256"))
            {
                return Convert.ToBase64String(algo.ComputeHash(input));
            }
        }
        private bool ComparePasswords(RegisterBindingModel model)
        {
            if (model.Password == model.PasswordConfirmation)
                return true;
            else
                return false;
        }
    }
}
