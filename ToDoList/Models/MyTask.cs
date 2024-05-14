using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class MyTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MyTaskStatus TaskStatus { get; set; }
    }

    public enum MyTaskStatus { New, InProcess, Finished }
}
