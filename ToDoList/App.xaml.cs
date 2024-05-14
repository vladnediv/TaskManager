using System.Configuration;
using System.Data;
using System.Windows;
using ToDoList.Infrastructure;
using ToDoList.View;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            AppServiceProvider.Initialize();
            var window = (TaskManagerView)AppServiceProvider.ServiceProvider.GetService(typeof(TaskManagerView));
            window.Show();
        }
    }

}
