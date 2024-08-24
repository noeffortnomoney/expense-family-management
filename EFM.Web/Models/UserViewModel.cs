using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFM.Common.Helpers;
using EFM.Common.Resources;

namespace EFM.Web.Models
{
    public class UserViewModel
    {
        public int UserID { get; set; }

        [LocalizedDisplayName("UserName", NameResourceType = typeof(EFM.Common.Resources.UserResource))]
        public string UserName { get; set; }

        public string Password { get; set; }

        [LocalizedDisplayName("FullName", NameResourceType = typeof(EFM.Common.Resources.UserResource))]
        public string FullName { get; set; }

        [LocalizedDisplayName("Email", NameResourceType = typeof(UserResource))]
        public string Email { get; set; }

        [LocalizedDisplayName("PhoneNumber", NameResourceType = typeof(UserResource))]
        public string PhoneNumber {  get; set; }

        [LocalizedDisplayName("Address", NameResourceType = typeof(UserResource))]
        public string Address { get; set; }

        [LocalizedDisplayName("Status", NameResourceType = typeof(UserResource))]
        public bool IsActived { get; set; }
        public string Role { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }

        [LocalizedDisplayName("OrderNumber", NameResourceType = typeof(UserResource))]
        public int OrderNumber { get; set; }
    }
}