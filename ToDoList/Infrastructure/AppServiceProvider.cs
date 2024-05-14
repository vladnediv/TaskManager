using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Context;
using ToDoList.Repository;
using ToDoList.Services;
using ToDoList.View;
using ToDoList.ViewModel;

namespace ToDoList.Infrastructure
{
    public static class AppServiceProvider
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        public static void Initialize()
        {
            var services = new ServiceCollection();

            //Database
            services.AddDbContext<MyTaskDbContext>();

            //Repository
            services.AddTransient<TaskRepositoryAsync, TaskRepositoryAsync>();

            //Services
            services.AddTransient<MyTaskService, MyTaskService>();

            //Views
            services.AddTransient<TaskManagerView, TaskManagerView>();

            //ViewModels
            services.AddTransient<TaskManagerViewModel, TaskManagerViewModel>();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
