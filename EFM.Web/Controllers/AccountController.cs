using AutoMapper;
using EFM.Model.Model;
using EFM.Service;
using EFM.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFM.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        // Constructor với dependency injection
        public AccountController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var users = _userService.GetAll();
            var userViewModels = _mapper.Map<IEnumerable<UserViewModel>>(users);
            return View(userViewModels);
        }

        public ActionResult CreateAccount()
        {
            return PartialView("_CreateAccount");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAccount(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(userViewModel);
                _userService.Add(user);
                _userService.SaveChanges();
                return Json(new { success = true, message = "Tạo tài khoản thành công" });
            }
            return Json(new { success = false, message = "Có lỗi xảy ra", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }
    }
}