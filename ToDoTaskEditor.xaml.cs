using System.Windows;
using System.Windows.Controls;
using WpfShowcaseCenter.HelperClasses;
using WpfShowcaseCenter.Models;

namespace WpfShowcaseCenter
{
    /// <summary>
    /// Interaction logic for ToDoTaskEditor.xaml
    /// </summary>
    public partial class ToDoTaskEditor : Page
    {
        public ToDoTaskEditor(ToDoTask task)
        {
            InitializeComponent();
            DataContext = task;
        }

        private void Button_UpdateTask(object sender, RoutedEventArgs e)
        {
            ToDoTaskManager.Instance.SaveTasks();
            NavigationService?.GoBack();
        }
    }
}
