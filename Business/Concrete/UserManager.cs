﻿using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;


namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userRepository.GetClaims(user);
        }

        public void Add(User user)
        {
            _userRepository.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userRepository.Get(u => u.Email == email);
        }
    }
}
