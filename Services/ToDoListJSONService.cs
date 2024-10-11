using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WpfShowcaseCenter.Models;

namespace WpfShowcaseCenter.Services
{
    class ToDoListJSONService
    {
        private readonly string _filePath;

        public ToDoListJSONService(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<List<ToDoTask>> ReadTasksAsync()
        {
            if (!File.Exists(_filePath))
            {
                return new List<ToDoTask>();
            }

            using (var stream = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
            {
                return await JsonSerializer.DeserializeAsync<List<ToDoTask>>(stream)
                       ?? new List<ToDoTask>();
            }
        }

        public async Task WriteTasksAsync(IEnumerable<ToDoTask> tasks)
        {
            using (var stream = new FileStream(_filePath, FileMode.Create, FileAccess.Write))
            {
                await JsonSerializer.SerializeAsync(stream, tasks.ToList()); // Convert to List if necessary
            }
        }
    }
}
