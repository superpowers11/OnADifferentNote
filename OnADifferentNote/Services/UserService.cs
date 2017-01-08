using System;
using OnADifferentNote.Repositories;

namespace OnADifferentNote.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User CreateUser(string email="NoEmail@none.none", string userName = "NoName", string password="NoPassword")
        {
            User newUser = new User();
            newUser.Username = userName;
            newUser.Password = password;
            newUser.Email = email;
            newUser.UserType = "Client"; //not admin
            newUser.UserDateCreated = DateTime.Today;
            _unitOfWork.UserRepository.Add(newUser);
            _unitOfWork.Save();
            return newUser;

        }
    }
}