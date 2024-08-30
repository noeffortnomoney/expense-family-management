using System;
using System.Collections.Generic;
using System.Linq;
using EFM.Common.Helpers;
using EFM.Model.Model;
using EFM.Repository.Infrastructure;
using EFM.Repository.Repositories;

namespace EFM.Service
{
    public interface IUserService
    {
        void Add(User user);

        void Update(User user);

        void Delete(int id);

        IEnumerable<User> GetAll();

        User GetById(int id);

        void SaveChanges();

        User AddUser(User user);

        User DeleteAccount(int id);

        bool ResetPassword(int userId, string newPassword);

        User GetUserByUserName(string userName);
        string GenerateNewPassword();
        //bool SendNewPasswordEmail(User user, string newPassword);
        void UpdateUserPassword(User user, string newPassword);
    }

    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this._userRepository = userRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(User user)
        {
            user.IsActived = true;  
            user.IsDeleted = false; 

            _userRepository.Add(user);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }

        public User AddUser(User user)
        {
            user.IsActived = true;   
            user.IsDeleted = false;
            user.CreatedDate = DateTime.Now;
            user.CreatedBy = 1; //tạm thời cho = 1 vì chưa phân quyền

            _userRepository.Add(user);
            SaveChanges();
            return user;
        }
        public User DeleteAccount(int id)
        {
            var user = _userRepository.GetById(id);

            if (user != null)
            {
                user.DeletedDate = DateTime.Now;
                user.DeletedBy = 1; 

                user.IsDeleted = true;
                user.IsActived = false;

                _userRepository.SoftDelete(id);

                SaveChanges();
            }

            return user;
        }
        public bool ResetPassword(int userId, string newPassword)
        {
            var user = _userRepository.GetSingleById(userId);
            if (user == null)
                return false;

            user.Password = newPassword; 
            user.UpdatedDate = DateTime.Now;
            user.UpdatedBy = 1; 

            _userRepository.Update(user);
            _unitOfWork.Commit();

            return true;
        }

        public User GetUserByUserName(string userName)
        {
            return _userRepository.GetUserByUserName(userName);
        }


        public string GenerateNewPassword()
        {
            // Tạo mật khẩu ngẫu nhiên, bạn có thể tùy chỉnh theo ý muốn
            return Guid.NewGuid().ToString().Substring(0, 8);
        }

        /*public bool SendNewPasswordEmail(User user, string newPassword)
        {
            var subject = "Mật khẩu mới của bạn";
            var content = $"Mật khẩu mới của bạn là: {newPassword}";

            return Mail.SendMail(user.Email, subject, content);
        }*/

        public void UpdateUserPassword(User user, string newPassword)
        {
            // Cập nhật mật khẩu mới (mã hóa mật khẩu nếu cần)
            user.Password = HashPassword(newPassword); // HashPassword là một phương thức giả định để mã hóa mật khẩu
            _userRepository.Update(user);
            _unitOfWork.Commit();
        }

        private string HashPassword(string password)
        {
            // Giả định bạn có một phương thức để hash mật khẩu
            // Bạn nên sử dụng một thư viện mã hóa mật khẩu như BCrypt hoặc PBKDF2
            return password; // Thay thế bằng mã hóa thực sự
        }

    }
}