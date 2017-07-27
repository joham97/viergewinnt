using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace VierGewinnt
{
    [Serializable()]
    public class Spieler
    {
        public string Name { get; private set; }
        public Color Farbe { get; private set; }

        public Spieler(String name, Color farbe)
        {
            this.Name = name;
            this.Farbe = farbe;
        }

    }
}
