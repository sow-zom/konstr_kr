using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
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
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace konstr_kr
{
    /// <summary>
    /// Логика взаимодействия для _6_9_12zmag.xaml
    /// </summary>
    public partial class _6_9_12zmag : Window
    {
        db sample = new db();
        MySqlDataAdapter dbAdab = new MySqlDataAdapter();
        DataTable table = new DataTable();

        public _6_9_12zmag()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show( (DateBefore.SelectedDate.Value.Date.ToString("yyyy-MM-dd")));

            //t1.Text = "SELECT * FROM zmfg WHERE zmfg.Data > " + DateBefore.SelectedDate.Value.Date.ToString("yyyy-MM-dd");
            try { 
            MySqlCommand db_command = new MySqlCommand("SELECT * FROM zmfg WHERE zmfg.Data > " + "'" + DateBefore.SelectedDate.Value.Date.ToString("yyyy-MM-dd") + "'", sample.getConnention());
            dbAdab = new MySqlDataAdapter(db_command);
            sample.OpenDBconnect();
            table = new DataTable();
            dbAdab.Fill(table);
            searchP.ItemsSource = table.DefaultView;
            }
            catch { MessageBox.Show("Виберіть дату"); }
        }
    }
}
