using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using ToDoList.Context;
using ToDoList.Interface;
using ToDoList.Models;

namespace ToDoList.Repository
{
    public class TaskRepositoryAsync : IRepositoryAsync<MyTask>
    {
        private readonly MyTaskDbContext _dbContext;
        public TaskRepositoryAsync(MyTaskDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(MyTask entity) 
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();        
        }

        public async Task<ICollection<MyTask>> GetAllAsync() => await _dbContext.Tasks.ToListAsync();

        public async Task<MyTask> GetByIdAsync(int id) => await _dbContext.Tasks.FirstOrDefaultAsync(x=> x.Id == id);

        public async Task RemoveAsync(MyTask entity)
        {
            _dbContext.Tasks.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveByIdAsync(int id)
        {
            var entity = await _dbContext.Tasks.FirstOrDefaultAsync(x=> x.Id == id);
            _dbContext.Tasks.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(int oldId, MyTask entity)
        {
            var toUpdate = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == oldId);
            toUpdate.Name = entity.Name;
            toUpdate.Description = entity.Description;
            toUpdate.TaskStatus = entity.TaskStatus;
            
            await _dbContext.SaveChangesAsync();
        }
    }
}
