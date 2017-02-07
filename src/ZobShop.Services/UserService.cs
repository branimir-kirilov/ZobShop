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
            this.repository = repository;
        }

        public IEnumerable<User> GetUsers()
        {
            return this.repository
                .Entities
                .ToList();
        }
    }
}
