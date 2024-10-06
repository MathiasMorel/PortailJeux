using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace PortailJeux.Jeux
{
    internal class morpions : InterfaceJeux
    {
        public string Nom => "Morpion";

        public void Demarrer()
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.NavigateToFenetre(new FenetreMorpions());
        }
    }
}
