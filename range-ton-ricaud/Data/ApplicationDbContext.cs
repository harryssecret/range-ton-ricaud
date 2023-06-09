﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using range_ton_ricaud.Models;

namespace range_ton_ricaud.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<range_ton_ricaud.Models.Garage> Garage { get; set; } = default!;
        public DbSet<range_ton_ricaud.Models.Tool> Tool { get; set; } = default!;
        public DbSet<range_ton_ricaud.Models.ToolKeyword> ToolKeyword { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}