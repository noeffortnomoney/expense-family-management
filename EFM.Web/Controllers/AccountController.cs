using AutoMapper;
using EFM.Model.Model;
using EFM.Service;
using EFM.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        [HttpPost]
        public ActionResult ResetPassword(int userId, string newPassword)
        {
            var result = _userService.ResetPassword(userId, newPassword);

            if (result)
            {
                return Json(new { success = true, message = "Cấp lại mật khẩu thành công." });
            }
            else
            {
                return Json(new { success = false, message = "Cấp lại mật khẩu thất bại. Vui lòng thử lại." });
            }
        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        { 
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userName = model.UserName;
                var user = _userService.GetUserByUserName(userName);

                if (user != null)
                {
                    //var userViewModel = _mapper.Map<UserViewModel>(model);
                    var newPassword = _userService.GenerateNewPassword();

                    try
                    {
                        _userService.UpdateUserPassword(user, newPassword);

                        // Gửi email mật khẩu mới
                        string recipientEmail = "truongquocbinh0423@gmail.com";
                        string senderEmail = ConfigurationManager.AppSettings["SenderEmail"];
                        string appPassword = ConfigurationManager.AppSettings["AppPassword"];
                        SendEmail(recipientEmail, "Mật khẩu mới", $"Mật khẩu mới của bạn là: {newPassword}", senderEmail, appPassword);

                        TempData["Message"] = "Mật khẩu mới đã được gửi đến email của bạn.";
                        return RedirectToAction("Login");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Cấp lại mật khẩu không thành công. Vui lòng thử lại sau.");
                        Console.WriteLine($"Error resetting password: {ex.Message}");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập không tồn tại.");
                }
            }
            return View(model);
        }

        private void SendEmail(string recipientEmail, string subject, string body, string senderEmail, string appPassword)
        {
            try
            {
                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress(senderEmail);
                    mail.To.Add(recipientEmail);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    using (var smtp = new SmtpClient("smtp.gmail.com"))
                    {
                        smtp.Port = 465; // Cổng SMTP của nhà cung cấp email của bạn
                        smtp.Credentials = new NetworkCredential(senderEmail, appPassword);
                        smtp.EnableSsl = true;

                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }


    }
}