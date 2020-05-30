using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.Data.Models;
using Template.Web.Dto;

namespace Template.Web.Mapper
{
    public class ApplicatioUserMapper:Profile
    {
        public ApplicatioUserMapper()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
        }

        public string UserDescription { get; set; }
        public int Rating { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpdateOn { get; set; }

        public UserAddress PrimaryAddress { get; set; }
    }
}
