using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VierGewinnt
{
    public class Feld
    {
        public Spieler[,] Feld { get; private set; }
        public Spieler Gewinner { get; set; }

        public Feld()
        {
            Feld = new Spieler[7, 7];

            // Zeile, Spalte
            // 0,0 ist unten links
        }


        public void setzeChip(int spalte, Spieler spieler)
        {
            // Zeile finden
            bool gesetzt = false;

            for (int i = 0; i < Feld.GetLength(0) && !gesetzt; i++)
            {
                if (Feld[i, spalte] == null)
                {
                    // einfügen
                    Feld[i, spalte] = spieler;
                    gesetzt = true;
                }
            }
        }

        public Boolean gueltigerZug(int spalte)
        {
            return (Feld[Feld.GetLength(0) - 1, spalte] == null);
        }

        public Boolean spielende()
        {
            if (!zuegeMöglich())
                return false;

            for (int i = 0; i < Feld.GetLength(0); i++)
            {
                for (int j = 0; j < Feld.GetLength(1); j++)
                {
                    if (checkUmgebung(i, j))
                    {
                        Gewinner = Feld[i, j];
                        return true;
                    }
                }
            }
            return false;
        }

        private Boolean checkUmgebung(int zeile, int spalte)
        {
            int anz;

            if (Feld[zeile, spalte] != null)
            {
                // Unten
                anz = 0;
                for (int i = zeile - 1; i >= 0 && i > zeile - 4; i--)
                {
                    if (Feld[zeile, spalte] == Feld[i, spalte])
                        anz++;
                    else
                        anz = 0;
                }
                if (anz == 3) return true;

                // Oben 
                anz = 0;
                for (int i = zeile + 1; i < Feld.GetLength(0) && i < zeile + 4; i++)
                {
                    if (Feld[zeile, spalte] == Feld[i, spalte])
                        anz++;
                    else
                        anz = 0;
                }
                if (anz == 3) return true;

                // Links 
                anz = 0;
                for (int i = spalte - 1; i >= 0 && i > spalte - 4; i--)
                {
                    if (Feld[zeile, spalte] == Feld[zeile, i])
                        anz++;
                    else
                        anz = 0;
                }
                if (anz == 3) return true;

                // Rechts 
                anz = 0;
                for (int i = spalte + 1; i < Feld.GetLength(1) && i < zeile + 4; i++)
                {
                    if (Feld[zeile, spalte] == Feld[zeile, i])
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
                while (s < Feld.GetLength(1) && s < spalte + 4 && z >= 0 && z > zeile - 4)
                {
                    if (Feld[zeile, spalte] == Feld[z, s])
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
                while (s < Feld.GetLength(1) && s < spalte + 4 && z < Feld.GetLength(0) && z < spalte + 4)
                {
                    if (Feld[zeile, spalte] == Feld[z, s])
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
                    if (Feld[zeile, spalte] == Feld[z, s])
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
                while (s >= 0 && s > spalte - 4 && z < Feld.GetLength(0) && z < zeile + 4)
                {
                    if (Feld[zeile, spalte] == Feld[z, s])
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
            for (int i = 0; i < Feld.GetLength(0); i++)
            {
                if (gueltigerZug(i))
                    return true;
            }
            return false;
        }
    }
}
