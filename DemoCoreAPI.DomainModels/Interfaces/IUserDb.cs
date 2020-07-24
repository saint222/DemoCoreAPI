using DemoCoreAPI.DomainModels.Enums;
using System;

namespace DemoCoreAPI.DomainModels.Interfaces
{
    public interface IUserDb
    {
        long Id { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Patronymic { get; set; }
        DateTime DateOfBirth { get; set; }
        Roles Role { get; set; }
    }
}