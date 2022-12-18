using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
            //t1.Text = "SELECT * FROM zmfg WHERE (zmfg.Data BETWEEN " + "'" + DateBefore.SelectedDate.Value.Date.ToString("yyyy-MM-dd") + "'" + " AND '" + DateAfter.SelectedDate.Value.Date.ToString("yyyy-MM-dd") + "')";
            try { 
            MySqlCommand db_command = new MySqlCommand("SELECT * FROM zmfg WHERE (zmfg.Data BETWEEN " + "'" + DateBefore.SelectedDate.Value.Date.ToString("yyyy-MM-dd") + "'" + " AND '" + DateAfter.SelectedDate.Value.Date.ToString("yyyy-MM-dd") + "')", sample.getConnention());
            dbAdab = new MySqlDataAdapter(db_command);
            sample.OpenDBconnect();
            table = new DataTable();
            dbAdab.Fill(table);
            searchP.ItemsSource = table.DefaultView;
                searchP.Columns.RemoveAt(4); searchP.Columns.RemoveAt(4); searchP.Columns.RemoveAt(4); searchP.Columns.RemoveAt(4); searchP.Columns.RemoveAt(5); searchP.Columns.RemoveAt(5); searchP.Columns.RemoveAt(5);
            }
            catch { MessageBox.Show("Виберіть коректну дату"); }
        }
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(sender , e);
            }
        }

        private void ComboBox_MouseLeave(object sender, MouseEventArgs e)
        {
            switch(SearchType .SelectionBoxItem.ToString()) 
            {
                case "Змагання":  break;
                case "Призери": break;
                case "Локація": searchP.Columns.RemoveAt(4); break;
                case "Клуби": break;
                case "Організатори": break;
                case "Дата і корпус": break;
                default: MessageBox.Show("Оберіть тип пошуку"); break;
            }
        }

    }
}
