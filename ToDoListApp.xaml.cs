
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using WpfShowcaseCenter.HelperClasses;
using WpfShowcaseCenter.Models;

namespace WpfShowcaseCenter
{
    /// <summary>
    /// Interaction logic for ToDoListApp.xaml
    /// </summary>
    public partial class ToDoListApp : Page
    {
        ToDoTaskManager manager;

        public ToDoListApp()
        {
            InitializeComponent();
            DataContext = ToDoTaskManager.Instance; // Set DataContext to the singleton
            manager = ToDoTaskManager.Instance;
            manager.LoadTasks(); // Load tasks from the singleton
        }


        private void Button_AddToTaskList(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(manager.TaskDescription))
            {
                MessageBox.Show($"{manager.TaskDescription} Please enter a valid task description and priority (1-5).");
                return;
            }

            // Create a new ToDoTask
            ToDoTask newTask = new ToDoTask(manager.SelectedPriority, manager.TaskDescription, manager.Deadline ?? DateTime.Now); // Use current date if no deadline

            // Add the new task to the singleton's task list
            manager.Tasks.Add(newTask);
            manager.SaveTasks();
            // Clear the input fields
            manager.TaskDescription = string.Empty; // Clear the task description
            manager.SelectedPriority = 0;           // Reset the priority
            manager.Deadline = null;                // Clear the deadline
        }

        private void Button_EditTask(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is ToDoTask task)
            {
                ToDoTaskEditor toDoTaskEditor = new ToDoTaskEditor(task); // Pass the task to edit
                NavigationService?.Navigate(toDoTaskEditor);
            }
        }

        private void Button_DeleteTask(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is ToDoTask task)
            {
                manager.Tasks.Remove(task); // Remove the task from the collection
                                                             // Optionally save changes
                manager.SaveTasks();
            }
        }

        private void Button_ClearTasks(object sender, RoutedEventArgs e)
        {
            manager.Tasks.Clear();
            manager.SaveTasks();
        }
    }
}
