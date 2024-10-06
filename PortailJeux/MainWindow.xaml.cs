using PortailJeux.Jeux;
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


namespace PortailJeux
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<InterfaceJeux> _jeux;

        public MainWindow()
        {
            InitializeComponent();
            ChargerJeux();
            BoutonJeux();
        }

        private void ChargerJeux()
        {
            _jeux = new List<InterfaceJeux>
                {
                    new morpions(),
                    new Puissance4()
                };
        }

        private void BoutonJeux()
        {
            foreach (var jeu in _jeux)
            {
                Button button = new Button
                {
                    Content = jeu.Nom,
                    Margin = new Thickness(5)
                };
                button.Click += (sender, e) => jeu.Demarrer();
                JeuxPanel.Children.Add(button);
            }
        }

        public void NavigateToFenetre(Window window)
        {
            window.Show();
        }
    }
}
