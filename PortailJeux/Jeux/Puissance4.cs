using PortailJeux.Jeux;
using System.Windows;

namespace PortailJeux
{
    internal class Puissance4 : InterfaceJeux
    {
        public string Nom => "Puissance 4";
        public void Demarrer()
        {
            MessageBox.Show("Démarrage du jeu du Puissance 4");
        }
    }
}