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

namespace VierGewinnt
{
    /// <summary>
    /// Interaktionslogik für VierGewinntSpielfeldUserControl.xaml
    /// </summary>
    public partial class SpielfeldUserControl : UserControl
    {

        public event TickHandler Tick;
        public EventArgs e = null;
        public delegate void TickHandler(int i, EventArgs e);

        public Feld feld { get; set; }

        public SpielfeldUserControl()
        {
            InitializeComponent();
            initFeld();
        }
        
        private void initFeld()
        {
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    int X = x;
                    int Y = y;
                    Console.WriteLine(x);
                    Ellipse ellipse = new Ellipse();
                    ellipse.Width = 90;
                    ellipse.Height = 90;
                    ellipse.Fill = new SolidColorBrush(Color.FromRgb((byte)200, (byte)200, (byte)200));
                    ellipse.MouseEnter += (obj, e) => { highlightColumn(X); };
                    ellipse.MouseLeave += (obj, e) => { notHighlightColumn(X); };
                    ellipse.MouseDown += (obj, e) => { Tick(X, e); };
                    grid.Children.Add(ellipse);
                    Grid.SetColumn(ellipse, x);
                    Grid.SetRow(ellipse, y);
                }
            }
        }

        private void highlightColumn(int x)
        {
            for (int y = 0; y < 7; y++)
            {
                if (feld.Feld[y, x] == null)
                {
                    getEllipse(y, x).Fill = new SolidColorBrush(Color.FromRgb((byte)150, (byte)150, (byte)150));
                }
            }
        }

        private void notHighlightColumn(int x)
        {
            for (int y = 0; y < 7; y++)
            {
                if (feld.Feld[y, x] == null)
                {
                    getEllipse(y, x).Fill = new SolidColorBrush(Color.FromRgb((byte)200, (byte)200, (byte)200));
                }
            }
        }

        public void redraw()
        {
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    if (feld.Feld[x, y] != null)
                    {
                        getEllipse(x, y).Fill = new SolidColorBrush(feld.Feld[x, y].Farbe);
                        
                    } else
                    {
                        getEllipse(x, y).Fill = new SolidColorBrush(Color.FromRgb((byte)200, (byte)200, (byte)200));
                    }
                }
            }
        }

        private Ellipse getEllipse(int x, int y)
        {
            x = (6 - x);
            var ellipse = grid.Children.Cast<UIElement>().Where(i => Grid.GetRow(i) == x);
            int forY = 0;
            foreach (Ellipse ell in ellipse)
            {
                if(forY == y)
                {
                    return ell;
                }
                forY++;
            }
            return null;
        }
    }
}
