using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Context
{
    public class MyTaskDbContext : DbContext
    {
        public MyTaskDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();
            string connectionString = configuration.GetConnectionString("TaskManagerDb");

            optionsBuilder.UseSqlServer(connectionString);
        }


        public DbSet<MyTask> Tasks { get; set; }
    }
}
