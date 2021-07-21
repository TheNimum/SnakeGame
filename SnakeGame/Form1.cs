using SnakeGame.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{


    public partial class Form1 : Form
    {

        private List<GameModels> snake = new List<GameModels>();
        private GameModels Food = new GameModels();

        int MaxWidth;
        int MaxHeight;

        int score;
        int HighScore;

        Random rand = new Random();

        bool GoLeft, GoRight, GoUp, GoDown;


        public Form1()
        {
            InitializeComponent();

            new Settings(); 
        }

        
        private void StartButton(object sender, EventArgs e)
        {
            RestartGame();

        }
        private void RestartGame()
        {
            MaxWidth = Picture.Width / Settings.Width - 1;
            MaxHeight = Picture.Height / Settings.Height - 1;
            snake.Clear();

            Start.Enabled = false;
            score = 0;
            txtScore.Text = "Score: " + score;
            GameModels head = new GameModels { X = 10, Y = 5 };
            snake.Add(head);

            for (int i = 0; i < 100; i++)
            {
                GameModels body = new GameModels();
                snake.Add(body);
            }
            Food = new GameModels { X = rand.Next(2, MaxWidth), Y = rand.Next(2, MaxHeight)};

            GameTimer.Start();

        }
        private void EatFood()
        {
            score += 1;
            txtScore.Text = "Score: " + score;
            GameModels body = new GameModels
            {
                X = snake[snake.Count - 1].X,
                Y = snake[snake.Count - 1].Y
            };
            snake.Add(body);
            Food = new GameModels { X = rand.Next(2, MaxWidth), Y = rand.Next(2, MaxHeight) };

        }

        private void GameScreen(object sender, PaintEventArgs e)
        {
            Graphics screen = e.Graphics;
            Brush snakeColour;
            for (int i = 0; i < snake.Count; i++)
            {
                if (i == 0)
                {
                    snakeColour = Brushes.Black;
                }
                else
                {
                    snakeColour = Brushes.DarkGreen;
                }

                screen.FillEllipse(snakeColour, new Rectangle
                    (
                    snake[i].X * Settings.Height,
                    snake[i].Y * Settings.Width,
                    Settings.Width, Settings.Height
                    ));
            }
            screen.FillEllipse(Brushes.DarkRed, new Rectangle
                    (
                    Food.X * Settings.Height,
                    Food.Y * Settings.Width,
                    Settings.Width, Settings.Height
                    ));
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (GoLeft)
            {
                Settings.Direction = "left";
            }
            if (GoRight)
            {
                Settings.Direction = "right";
            }
            if (GoDown)
            {
                Settings.Direction = "down";
            }
            if (GoUp)
            {
                Settings.Direction = "up";
            }
            for (int i = snake.Count -1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.Direction)
                    {
                        case "left":
                            snake[i].X--;
                            break;
                        case "right":
                            snake[1].X++;
                            break;
                        case "down":
                            snake[i].Y++;
                            break;
                        case "up":
                            snake[i].Y--;
                            break;
                    }
                    if (snake[i].X < 0 )
                    {
                        snake[i].X = MaxWidth;
                    }
                    if (snake[i].X > MaxWidth)
                    {
                        snake[i].X = 0;
                    }
                    if (snake[i].Y < 0 )
                    {
                        snake[i].Y = MaxHeight;
                    }
                    if (snake[i].Y > MaxHeight)
                    {
                        snake[i].Y = 0;
                    }

                    if (snake[i].Y == Food.Y && snake[i].Y == Food.Y)
                    {
                        EatFood();
                    }
                    for (int j = 1; j < snake.Count; j++)
                    {
                        if (snake[i].X == snake[j].Y && snake[i].Y == snake[j].Y)
                        {
                            GameOver();
                        }
                    }
                }
                else
                {
                    snake[i].X = snake[i - 1].X;
                    snake[i].Y = snake[i - 1].Y;
                }
            }
            Picture.Invalidate();
        }

        private void GameOver()
        {

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Settings.Direction != "right")
            {
                GoLeft = true; 
            }
            if (e.KeyCode == Keys.Right && Settings.Direction != "left")
            {
                GoLeft = true; 
            }
            if (e.KeyCode == Keys.Up && Settings.Direction != "down")
            {
                GoLeft = true; 
            }
            if (e.KeyCode == Keys.Down && Settings.Direction != "up")
            {
                GoLeft = true; 
            }

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                GoLeft = false;
            }if (e.KeyCode == Keys.Right)
            {
                GoRight = false;
            }if (e.KeyCode == Keys.Up)
            {
                GoUp = false;
            }if (e.KeyCode == Keys.Down)
            {
                GoDown = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
