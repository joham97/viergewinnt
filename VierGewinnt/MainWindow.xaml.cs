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

        private Historie historie;

        public MainWindow(String namep1, Color colorp1, String namep2, Color colorp2, Byte erster)
        {
            InitializeComponent();
            spielfeld.initFeld(true);

            Spieler spieler1 = new Spieler(namep1, colorp1);
            Spieler spieler2 = new Spieler(namep2, colorp2);

            frame_p1.BorderThickness = new Thickness(2.0);
            frame_p2.BorderThickness = new Thickness(2.0);

            if (erster == 1)
            {
                amZug = spieler1;
                frame_p1.BorderBrush = Brushes.Red;
            }
            else
            {
                amZug = spieler2;
                frame_p2.BorderBrush = Brushes.Red;

            }

            VierGewinntSpiel viergewinnt = new VierGewinntSpiel(spieler1, spieler2);
            spielfeld.feld = viergewinnt.feld;
            spielfeld.redraw();
<<<<<<< HEAD

            spielfeld.Tick += (i, e) =>
            {
=======
            
            spielfeld.Tick += (i, e) => {
>>>>>>> 1cff476246795c450a576c0c5a0ba3baacb7bd4f
                if (viergewinnt.setzeChip(i, amZug))
                {
                    spielfeld.redraw();
                    if (amZug == spieler1)
                    {
                        amZug = spieler2;
                        frame_p1.BorderBrush = Brushes.White;
                        frame_p2.BorderBrush = Brushes.Red;

                    }
                    else
                    {
                        amZug = spieler1;
                        frame_p1.BorderBrush = Brushes.Red;
                        frame_p2.BorderBrush = Brushes.White;

                    }
                    if (viergewinnt.spielende())
                    {
                        String gewinner = "Der Gewinner ist " + viergewinnt.getGewinner().Name+". Wollen Sie nochmal Spielen?";
                        String retry = "Spiel beendet";
                        MessageBoxButton but = MessageBoxButton.YesNo;
                        var result = MessageBox.Show(gewinner, retry, but);
                        if (result == MessageBoxResult.Yes)
                        {
                            newStart(spieler1.Name, spieler2.Name, erster, spieler1.Farbe, spieler2.Farbe);
                        }
                        else if (result == MessageBoxResult.No)
                        {
                            this.Close();
                        }

                    }
                    historie.Add(viergewinnt.kloneFeld());
                    spielfeld.redraw();
                }
            };

            historie = new Historie();
            historie.Add(viergewinnt.kloneFeld());

            setColorsPlayers(spieler1.Farbe, spieler2.Farbe);
            setNamesPlayers(spieler1.Name, spieler2.Name);

            Thread timer = new Thread(CountTime);
            timer.Start();



        }

        private void newStart(string p1, string p2, byte erster, Color c1, Color c2)
        {
            StartOptions s = new StartOptions(p1, p2, erster, c1, c2);
            s.Show();
            this.Close();
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

        private void Historie_Click(object sender, RoutedEventArgs e)
        {
            historie.Show();
        }
    }
}
