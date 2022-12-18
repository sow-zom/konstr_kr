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
    /// Логика взаимодействия для _1Sporud.xaml
    /// </summary>
    public partial class _1Sporud : Window
    {
        db sample = new db();
        MySqlDataAdapter dbAdab = new MySqlDataAdapter();
        DataTable table = new DataTable();
        //string symbl = "=";
        //string symbl2 = "<";
        string tabl = "gym";
        //string ID = "ID";
        string num_1 = "Square";
        string num_2 = "Ceiling_height";
        string text = "Designed_for";
        public _1Sporud()
        {
            InitializeComponent();
           
            getSporud();
            
        }
        public void getSporud() 
        {
                switch (Bilding.SelectionBoxItem.ToString())
                {
                    case "Спорт зал": l1.Content = "ID_zal"; l2.Content = "Площа"; l3.Content = "Висота"; l4.Content = "Призначення";
                    tabl = "gym";
                    num_1 = "Square";
                    num_2 = "Ceiling_height";
                    text = "Designed_for"; 
                    break;
                    case "Манеж": l1.Content = "ID_manej"; l2.Content = "Клст Доріжок"; l3.Content = "Довжина"; l4.Content = "Тип поверхні"; 
                    tabl = "manej";
                    num_1 = "Treadmills_num";
                    num_2 = "Length";
                    text = "Type_covering"; break;
                    case "Стадіон": l1.Content = "ID_stad"; l2.Content = "Кількість мість"; l3.Content = "Площа"; l4.Content = "Дод. інф.";
                    tabl = "stadium";
                    num_1 = "seat_num";
                    num_2 = "square";
                    text = "stand_plays"; break;
                    case "Корт": l1.Content = "ID_kort"; l2.Content = "Ширина"; l3.Content = "Довжина"; l4.Content = "Тип поверхні";
                    tabl = "court";
                    num_1 = "Width";
                    num_2 = "Length";
                    text = "Type_covering"; break;
                }
        }

        private string CheckForEmpty(string s) 
        {

            if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
            {
                return " ";
            }
            else
            {
                if (SearchType.Content.ToString() == "Конкретне значення") return ">";
                else return "=";
            }

        }
        private string CheckForEmpty3(string s)
        {

            if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
            {

                return " or ";
            }
            else return " and ";

        } 
        private string CheckForEmpty2(string s)
        {

            if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
            {
                return "";
            }
            else
            {
                return " < ";
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //CheckForEmpty();

            // MySqlCommand db_command = new MySqlCommand("SELECT * FROM " + tabl + " and ID " + CheckForEmpty(t1.Text) + t1.Text + " and " + num_1 + CheckForEmpty(t2.Text) + t2.Text + " and " + num_2 + CheckForEmpty(t3.Text) + t3.Text + " or " + text + " = '" + t4.Text + "'" + " and ID " + CheckForEmpty2(th1.Text) + th1.Text + " and " + num_1 + CheckForEmpty2(th2.Text) + th2.Text + " and " + num_2 + CheckForEmpty2(th3.Text) + th3.Text + "", sample.getConnention());

            try {
                                           //MessageBox.Show("SELECT * FROM " + tabl + " WHERE ID " + CheckForEmpty(t1.Text) + t1.Text + " and " + num_1 + CheckForEmpty(t2.Text) + t2.Text + " and " + num_2 + CheckForEmpty(t3.Text) + t3.Text + " and ID " + CheckForEmpty2(th1.Text) + th1.Text + " and " + num_1 + CheckForEmpty2(th2.Text) + th2.Text + " and " + num_2 + CheckForEmpty2(th3.Text) + th3.Text + CheckForEmpty3(t4.Text) + text + " = " + " '" + t4.Text + "'");
                MySqlCommand db_command = new MySqlCommand("SELECT * FROM " + tabl + " WHERE ID " + CheckForEmpty(t1.Text) + t1.Text + " and " + num_1 + CheckForEmpty(t2.Text) + t2.Text + " and " + num_2 + CheckForEmpty(t3.Text) + t3.Text + " and ID " + CheckForEmpty2(th1.Text) + th1.Text + " and " + num_1 + CheckForEmpty2(th2.Text) + th2.Text + " and " + num_2 + CheckForEmpty2(th3.Text) + th3.Text + CheckForEmpty3(t4.Text) + text + " = " + " '" + t4.Text + "'", sample.getConnention());
                dbAdab = new MySqlDataAdapter(db_command);
                sample.OpenDBconnect();
                table = new DataTable();
                dbAdab.Fill(table);
                grid_sporud.ItemsSource = table.DefaultView;
            }
            catch
            {

            }

        }
        private void Bilding_MouseLeave(object sender, MouseEventArgs e)
        {
            //string s = Bilding.SelectionBoxItem.ToString();
            //MessageBox.Show(s);
            getSporud();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (th1.Visibility==Visibility.Hidden)
            {
                th1.Visibility = Visibility.Visible;
                th2.Visibility = Visibility.Visible;
                th3.Visibility = Visibility.Visible;
                t4.Visibility = Visibility.Hidden;
                l4.Visibility = Visibility.Hidden;
                t4.Text = " ";
                vid.Visibility= Visibility.Visible;
                Do.Visibility = Visibility.Visible;
                SearchType.Content = "Конкретне значення";
            }
            else 
            {
                th1.Text = "";
                th2.Text = "";
                th3.Text = "";
                th1.Visibility = Visibility.Hidden;
                th2.Visibility = Visibility.Hidden;
                th3.Visibility = Visibility.Hidden;
                t4.Visibility = Visibility.Visible;
                l4.Visibility = Visibility.Visible;
                vid.Visibility = Visibility.Hidden;
                Do.Visibility = Visibility.Hidden;
                SearchType.Content = "Діапазон значень";
            }
        }
        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
