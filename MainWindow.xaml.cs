using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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


namespace konstr_kr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        db sample = new db();
        MySqlDataAdapter dbAdab = new MySqlDataAdapter();
        DataTable table = new DataTable();
        Random rnd = new Random();
        

        public MainWindow()
        {
            InitializeComponent();
            int x = rnd.Next(0, 7);
            //MessageBox.Show(x.ToString());
            string rnd2 = "random";
            switch (x)
            {
                case 0: rnd2 = "court"; break;
                case 1: rnd2 = "gym"; break;
                case 2: rnd2= "manej"; break;
                case 3: rnd2 = "stadium"; break;
                case 4: rnd2 = "sport"; break;
                case 5: rnd2 = "sportsman"; break;
                case 6: rnd2 = "trener"; break;
                case 7: rnd2 = "zmfg"; break;
            }

            MySqlCommand db_command = new MySqlCommand("SELECT * FROM "+ rnd2, sample.getConnention());
            dbAdab = new MySqlDataAdapter(db_command);
            sample.OpenDBconnect();
            table = new DataTable();
            dbAdab.Fill(table);
            MainGrid.ItemsSource = table.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _1Sporud sporud = new _1Sporud();
            sporud.Show();

        }

        private void Sportm(object sender, RoutedEventArgs e)
        {
            _2_4Sportsm sportm = new _2_4Sportsm();
            sportm.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _6_9_12zmag zmag = new _6_9_12zmag();
            zmag.Show();
        }
    }
}
