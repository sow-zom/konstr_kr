using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace konstr_kr
{
    /// <summary>
    /// Логика взаимодействия для _2_4Sportsm.xaml
    /// </summary>
    public partial class _2_4Sportsm : Window
    {
        db sample = new db();
        MySqlDataAdapter dbAdab = new MySqlDataAdapter();
        DataTable table = new DataTable();
        public _2_4Sportsm()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MySqlCommand db_command = new MySqlCommand("SELECT p.*, f.* FROM sportsman p INNER JOIN tc_spotsman_sport pf ON pf.ID_sport = p.id INNER JOIN sport f ON f.ID_sport = pf.ID_sman WHERE rozrd", sample.getConnention());
            dbAdab = new MySqlDataAdapter(db_command);
            sample.OpenDBconnect();
            table = new DataTable();
            dbAdab.Fill(table); 
            grid_sports.ItemsSource = table.DefaultView;
        }
    }
}
