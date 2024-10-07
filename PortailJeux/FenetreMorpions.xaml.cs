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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PortailJeux
{
    public partial class FenetreMorpions : Window
    {
        private Button[,] buttons;
        private bool isPlayerXTurn = true;
        private int scoreX = 0;
        private int scoreO = 0;
        public FenetreMorpions()
        {
            InitializeComponent();
            InitializeGameBoard();
        }

        private void InitializeGameBoard()
        {
            buttons = new Button[3, 3];

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Button button = new Button
                    {
                        FontSize = 32
                    };
                    button.Click += Button_ClickMorpions;
                    Grid.SetRow(button, row + 1); // Ajuster l'indice de ligne
                    Grid.SetColumn(button, col);
                    buttons[row, col] = button;
                    GameGrid.Children.Add(button); // Ajoute le bouton à la grille
                }
            }   
        }

        private void Button_ClickMorpions(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button.Content != null) 
                return;
            button.Content = isPlayerXTurn ? "X" : "O";
            TourJoueur.Text = isPlayerXTurn ? "O" : "X";
            AnimateButton(button);
            CheckWinMorpion();
            isPlayerXTurn = !isPlayerXTurn;
        }

        private void AnimateButton(Button button)
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };
            button.BeginAnimation(Button.OpacityProperty, animation);
        }

        private void Button_ClickReinitialiser(object sender, RoutedEventArgs e)
        {
            foreach (Button button in buttons)
            {
                button.Content = null;
                button.IsEnabled = true;
                TourJoueur.Text = "X";
                
            }
        }
        private void CheckWinMorpion()
        {
            for (int i = 0; i < 3; i++)
            {
                if (buttons[i, 0].Content != null && buttons[i, 0].Content == buttons[i, 1].Content && buttons[i, 1].Content == buttons[i, 2].Content)
                {
                    Winner(buttons[i, 0].Content.ToString());

                    return;
                }
                if (buttons[0, i].Content != null && buttons[0, i].Content == buttons[1, i].Content && buttons[1, i].Content == buttons[2, i].Content)
                {
                    Winner(buttons[0, i].Content.ToString());
                    return;
                }
            }
            if (buttons[0, 0].Content != null && buttons[0, 0].Content == buttons[1, 1].Content && buttons[1, 1].Content == buttons[2, 2].Content)
            {
                Winner(buttons[0, 0].Content.ToString());
                return;
            }
            if (buttons[0, 2].Content != null && buttons[0, 2].Content == buttons[1, 1].Content && buttons[1, 1].Content == buttons[2, 0].Content)
            {
                Winner(buttons[0, 2].Content.ToString());
                return;
            }
        }
        private void Button_ClickRetour(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Winner(string winner)
        {
            TourJoueur.Text = $"Victoire de {winner}";
            if (winner == "X")
            {
                scoreX++;
            }
            else
            {
                scoreO++;
            }
            Score.Text = $"Score: {scoreX} - {scoreO}";
            foreach (Button button in buttons)
            {
                button.IsEnabled = false;
            }
        }

    }
}
