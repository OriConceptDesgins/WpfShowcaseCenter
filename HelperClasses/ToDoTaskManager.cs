using System.Collections.ObjectModel;
using System.ComponentModel;
using WpfShowcaseCenter.Models;
using WpfShowcaseCenter.Services;

namespace WpfShowcaseCenter.HelperClasses
{
    public class ToDoTaskManager: INotifyPropertyChanged
    {
        
        private static ToDoTaskManager? _instance;

        public static ToDoTaskManager Instance => _instance ??= new ToDoTaskManager();

        public ObservableCollection<ToDoTask> Tasks { get; } = new ObservableCollection<ToDoTask>();

        private readonly ToDoListJSONService _toDoListJSONService;

        private ToDoTaskManager()
        {
            _taskDescription = "";
            _toDoListJSONService = new ToDoListJSONService("tasks.json");
            LoadTasks();
        }

        public async void LoadTasks()
        {

            try
            {
                List<ToDoTask> tasks = await _toDoListJSONService.ReadTasksAsync();

                if (tasks?.Any() == true)
                {
                    foreach (ToDoTask task in tasks)
                    {
                        Tasks.Add(task); 
                    }
                } // If tasks is null or empty, do nothing
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading tasks: {ex.Message}");
            }
        }

        public async void SaveTasks()
        {
            if (Tasks?.Any() == true)
            {
                await _toDoListJSONService.WriteTasksAsync(Tasks);
            }
        }

        /// <summary>
        /// Model binding part of the singleton and I notify change implementation.
        /// </summary>
        private string _taskDescription;
        private int _selectedPriority;
        private DateTime? _deadline;

        public string TaskDescription
        {
            get => _taskDescription;
            set
            {
                if (_taskDescription != value)
                {
                    _taskDescription = value;
                    OnPropertyChanged(nameof(TaskDescription)); // Notify that the property has changed
                }
            }
        }

        public int SelectedPriority
        {
            get => _selectedPriority;
            set
            {
                _selectedPriority = value;
                OnPropertyChanged(nameof(SelectedPriority));
            }
        }

        public DateTime? Deadline
        {
            get => _deadline;
            set
            {
                _deadline = value;
                OnPropertyChanged(nameof(Deadline));
            }
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
