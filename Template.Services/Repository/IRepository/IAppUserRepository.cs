using System;
using System.Collections.Generic;
using System.Text;
using Template.Data.Models;

namespace Template.Services.Repository.IRepository
{
    public interface IAppUserRepository
    {
        ApplicationUser GetById(string userId);
        IEnumerable<ApplicationUser> GetAll();

        ServiceResponse<ApplicationUser> CreateUser(ApplicationUser user);
        ServiceResponse<ApplicationUser> UpdateUser(string userId, Type type);
        ServiceResponse<ApplicationUser> Deactivate(ApplicationUser user);
    }
}
