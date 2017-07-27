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
    /// Interaktionslogik für Historie.xaml
    /// </summary>
    public partial class Historie : Window
    {

        public List<Feld> history;

        public int currentHistoryId;

        public Historie()
        {
            InitializeComponent();
            history = new List<Feld>();
        }

        private void prev_Click(object sender, RoutedEventArgs e)
        {
            if (0 < currentHistoryId)
            {
                currentHistoryId--;
                spielfeld.feld = history[currentHistoryId];
            }
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            if (currentHistoryId < history.Count - 1)
            {
                currentHistoryId++;
            }
        }        
    }
}
