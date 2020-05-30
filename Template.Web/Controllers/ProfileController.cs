using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Template.Data.Models;
using Template.Services.Repository.IRepository;

namespace Template.Web.Controllers
{
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUser _userService;
        private readonly IConfiguration _configuration;

        public ProfileController(UserManager<ApplicationUser> userManager, IApplicationUser userService, IConfiguration configuration)
        {
            _userManager = userManager;
            _userService = userService;
            _configuration = configuration;
        }
    }
}