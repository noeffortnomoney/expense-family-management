using System;
using System.Collections.Generic;
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

    }
}