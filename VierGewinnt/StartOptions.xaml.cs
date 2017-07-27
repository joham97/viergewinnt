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
using System.Windows.Shapes;

namespace VierGewinnt
{
    /// <summary>
    /// Interaktionslogik für StartOptions.xaml
    /// </summary>
    public partial class StartOptions : Window
    {
        public StartOptions()
        {
            InitializeComponent();

            tb_player1.Text = "Player1";
            tb_player2.Text = "Player2";
            rb_Startetp1.IsChecked = true;
            clrPcker_spieler1.SelectedColor = Colors.Red;
            clrPcker_spieler2.SelectedColor = Colors.Green;

        }

        private void btn_Start_Click(object sender, RoutedEventArgs e)
        {
            Byte erster = 0;
            if (rb_Startetp1.IsChecked == true)
            {
                erster = 1;
            }
            else
            {
                erster = 2;
            }

            MainWindow mw = new MainWindow(tb_player1.Text, clrPcker_spieler1.SelectedColor.Value, tb_player2.Text, clrPcker_spieler2.SelectedColor.Value, erster);
            mw.Show();
            this.Close();
        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
