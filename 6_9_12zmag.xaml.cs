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

        int comandNum = 1;

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
                if (SearchType.SelectionBoxItem.ToString()=="Змагання")
                {
                    MySqlCommand db_command = new MySqlCommand("SELECT * FROM zmfg WHERE (zmfg.Data BETWEEN " + "'" + DateBefore.SelectedDate.Value.Date.ToString("yyyy-MM-dd") + "'" + " AND '" + DateAfter.SelectedDate.Value.Date.ToString("yyyy-MM-dd") + "')", sample.getConnention());
                    dbAdab = new MySqlDataAdapter(db_command);
                }
                if (SearchType.SelectionBoxItem.ToString() == "Призери")
                {
                    string x = "SELECT * FROM zmfg WHERE zmfg.name_zmg = " +  "'" + t1.Text+"'";
                    //MessageBox.Show(x);
                    //t1.Text = x;
                    MySqlCommand db_command = new MySqlCommand(x, sample.getConnention());
                    dbAdab = new MySqlDataAdapter(db_command);
                }

                sample.OpenDBconnect();
            table = new DataTable();
            dbAdab.Fill(table);
                
                searchP.ItemsSource = table.DefaultView;
                ColumnsEdit(SearchType.SelectionBoxItem.ToString());
            }

            catch { //MessageBox.Show("Виберіть коректну дату");
                  }
            

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
            switch(SearchType.SelectionBoxItem.ToString()) 
            {
                case "Змагання": 
                    t1.Visibility = Visibility.Hidden;
                    t2.Visibility = Visibility.Hidden;
                    l1.Visibility = Visibility.Hidden;
                    l2.Visibility = Visibility.Hidden;
                    t3.Visibility = Visibility.Hidden;
                    l3.Visibility = Visibility.Hidden;
                    DateAfter.Visibility = Visibility.Visible;   
                    DateBefore.Visibility = Visibility.Visible;  
                    break;
                case "Призери":
                    l2.Content = "Змагання";
                    t1.Visibility = Visibility.Visible; 
                    l2.Visibility = Visibility.Visible;
                    t2.Visibility = Visibility.Hidden;
                    l1.Visibility = Visibility.Hidden;
                    t3.Visibility = Visibility.Hidden;
                    l3.Visibility = Visibility.Hidden;
                    DateAfter.Visibility = Visibility.Hidden;
                    DateBefore.Visibility = Visibility.Hidden;
                    break;
                case "Локація":
                    t1.Visibility = Visibility.Visible;
                    l2.Visibility = Visibility.Visible;
                    t2.Visibility = Visibility.Visible;
                    l1.Visibility = Visibility.Visible;
                    t3.Visibility = Visibility.Visible;
                    l3.Visibility = Visibility.Visible;
                    l2.Content = "Номер споруди";
                    l1.Content = "Тип споруди";
                    l3.Content = "Спорт";
                    break;
                case "Клуби": break;
                case "Організатори": break;
                case "Дата і корпус": break;
                default: break;
            }
        }

        private void ColumnsEdit(string data) 
        
        {
            switch (data)
            {
                case "Змагання":
                    searchP.Columns.RemoveAt(0);
                    searchP.Columns.RemoveAt(2);
                    searchP.Columns.RemoveAt(2);
                    searchP.Columns.RemoveAt(2);
                    searchP.Columns.RemoveAt(4);
                    searchP.Columns.RemoveAt(4);
                    searchP.Columns.RemoveAt(3);
                    //searchP.Columns.RemoveAt(5);
                    break;
                case "Призери":
                    searchP.Columns.RemoveAt(0);
                    searchP.Columns.RemoveAt(1); 
                    searchP.Columns.RemoveAt(4);
                    searchP.Columns.RemoveAt(4);
                    searchP.Columns.RemoveAt(4);
                    searchP.Columns.RemoveAt(4); break;
                case "Локація":
                    searchP.Columns.RemoveAt(4);
                    searchP.Columns.RemoveAt(4);
                    searchP.Columns.RemoveAt(4);
                    searchP.Columns.RemoveAt(4);
                    searchP.Columns.RemoveAt(5);
                    searchP.Columns.RemoveAt(5);
                    searchP.Columns.RemoveAt(5); 
                    searchP.Columns.RemoveAt(4); break;
                case "Клуби":
                    searchP.Columns.RemoveAt(4);
                    searchP.Columns.RemoveAt(4);
                    searchP.Columns.RemoveAt(4);
                    searchP.Columns.RemoveAt(4);
                    searchP.Columns.RemoveAt(5);
                    searchP.Columns.RemoveAt(5);
                    searchP.Columns.RemoveAt(5); break;
                case "Організатори":
                    searchP.Columns.RemoveAt(4);
                    searchP.Columns.RemoveAt(4);
                    searchP.Columns.RemoveAt(4);
                    searchP.Columns.RemoveAt(4);
                    searchP.Columns.RemoveAt(5);
                    searchP.Columns.RemoveAt(5);
                    searchP.Columns.RemoveAt(5); break;
                case "Дата і корпус":
                    searchP.Columns.RemoveAt(4);
                    searchP.Columns.RemoveAt(4);
                    searchP.Columns.RemoveAt(4);
                    searchP.Columns.RemoveAt(4);
                    searchP.Columns.RemoveAt(5);
                    searchP.Columns.RemoveAt(5);
                    searchP.Columns.RemoveAt(5); break;
                default: MessageBox.Show("Оберіть тип пошуку"); break;
            }


        }

    }
}
