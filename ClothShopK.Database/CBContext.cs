﻿using ClothShopK.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothShopK.Database
{
    public class CBContext : DbContext, IDisposable
    {
        public CBContext() : base("ClothShopKConnection")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
