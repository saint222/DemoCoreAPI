﻿using AutoMapper;
using DemoCoreAPI.BusinessLogic.APIModels;
using DemoCoreAPI.BusinessLogic.BindingModels;
using DemoCoreAPI.BusinessLogic.Errors;
using DemoCoreAPI.BusinessLogic.Interfaces;
using DemoCoreAPI.Data;
using DemoCoreAPI.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoCoreAPI.BusinessLogic.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly IRepository<UserDb> _repo;
        private readonly IMapper _mapper;

        public AdminService(IRepository<UserDb> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public ICollection<UserAPIModel> GetAllUsers()
        {
            var users = _repo.GeAll();
            return _mapper.Map<ICollection<UserAPIModel>>(users);
        }

        public UserAPIModel GetUserById(long id)
        {
            if (id <= 0)
                throw new ArgumentException("Id can not be negative or 0.");
            var user = _repo.FindById(id);
            if (user == null)
                throw new NotFoundException("User doesn't exist.");
            return _mapper.Map<UserAPIModel>(user);
        }
        
        public NewUserAPIModel CreateNewUser(NewUserBindingModel model)
        {
            if (model == null)
                throw new ArgumentNullException("RegisterViewModel can not be null.");
            if (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password))
                throw new ArgumentException("Email and Password can not be null/empty.");
            var exists = _repo.Where(x => x.Email == model.Email).Any();
            if (exists)
                throw new EmailDuplicateException("User with such email already exists.");
            var newUser = _mapper.Map<UserDb>(model);
            _repo.Add(newUser);
            _repo.SaveChanges();
            return _mapper.Map<NewUserAPIModel>(newUser);
        }

        public UpdatedUserAPIModel UpdateUser(UpdateUserBindingModel model)
        {
            if (model == null)
                throw new ArgumentNullException("UpdateUserBindingModel can not be null");
            var updatedUser = _repo.FindById(model.Id);
            if (updatedUser == null)
                throw new NotFoundException("User is not found.");
            _mapper.Map(model, updatedUser);
            _repo.Update(updatedUser);
            _repo.SaveChanges();
            return _mapper.Map<UpdatedUserAPIModel>(updatedUser);
        }

        public DeleteUserApiModel RemoveUser(long id)
        {
            if (id <= 0)
                throw new ArgumentException("Id can not be negative or 0.");
            var userToDelete = _repo.FindById(id);
            if (userToDelete == null)
                throw new NotFoundException("User doesn't exist");
            _repo.Remove(userToDelete);
            _repo.SaveChanges();
            return _mapper.Map<DeleteUserApiModel>(userToDelete);
        }
    }
}
