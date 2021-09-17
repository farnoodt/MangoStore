﻿using Microsoft.EntityFrameworkCore;
using Mango.Services.ShoppingCartAPI.Models;

namespace Mango.Services.ShoppingCartAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> products { get; set; }
        public DbSet<CartHeader> CartHeaders{ get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }
    }
}
