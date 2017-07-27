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

        public bool inited = false;

        public SpielfeldUserControl()
        {
            InitializeComponent();
        }

        public void initFeld(bool withMouseEvent)
        {
            for (int x = 0; x < feld.feld.GetLength(0); x++)
            {
                for (int y = 0; y < feld.feld.GetLength(1); y++)
                {
                    int X = x;
                    int Y = y;
                    Ellipse ellipse = new Ellipse();
                    ellipse.Width = 90;
                    ellipse.Height = 90;
                    ellipse.Fill = new SolidColorBrush(Color.FromRgb((byte)200, (byte)200, (byte)200));
                    if (withMouseEvent)
                    {
                        ellipse.MouseEnter += (obj, e) => { highlightColumn(Y); };
                        ellipse.MouseLeave += (obj, e) => { notHighlightColumn(Y); };
                        ellipse.MouseDown += (obj, e) => { Tick(Y, e); };
                    }
                    grid.Children.Add(ellipse);
                    Grid.SetColumn(ellipse, y);
                    Grid.SetRow(ellipse, x);
                }
            }
        }

        private void highlightColumn(int y)
        {
            for (int x = 0; x < feld.feld.GetLength(0); x++)
            {
                if (feld.feld[x, y] == null)
                {
                    getEllipse(x, y).Fill = new SolidColorBrush(Color.FromRgb((byte)150, (byte)150, (byte)150));
                }
            }
        }

        private void notHighlightColumn(int y)
        {
            for (int x = 0; x < feld.feld.GetLength(0); x++)
            {
                if (feld.feld[x, y] == null)
                {
                    getEllipse(x, y).Fill = new SolidColorBrush(Color.FromRgb((byte)200, (byte)200, (byte)200));
                }
            }
        }

        public void redraw()
        {
            for (int x = 0; x < feld.feld.GetLength(0); x++)
            {
                for (int y = 0; y < feld.feld.GetLength(1); y++)
                {
                    if (feld.feld[x, y] != null)
                    {
                        getEllipse(x, y).Fill = new SolidColorBrush(feld.feld[x, y].Farbe);

                    }
                    else
                    {
                        getEllipse(x, y).Fill = new SolidColorBrush(Color.FromRgb((byte)200, (byte)200, (byte)200));
                    }
                }
            }
        }

        private Ellipse getEllipse(int x, int y)
        {
            x = (feld.feld.GetLength(0) - 1) - x;
            var ellipse = grid.Children.Cast<UIElement>().Where(i => Grid.GetRow(i) == x).Where(i => Grid.GetColumn(i) == y);
            foreach (Ellipse ell in ellipse)
            {
                return ell;                
            }
            return null;
        }
    }
}
