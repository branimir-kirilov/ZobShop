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

        public UserService(IRepository<User> repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository cannot be null");
            }

            this.repository = repository;
        }

        public IEnumerable<User> GetUsers()
        {
            var result = this.repository
                .Entities
                .ToList();

            return result;
        }
    }
}
