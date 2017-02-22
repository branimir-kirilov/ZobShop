using System;
using System.Collections.Generic;
using System.Linq;
using ZobShop.Data.Contracts;
using ZobShop.Models;
using ZobShop.Services.Contracts;

namespace ZobShop.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> repository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IRepository<User> repository, IUnitOfWork unitOfWork)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository cannot be null");
            }

            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork cannot be null");
            }

            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<User> GetUsers()
        {
            var result = this.repository
                .Entities
                .ToList();

            return result;
        }

        public User GetById(string id)
        {
            var user = this.repository.GetById(id);

            return user;
        }

        public void DeleteUser(string id)
        {
            var user = this.repository.GetById(id);

            this.repository.Delete(user);
            this.unitOfWork.Commit();
        }
    }
}
