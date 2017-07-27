using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VierGewinnt
{
    [Serializable()]
    public class Feld
    {
        public Spieler[,] feld { get; private set; }
        public Spieler gewinner { get; set; }

        public Feld()
        {
            feld = new Spieler[7, 7];

            // Zeile, Spalte
            // 0,0 ist unten links
        }


        public void setzeChip(int spalte, Spieler spieler)
        {
            // Zeile finden
            bool gesetzt = false;

            for (int i = 0; i < feld.GetLength(0) && !gesetzt; i++)
            {
                if (feld[i, spalte] == null)
                {
                    // einfügen
                    feld[i, spalte] = spieler;
                    gesetzt = true;
                }
            }
        }

        public Boolean gueltigerZug(int spalte)
        {
            return (feld[feld.GetLength(0) - 1, spalte] == null);
        }

        public Boolean spielende()
        {
            if (!zuegeMöglich())
                return false;

            for (int i = 0; i < feld.GetLength(0); i++)
            {
                for (int j = 0; j < feld.GetLength(1); j++)
                {
                    if (checkUmgebung(i, j))
                    {
                        gewinner = feld[i, j];
                        return true;
                    }
                }
            }
            return false;
        }

        private Boolean checkUmgebung(int zeile, int spalte)
        {
            int anz;

            if (feld[zeile, spalte] != null)
            {
                // Unten
                anz = 0;
                for (int i = zeile - 1; i >= 0 && i > zeile - 4; i--)
                {
                    if (feld[zeile, spalte] == feld[i, spalte])
                        anz++;
                    else
                        anz = 0;
                }
                if (anz == 3) return true;

                // Oben 
                anz = 0;
                for (int i = zeile + 1; i < feld.GetLength(0) && i < zeile + 4; i++)
                {
                    if (feld[zeile, spalte] == feld[i, spalte])
                        anz++;
                    else
                        anz = 0;
                }
                if (anz == 3) return true;

                // Links 
                anz = 0;
                for (int i = spalte - 1; i >= 0 && i > spalte - 4; i--)
                {
                    if (feld[zeile, spalte] == feld[zeile, i])
                        anz++;
                    else
                        anz = 0;
                }
                if (anz == 3) return true;

                // Rechts 
                anz = 0;
                for (int i = spalte + 1; i < feld.GetLength(1) && i < zeile + 4; i++)
                {
                    if (feld[zeile, spalte] == feld[zeile, i])
                        anz++;
                    else
                        anz = 0;
                }
                if (anz == 3) return true;

                // Diagonal 

                // Unten Rechts
                anz = 0;
                int s = spalte + 1;
                int z = zeile - 1;
                while (s < feld.GetLength(1) && s < spalte + 4 && z >= 0 && z > zeile - 4)
                {
                    if (feld[zeile, spalte] == feld[z, s])
                        anz++;
                    else
                        anz = 0;
                    z--;
                    s++;
                }
                if (anz == 3) return true;

                // Oben Rechts
                anz = 0;
                s = spalte + 1;
                z = zeile + 1;
                while (s < feld.GetLength(1) && s < spalte + 4 && z < feld.GetLength(0) && z < spalte + 4)
                {
                    if (feld[zeile, spalte] == feld[z, s])
                        anz++;
                    else
                        anz = 0;
                    z++;
                    s++;
                }
                if (anz == 3) return true;

                // Unten Links
                anz = 0;
                s = spalte - 1;
                z = zeile - 1;
                while (s >= 0 && s > spalte - 4 && z >= 0 && z > zeile - 4)
                {
                    if (feld[zeile, spalte] == feld[z, s])
                        anz++;
                    else
                        anz = 0;
                    z--;
                    s--;
                }
                if (anz == 3) return true;

                // Oben Links
                anz = 0;
                s = spalte - 1;
                z = zeile + 1;
                while (s >= 0 && s > spalte - 4 && z < feld.GetLength(0) && z < zeile + 4)
                {
                    if (feld[zeile, spalte] == feld[z, s])
                        anz++;
                    else
                        anz = 0;
                    z++;
                    s--;
                }
                if (anz == 3) return true;
            }
            return false;
        }

        private Boolean zuegeMöglich()
        {
            for (int i = 0; i < feld.GetLength(0); i++)
            {
                if (gueltigerZug(i))
                    return true;
            }
            return false;
        }
    }
}
