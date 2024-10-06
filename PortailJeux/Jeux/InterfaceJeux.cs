using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortailJeux.Jeux
{
    public interface InterfaceJeux
    {
        string Nom { get; }
        void Demarrer();
    }
}
