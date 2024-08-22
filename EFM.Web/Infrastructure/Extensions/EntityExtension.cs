using System;
using EFM.Model.Model; 
using EFM.Web.Models; 

namespace EFM.Web.Infrastructure.Extensions
{
    public static class EntityExtension
    {
        public static void UpdateUser(this User user, UserViewModel userViewModel)
        {
            user.UserID = userViewModel.UserID;
            user.FullName = userViewModel.FullName;
            user.Email = userViewModel.Email;
            user.Username = userViewModel.UserName;
            user.PhoneNumber = userViewModel.PhoneNumber;
            user.IsActived = userViewModel.IsActived;
        }       
    }
}
