using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Services;

namespace ToDoList.ViewModel
{
    public class TaskManagerViewModel : BaseViewModel
    {
        private readonly MyTaskService _taskService;

        public TaskManagerViewModel(MyTaskService myTaskService)
        {
            _taskService = myTaskService;


        }
    }
}
