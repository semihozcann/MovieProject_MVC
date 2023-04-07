using DataAccess.Conctere.EntityFramework.Mapping;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Conctere.EntityFramework.Context
{
    public class MovieProjectContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {


        public MovieProjectContext()
        {

        }

        //configuration from settings
        public MovieProjectContext(DbContextOptions<MovieProjectContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=DESKTOP-5R6CJJ3\SQLEXPRESS;Database=MovieProjectDb;Trusted_Connection=true");

            }
            base.OnConfiguring(optionsBuilder);



        }

        public DbSet<Category> Categories { get; set; }


        //db kurallarını burada db olusturken veriyoruz. 
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new RoleMap());
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new UserTokenMap());
            builder.ApplyConfiguration(new UserRoleMap());
            builder.ApplyConfiguration(new UserLoginMap());
            builder.ApplyConfiguration(new RoleClaimMap());
            builder.ApplyConfiguration(new UserClaimMap());

            builder.ApplyConfiguration(new CategoryMap());



        }

    }
}
