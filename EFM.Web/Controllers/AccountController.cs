using AutoMapper;
using EFM.Model.Model;
using EFM.Service;
using EFM.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            int orderNumber = 1;
            foreach (var userViewModel in userViewModels)
            {
                userViewModel.OrderNumber = orderNumber++;
            }
            return View(userViewModels);
        }
        public ActionResult DetailAccount(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            var userViewModel = _mapper.Map<UserViewModel>(user);
            return View(userViewModel);
        }
        public ActionResult CreateAccount()
        {
            var roles = new List<SelectListItem>
            {
                new SelectListItem { Value = "Admin", Text = "Admin" },
                new SelectListItem { Value = "Manager", Text = "Quản lý" },
                new SelectListItem { Value = "Member", Text = "Thành viên" }
            };

            ViewBag.Roles = roles;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAccount(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(userViewModel);
                user = _userService.AddUser(user);
                return Json(new { status = true, message = "Tạo tài khoản thành công" });
            }

            return Json(new { status = false, message = "Có lỗi xảy ra", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }

        public ActionResult EditAccount(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            var userViewModel = _mapper.Map<UserViewModel>(user);
            return View(userViewModel);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAccount(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(userViewModel);
                _userService.Update(user);
                _userService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userViewModel);
        }
        [HttpDelete]
        public ActionResult DeleteAccount(int id)
        {
            var user = _userService.DeleteAccount(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return Json(new { success = true });
        }


    }
}