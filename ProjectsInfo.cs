using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfShowcaseCenter
{
    class ProjectsInfo
    {

        // Dictionary to store data for each icon
        private static readonly Dictionary<string, (string ImageSource, string Description)> iconData = new()
        {
            { "ToDo List", ("/Images/ToDoListWhite.png", "This is a To do list app.") },
            { "Placeholder Icon", ("/Images/PlaceholderIcon.png", "This is a placeholder icon.") },
            { "Snake Game", ("/Images/SnakeGameIcon.png", "Play the classic Snake game.") },
            { "Tetris", ("/Images/TetrisImage.png", "Play the classic Tetris game.") },
            { "Tic Tac Toe", ("/Images/TicTacToeImage.png", "Play Tic Tac Toe.") },
            { "Memory Game", ("/Images/MemoryGameImage.png", "A memory matching game.") }
        };

        // Method to get data based on the key
        public static bool TryGetIconData(string key, out (string ImageSource, string Description) data)
        {
            return iconData.TryGetValue(key, out data);
        }
    }
}
