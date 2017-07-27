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

        private List<Feld> history;

        public int currentHistoryId;

        public Historie(Feld feld)
        {
            InitializeComponent();
            spielfeld.feld = feld;
            spielfeld.initFeld(false);
            history = new List<Feld>();
        }

        public void Add(Feld feld)
        {
            history.Add(feld);
            currentHistoryId = history.Count - 1;
            spielfeld.feld = feld;
            next.IsEnabled = false;
            spielfeld.redraw();
        }

        private void prev_Click(object sender, RoutedEventArgs e)
        {
            if (0 < currentHistoryId)
            {
                currentHistoryId--;
                spielfeld.feld = history[currentHistoryId];
                spielfeld.redraw();

                if (currentHistoryId == history.Count - 1) next.IsEnabled = false;
                if (currentHistoryId != history.Count - 1) next.IsEnabled = true;
                if (currentHistoryId == 0) prev.IsEnabled = false;
                if (currentHistoryId != 0) prev.IsEnabled = true;
            }
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            if (currentHistoryId < history.Count - 1)
            {
                currentHistoryId++;
                spielfeld.feld = history[currentHistoryId];
                spielfeld.redraw();
                if (currentHistoryId == history.Count - 1) next.IsEnabled = false;
                if (currentHistoryId != history.Count - 1) next.IsEnabled = true;
                if (currentHistoryId == 0) prev.IsEnabled = false;
                if (currentHistoryId != 0) prev.IsEnabled = true;
            }
        }        
    }
}
