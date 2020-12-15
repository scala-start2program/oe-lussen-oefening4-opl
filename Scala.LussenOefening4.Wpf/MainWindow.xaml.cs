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

namespace Scala.LussenOefening4.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<string> ploegenBeschikbaar;
        List<string> ploegenGeloot;
        List<string> wedstrijden;
        Random rnd = new Random();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ploegenBeschikbaar = new List<string>();
            ploegenGeloot = new List<string>();
            wedstrijden = new List<string>();
            VulPloegen();
            VulListboxen();
        }
        private void VulPloegen()
        {
            ploegenBeschikbaar.Add("Club Brugge");
            ploegenBeschikbaar.Add("Genk");
            ploegenBeschikbaar.Add("Beerschot VA");
            ploegenBeschikbaar.Add("OHL");
            ploegenBeschikbaar.Add("Charleroi");
            ploegenBeschikbaar.Add("Anderlecht");
            ploegenBeschikbaar.Add("Antwerp");
            ploegenBeschikbaar.Add("Standard");
            ploegenBeschikbaar.Add("Oostende");
            ploegenBeschikbaar.Add("Kortrijk");
            ploegenBeschikbaar.Add("Eupen");
            ploegenBeschikbaar.Add("Gent");
            ploegenBeschikbaar.Add("Cercle");
            ploegenBeschikbaar.Add("W-Beveren");
            ploegenBeschikbaar.Add("Zulte-Waregem");
            ploegenBeschikbaar.Add("Mechelen");
            ploegenBeschikbaar.Add("Moeskroen");
            ploegenBeschikbaar.Add("STVV");
        }

        private void VulListboxen()
        {
            lstBeschikbaar.ItemsSource = null;
            lstGekozen.ItemsSource = null;
            lstMatchen.ItemsSource = null;

            lstBeschikbaar.ItemsSource = ploegenBeschikbaar;
            lstGekozen.ItemsSource = ploegenGeloot;
            lstMatchen.ItemsSource = wedstrijden;

        }

        private void btnLoot_Click(object sender, RoutedEventArgs e)
        {
            int teamsAvailable = ploegenBeschikbaar.Count;
            int eerstePloeg = rnd.Next(0, teamsAvailable);
            int tweedePloeg = eerstePloeg;
            while (tweedePloeg == eerstePloeg)
            {
                tweedePloeg = rnd.Next(0, teamsAvailable);
            }

            string ploegNaamEen = ploegenBeschikbaar[eerstePloeg];
            string ploegNaamTwee = ploegenBeschikbaar[tweedePloeg];
            ploegenGeloot.Add(ploegNaamEen);
            ploegenGeloot.Add(ploegNaamTwee);
            ploegenBeschikbaar.Remove(ploegNaamEen);
            ploegenBeschikbaar.Remove(ploegNaamTwee);
            wedstrijden.Add(ploegNaamEen + " - " + ploegNaamTwee);

            VulListboxen();

            if (ploegenBeschikbaar.Count == 0)
                btnLoot.IsEnabled = false;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ploegenBeschikbaar.Clear();
            ploegenGeloot.Clear();
            wedstrijden.Clear();
            VulPloegen();
            VulListboxen();
            btnLoot.IsEnabled = true;

        }
    }
}
