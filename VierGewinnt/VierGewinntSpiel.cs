﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace VierGewinnt 
{
    [Serializable()]
    class VierGewinntSpiel
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
            if (!feld.spielende() && feld.gueltigerZug(spalte))
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
            return feld.gueltigerZug(spalte);
        }

        public Boolean spielende()
        {
            return feld.spielende();
        }

        public Spieler getGewinner()
        {
            return feld.gewinner;
        }

        public void speichern()
        {
            StringBuilder fileText = new StringBuilder();
            fileText.AppendLine(spieler[0].Name + "|" + spieler[0].Farbe.R + "|" + spieler[0].Farbe.G + "|" + spieler[0].Farbe.B);
            fileText.AppendLine(spieler[1].Name + "|" + spieler[1].Farbe.R + "|" + spieler[1].Farbe.G + "|" + spieler[1].Farbe.B);
            foreach(Spieler spieler1 in feld.feld)
            {
                if(spieler1 == spieler[0])
                {
                    fileText.AppendLine("1");
                }
                else if(spieler1 == spieler[1])
                {
                    fileText.AppendLine("2");
                }else
                {
                    fileText.AppendLine("0");
                }
            }


            System.IO.File.WriteAllLines(@"C:\Users\SR43_9\Desktop\Save.txt", new string[] { fileText.ToString() });

            //IFormatter formatter = new BinaryFormatter();
            //Stream stream = new FileStream("speicherstand.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            //formatter.Serialize(stream, this);
            //stream.Close();
        }

        public void laden()
        {

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\SR43_9\Desktop\Save.txt");

            
            Feld feld = new Feld();


            //IFormatter formatter = new BinaryFormatter();
            //Stream stream = new FileStream("speicherstand.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            //VierGewinntSpiel geladenesSpiel = 
            //    (VierGewinntSpiel)formatter.Deserialize(new FileStream("speicherstand.bin", FileMode.Create, FileAccess.Write, FileShare.None));
            //stream.Close();

            //this.feld = geladenesSpiel.feld;
            //this.spieler = geladenesSpiel.spieler;
        }

        public Feld kloneFeld()
        {
            Feld f = new Feld();
            f.gewinner = feld.gewinner;

            for (int i = 0; i < feld.feld.GetLength(0); i++)
            {
                for (int j = 0; j < feld.feld.GetLength(1); j++)
                {
                    f.feld[i, j] = feld.feld[i, j];
                }
            }
            return f;
        }
    }
}
