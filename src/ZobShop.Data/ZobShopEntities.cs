﻿using Microsoft.AspNet.Identity.EntityFramework;
using ZobShop.Models;

namespace ZobShop.Data
{
    public class ZobShopEntities : IdentityDbContext<User>
    {
        public ZobShopEntities()
            : base("ZobShopDb", throwIfV1Schema: false)
        {
        }

        public static ZobShopEntities Create()
        {
            return new ZobShopEntities();
        }
    }
}
