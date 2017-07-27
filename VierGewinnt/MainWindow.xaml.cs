using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Spieler amZug;

        public MainWindow()
        {
            InitializeComponent();
            Spieler spieler1 = new Spieler("Olli", Color.FromRgb((byte)200, (byte)0, (byte)0));
            Spieler spieler2 = new Spieler("Andrea", Color.FromRgb((byte)0, (byte)200, (byte)0));

            amZug = spieler1;

            VierGewinntSpiel viergewinnt = new VierGewinntSpiel(spieler1, spieler2);
            spielfeld.feld = viergewinnt.feld;
            spielfeld.redraw();

            spielfeld.Tick += (i, e) => {
                viergewinnt.setzeChip(i, amZug);
                if (amZug == spieler1)
                {
                    amZug = spieler2;
                }else
                {
                    amZug = spieler1;
                }
                spielfeld.redraw();
            };

            setColorsPlayers(spieler1.Farbe, spieler2.Farbe);
            setNamesPlayers(spieler1.Name, spieler2.Name);

            Thread timer = new Thread(CountTime);
            timer.Start();
        }

        private void CountTime()
        {
            try
            {
                int min = 0;
                int sec = 0;

                while (true)
                {
                    if (sec == 59)
                    {
                        min += 1;
                        sec = 0;
                    }
                    else
                    {
                        sec += 1;
                    }
                    Thread.Sleep(1000);
                    if (sec < 10 && min < 10)
                    {
                        this.Dispatcher.Invoke(delegate { label_Time.Content = "0" + min + ":0" + sec; });
                    }
                    else if (sec < 10)
                    {
                        this.Dispatcher.Invoke(delegate { label_Time.Content = min + ":0" + sec; });
                    }
                    else if (min < 10)
                    {
                        this.Dispatcher.Invoke(delegate { label_Time.Content = "0" + min + ":" + sec; });
                    }
                    else
                    {
                        this.Dispatcher.Invoke(delegate { label_Time.Content = min + ":" + sec; });
                    }

                }
            }
            catch (TaskCanceledException)
            {

            }
        }

        private void frame_Navigated(object sender, NavigationEventArgs e)
        {

        }
        
        private void setColorsPlayers(Color color1, Color color2)
        {
            color_p1.Background = new SolidColorBrush(color1);
            color_p2.Background = new SolidColorBrush(color2);
        }

        private void setNamesPlayers(string name1, string name2)
        {
            lbl_Player1.Content = name1;
            lbl_Player2.Content = name2;
        }
    }
}
