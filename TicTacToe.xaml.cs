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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfShowcaseCenter
{
    /// <summary>
    /// Interaction logic for TicTacToe.xaml
    /// </summary>
    public partial class TicTacToe : Page
    {
        private string currentPlayer = "X"; // Current player
        private string[,] board = new string[3, 3]; // Game board

        public TicTacToe()
        {
            InitializeComponent();
            ResetGame();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button.Content == null) // Check if button is empty
            {
                button.Content = currentPlayer; // Set button content to current player
                UpdateBoard(button.Name);
                if (CheckForWinner())
                {
                    StatusText.Text = $"Player {currentPlayer} Wins!";
                    DisableButtons();
                }
                else if (IsBoardFull())
                {
                    StatusText.Text = "It's a Draw!";
                }
                else
                {
                    currentPlayer = currentPlayer == "X" ? "O" : "X"; // Switch player
                    StatusText.Text = $"Player {currentPlayer}'s Turn";
                }
            }
        }

        private void UpdateBoard(string buttonName)
        {
            int row = int.Parse(buttonName[6].ToString());
            int col = int.Parse(buttonName[7].ToString());
            board[row, col] = currentPlayer;
        }

        private bool CheckForWinner()
        {
            // Check rows, columns, and diagonals for a winner
            for (int i = 0; i < 3; i++)
            {
                if ((board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) ||
                    (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer))
                {
                    return true;
                }
            }

            // Check diagonals
            if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
                (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
            {
                return true;
            }

            return false;
        }

        private bool IsBoardFull()
        {
            foreach (var cell in board)
            {
                if (cell == null)
                    return false;
            }
            return true;
        }

        private void DisableButtons()
        {
            foreach (var child in this.FindVisualChildren<Button>())
            {
                child.IsEnabled = false;
            }
        }

        private void ResetGame()
        {
            currentPlayer = "X";
            board = new string[3, 3];
            StatusText.Text = "Player X's Turn";

            foreach (var child in this.FindVisualChildren<Button>())
            {
                child.Content = null;
                child.IsEnabled = true;
            }
        }

        // Helper method to find visual children (for disabling buttons)
        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}
}
