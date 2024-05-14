using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.ViewModel
{
    public class TaskManagerViewModel : BaseViewModel
    {
        private readonly MyTaskService _taskService;

        public TaskManagerViewModel(MyTaskService myTaskService)
        {
            _taskService = myTaskService;
            TasknameInput = "";
            DescriptionInput = "";
            AddTaskCommand = new AsyncRelayCommand(AddTaskAsync);
            UpdateTaskCommand = new AsyncRelayCommand(UpdateTaskAsync);
            RemoveTaskCommand = new AsyncRelayCommand(RemoveTaskAsync);
        }
        public async Task Initialize()
        {
            TaskCollection = new ObservableCollection<Models.MyTask>(await _taskService.GetAllTasksAsync());
        }

        //Add Task
        private string _TasknameInput;
        public string TasknameInput { get { return _TasknameInput; } set { _TasknameInput = value; OnPropertyChanged(); } }


        private string _DescriptionInput;
        public string DescriptionInput { get { return _DescriptionInput; } set { _DescriptionInput = value; OnPropertyChanged(); } }

        public ComboBoxItem SelectedStatus { get; set; }

        public ICommand AddTaskCommand { get; }
        private async Task AddTaskAsync()
        {
            var result = await Task<bool>.Run(() => { if (TasknameInput.Length > 0 && DescriptionInput.Length > 0 && SelectedStatus != null) return true; else return false; });
            if(result)
            {
                bool status = SelectedStatus.Content == "New";
                MyTaskStatus taskStatus;
                if (status)
                {
                    taskStatus = MyTaskStatus.New;
                }
                else taskStatus = MyTaskStatus.Finished;
                var task = new Models.MyTask() { Name = TasknameInput, Description = DescriptionInput, TaskStatus = taskStatus };
                await _taskService.AddTaskAsync(task);
                TaskCollection.Add(task);
            }
        }


        //Update/Remove Task
        private int _IdInput;
        public int IdInput { get { return _IdInput; } set { _IdInput = value; OnPropertyChanged(); } }
        public ICommand UpdateTaskCommand { get; }
        private async Task UpdateTaskAsync()
        {
            var result = await Task<bool>.Run(() => { if (TasknameInput.Length > 0 && DescriptionInput.Length > 0 && SelectedStatus != null) return true; else return false; });
            if (result)
            {
                bool status = SelectedStatus.Content == "New";
                MyTaskStatus taskStatus;
                if (status)
                {
                    taskStatus = MyTaskStatus.New;
                }
                else taskStatus = MyTaskStatus.Finished;
                var task = new Models.MyTask() { Name = TasknameInput, Description = DescriptionInput, TaskStatus = taskStatus };
                await _taskService.UpdateTaskAsync(IdInput, task);
                await Initialize();
            }
        }


        public ICommand RemoveTaskCommand { get; }
        private async Task RemoveTaskAsync()
        {
            var result = await Task<bool>.Run(() => { if (IdInput != null) return true; else return false; });
            if (result)
            {
                await _taskService.RemoveTaskByIdAsync(IdInput);
            }
            await Initialize();
        }

        //Show Tasks
        private ObservableCollection<Models.MyTask> _TaskCollection;
        public ObservableCollection<Models.MyTask> TaskCollection { get { return _TaskCollection; } set { _TaskCollection = value; OnPropertyChanged(); } }
    }
}
