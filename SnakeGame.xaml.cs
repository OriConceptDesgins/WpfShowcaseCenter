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
using System.Windows.Threading;
using WpfShowcaseCenter.HelperClasses;

namespace WpfShowcaseCenter
{
    /// <summary>
    /// Interaction logic for SnakeGame.xaml
    /// </summary>
    public partial class SnakeGame : Page
    {
        private const int SquareSize = 20;
        private readonly List<Point> snake = new List<Point>();
        private Point food;
        private Vector direction;
        private bool gameOver = false;

        public SnakeGame()
        {

            InitializeComponent();
            InitializeGame();
            GameCanvas.KeyDown += SnakeGame_KeyDown;
            GameCanvas.Focus();
        }

        private void InitializeGame()
        {
            gameOver = false ;
            snake.Clear();
            snake.Add(new Point(5, 5)); // Starting position
            direction = new Vector(1, 0); // Initial direction
            GenerateFood();
            TimerManager.Instance.StartTimer(TimeSpan.FromMilliseconds(150), Timer_Tick);
        }

        private void SnakeGame_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    if (direction.Y == 0) direction = new Vector(0, -1);
                    break;
                case Key.Down:
                    if (direction.Y == 0) direction = new Vector(0, 1);
                    break;
                case Key.Left:
                    if (direction.X == 0) direction = new Vector(-1, 0);
                    break;
                case Key.Right:
                    if (direction.X == 0) direction = new Vector(1, 0);
                    break;
            }
            
        }

        private void Timer_Tick()
        {
            if (gameOver) return;
            MoveSnake();
            DrawGame();
            CheckCollisions();

        }

        private void MoveSnake()
        {
            var head = snake[0];
            var newHead = new Point(head.X + direction.X, head.Y + direction.Y);
            snake.Insert(0, newHead);
            if (newHead == food)
            {
                GenerateFood(); // Eat food
            }
            else
            {
                snake.RemoveAt(snake.Count - 1); // Remove tail
            }
        }

        private void CheckCollisions()
        {
            var head = snake[0];
            // Check wall collisions
            if (head.X < 0 || head.X >= GameCanvas.ActualWidth / SquareSize ||
                head.Y < 0 || head.Y >= GameCanvas.ActualHeight / SquareSize)
            {
                EndGame();
            }
            // Check self-collision
            for (int i = 1; i < snake.Count; i++)
            {
                if (head == snake[i])
                {
                    EndGame();
                    break;
                }
            }
        }

        private void EndGame()
        {
            gameOver = true;
            TimerManager.Instance.StopTimer();
            MessageBox.Show("Game Over!");
            InitializeGame(); // Optionally restart the game
        }

        private void GenerateFood()
        {
            Random rand = new Random();
            food = new Point(rand.Next((int)(GameCanvas.ActualWidth / SquareSize)),
                             rand.Next((int)(GameCanvas.ActualHeight / SquareSize)));
        }

        private void DrawGame()
        {
            GameCanvas.Children.Clear();
            foreach (var segment in snake)
            {
                var rect = new Rectangle
                {
                    Width = SquareSize,
                    Height = SquareSize,
                    Fill = Brushes.Green
                };
                Canvas.SetLeft(rect, segment.X * SquareSize);
                Canvas.SetTop(rect, segment.Y * SquareSize);
                GameCanvas.Children.Add(rect);
            }
            // Draw food
            var foodRect = new Rectangle
            {
                Width = SquareSize,
                Height = SquareSize,
                Fill = Brushes.Red
            };
            Canvas.SetLeft(foodRect, food.X * SquareSize);
            Canvas.SetTop(foodRect, food.Y * SquareSize);
            GameCanvas.Children.Add(foodRect);
        }

    }
}
