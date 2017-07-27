using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VierGewinnt
{
    public class VierGewinntSpiel
    {
        public Feld feld { get; private set; }
        private Spieler[] spieler;

        public VierGewinntSpiel(Spieler s1, Spieler s2)
        {
            feld = new Feld();
            spieler = new Spieler[2] { s1, s2 };
        }

        public Boolean setzeChip(int spalte, Spieler spieler)
        {
            if (feld.gueltigerZug(spalte))
            {
                feld.setzeChip(spalte, spieler);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean gueltigerZug(int spalte)
        {
            return this.feld.gueltigerZug(spalte);
        }

        /*public Boolean spielende()
        {
            return feld.spielende();
        }*/

        /*public Spieler getGewinner()
        {
            return feld.getGewinner();
        }*/

        public void speichern()
        {

        }

        public void laden()
        {

        }
    }
}
