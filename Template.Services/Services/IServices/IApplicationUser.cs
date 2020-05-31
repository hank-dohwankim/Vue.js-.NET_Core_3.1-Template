using System;
using System.Collections.Generic;
using System.Text;
using Template.Data.Models;

namespace Template.Services.Services.IServices
{
    public interface IApplicationUser
    {
        ApplicationUser GetById(string userId);
        IEnumerable<ApplicationUser> GetAll();

        ServiceResponse<ApplicationUser> CreateUser(ApplicationUser user);
        ServiceResponse<ApplicationUser> UpdateUserRating(string userId, Type type);
        ServiceResponse<ApplicationUser> Deactivate(ApplicationUser user);
    }
}
