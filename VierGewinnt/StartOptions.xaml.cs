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
        }

        private void btn_Start_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(tb_player1.Text, Color.FromRgb((byte)200, (byte)0, (byte)0), tb_player2.Text, Color.FromRgb((byte)0, (byte)0, (byte)200));
            mw.Show();
            this.Close();
        }
    }
}
