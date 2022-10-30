using System;
using System.Data;
using System.Reflection.Emit;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;
using test_npp_api.EF_entities;

namespace test_npp_api.Data
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Tool_User> Tool_User { get; set; }

        public Context(DbContextOptions<Context> options)
        : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            Console.WriteLine("COntext create c");
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        

            modelBuilder.Entity<User>().HasData(
            new User[]
            {
                new User{Id = 1, FirstName = "Калугина", LastName="Анастасия", MiddleName="Матвеевна"},
                new User{Id = 2, FirstName = "Григорьев", LastName="Арсений", MiddleName="Викторович"},
                new User{Id = 3, FirstName = "Назарова", LastName="Ева", MiddleName="Константиновна"},
                new User{Id = 4, FirstName = "Сазонова", LastName="Маргарита", MiddleName="Егоровна"},
            });

            modelBuilder.Entity<Tool>().HasData(
            new Tool[]
            {
                new Tool{
                    Id = 1,
                    Name= "Ключ",
                    Count=10
                },
                 new Tool{
                    Id = 2,
                    Name= "Мощимер",
                    Count=3
                },
                new Tool{
                    Id = 3,
                    Name= "Устройстов 1",
                    Count=10
                },
                new Tool{
                    Id = 4,
                    Name= "Устройстов 2",
                    Count=5
                }
            });
        }
    }
}

