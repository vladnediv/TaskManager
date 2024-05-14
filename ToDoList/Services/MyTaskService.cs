using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.Repository;

namespace ToDoList.Services
{
    public class MyTaskService
    {
        private readonly TaskRepositoryAsync _taskRepository;
        public MyTaskService(TaskRepositoryAsync taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task AddTaskAsync(MyTask task) => await _taskRepository.AddAsync(task);

        public async Task<ICollection<MyTask>> GetAllTasksAsync() => await _taskRepository.GetAllAsync();

        public async Task<MyTask> GetTaskByIdAsync(int id) => await _taskRepository.GetByIdAsync(id);

        public async Task RemoveTaskAsync(MyTask task) => await _taskRepository.RemoveAsync(task);

        public async Task RemoveTaskByIdAsync(int id) => await _taskRepository.RemoveByIdAsync(id);

        public async Task UpdateTaskAsync(int oldId, MyTask task) => await _taskRepository.UpdateAsync(oldId, task);
    }
}
