using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VierGewinnt
{
    public class Feld
    {
        public Spieler[,] feld { get; private set; }
        //private Spieler gewinner;

        public Feld()
        {
            feld = new Spieler[7, 7];
            
            // Zeile, Spalte
            // 0,0 ist unten links
        }

        
        public void setzeChip(int spalte, Spieler spieler)
        {
            // Zeile finden
            for (int zeile = 0; zeile < feld.GetLength(0); zeile++)
            {
                if (feld[zeile, spalte] == null)
                {
                    // einfügen
                    feld[zeile, spalte] = spieler;
                    return;
                }
            }
        }

        public Boolean gueltigerZug(int spalte)
        {
            return (feld[feld.GetLength(0) - 1, spalte] == null);
        }

        /*public Boolean spielende()
        {
            // Horizontal
            for (int i = 0; i < feld.GetLength(0); i++)
            {
                int anz = 0;
                for (int j = 0; j < feld.GetLength(1); i += 2)
                {
                    if (feld[i, j] == feld[i, j+1])
                    {
                        anz += 1;
                    }
                    else
                    {
                        anz = 0;
                    }
                    if (anz > 4) return 
                }
            }
        }*/

        /*public Spieler getGewinner()
        {
            return gewinner;
        }*/


    }
}
