using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ToDoList.Context;
using ToDoList.ViewModel;

namespace ToDoList.View
{
    /// <summary>
    /// Interaction logic for TaskManagerView.xaml
    /// </summary>
    public partial class TaskManagerView : Window
    {
        public TaskManagerView(TaskManagerViewModel viewModel)
        {
            viewModel.Initialize();
            this.DataContext = viewModel;
            InitializeComponent();
        }
    }
}
