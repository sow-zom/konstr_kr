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
using System.Windows.Controls.Primitives;
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
        int sp_or_tr = 2;
        string morethanone = " WHERE sports_num > 0 ";


        public _2_4Sportsm()
        {
            InitializeComponent();
            
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
                return " > ";
            }

        }

        private string CheckForEmpty1(string s)
        {

            if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
            {
                return " = ";
            }
            else
            {
                return " = ";
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //test
            //MySqlCommand db_command = new MySqlCommand("SELECT p.*, f.* FROM sportsman p INNER JOIN tc_spotsman_sport pf ON pf.ID_sport = p.id INNER JOIN sport f ON f.ID_sport = pf.ID_sman WHERE f.name_sport" + CheckForEmpty1(sport.Text) + "'" +sport.Text +"'" + " and rozrd " + CheckForEmpty2(rozrd.Text) + rozrd.Text, sample.getConnention());
            //main test 
            try
            {
                if (sp_or_tr == 2)
            {
                if (morethanone2.IsChecked == true)  morethanone = " WHERE sports_num > 1 ";
                if (morethanone2.IsChecked == false) morethanone = " WHERE sports_num > 0 ";
                //MessageBox.Show("SELECT p.*, f.* FROM sportsman p INNER JOIN tc_spotsman_sport pf ON pf.ID_sport = p.id INNER JOIN sport f ON f.ID_sport = pf.ID_sman WHERE rozrd" + CheckForEmpty2(rozrd.Text) + rozrd.Text + CheckForEmpty3(sport.Text) + " f.name_sport " + CheckForEmpty1(sport.Text) + "'" + sport.Text + "'");
                MySqlCommand db_command = new MySqlCommand("SELECT p.*, f.* FROM sportsman p INNER JOIN tc_spotsman_sport pf ON pf.ID_sport = p.id INNER JOIN sport f ON f.ID_sport = pf.ID_sman "+ morethanone +  " and rozrd"  + CheckForEmpty2(rozrd.Text) + rozrd.Text + CheckForEmpty3(sport.Text) + " f.name_sport " + CheckForEmpty1(sport.Text) + "'" + sport.Text + "'", sample.getConnention());

            //MySqlCommand db_command = new MySqlCommand("SELECT p.*, f.*, t.* FROM sportsman p INNER JOIN tc_spotsman_sport pf ON pf.ID_sport = p.id INNER JOIN sport f ON f.ID_sport = pf.ID_sman INNER JOIN tc_sportsman_trener t ON t.ID_trener = p.id INNER JOIN trener tr ON t.ID_trener = pf.ID_sman  WHERE f.name_sport" + CheckForEmpty1(sport.Text) + "'" + sport.Text + "'" + " and rozrd " + CheckForEmpty2(rozrd.Text) + rozrd.Text, sample.getConnention());

            dbAdab = new MySqlDataAdapter(db_command);
            }
            if (sp_or_tr == 1)
            {
                //MessageBox.Show("SELECT p.*, t.* FROM sportsman p INNER JOIN tc_sportsman_trener t ON t.ID_sportsman = p.id INNER JOIN trener tr ON tr.ID = t.ID_trener WHERE  rozrd " + CheckForEmpty2(rozrd.Text) + rozrd.Text + "t.name_tr" + CheckForEmpty3(sport.Text) + CheckForEmpty1(sport.Text) + "'" + sport.Text + "'");
                string x = "SELECT p.*, t.* FROM sportsman p INNER JOIN tc_sportsman_trener t ON t.ID_sportsman = p.id INNER JOIN trener tr ON tr.ID = t.ID_trener " +
                    "WHERE t.name_tr"  + CheckForEmpty1(sport.Text) + "'" + sport.Text + "'";
               MessageBox.Show(x);
                MySqlCommand db_command = new MySqlCommand(x, sample.getConnention());

                //MySqlCommand db_command = new MySqlCommand("SELECT p.*, f.*, t.* FROM sportsman p INNER JOIN tc_spotsman_sport pf ON pf.ID_sport = p.id INNER JOIN sport f ON f.ID_sport = pf.ID_sman INNER JOIN tc_sportsman_trener t ON t.ID_trener = p.id INNER JOIN trener tr ON t.ID_trener = pf.ID_sman  WHERE f.name_sport" + CheckForEmpty1(sport.Text) + "'" + sport.Text + "'" + " and rozrd " + CheckForEmpty2(rozrd.Text) + rozrd.Text, sample.getConnention());

                dbAdab = new MySqlDataAdapter(db_command);
            }
                if (sp_or_tr == 3)
                {
                    string x = "SELECT p.*, t.* FROM sportsman p INNER JOIN tc_sportsman_trener t ON t.ID_sportsman = p.id INNER JOIN trener tr ON tr.ID = t.ID_trener WHERE " + "t.name_sportm" + CheckForEmpty1(sport.Text) + "'" + sport.Text + "'";
                   //MessageBox.Show(x);
                    MySqlCommand db_command = new MySqlCommand(x, sample.getConnention());

                    //MySqlCommand db_command = new MySqlCommand("SELECT p.*, f.*, t.* FROM sportsman p INNER JOIN tc_spotsman_sport pf ON pf.ID_sport = p.id INNER JOIN sport f ON f.ID_sport = pf.ID_sman INNER JOIN tc_sportsman_trener t ON t.ID_trener = p.id INNER JOIN trener tr ON t.ID_trener = pf.ID_sman  WHERE f.name_sport" + CheckForEmpty1(sport.Text) + "'" + sport.Text + "'" + " and rozrd " + CheckForEmpty2(rozrd.Text) + rozrd.Text, sample.getConnention());

                    dbAdab = new MySqlDataAdapter(db_command);
                }
                sample.OpenDBconnect();
            table = new DataTable();
            dbAdab.Fill(table);
                // grid_sports.Columns[1].Visibility = Visibility.Hidden;
                
                grid_sports.ItemsSource = table.DefaultView;
             }
            catch { }
            //MessageBox.Show(grid_sports.Items.Count.ToString()) ;
            //grid_sports.Columns.RemoveAt(4);
        }

        private void visiblevalue()
        {
            rozrd.Visibility = Visibility.Hidden;
            l3.Visibility = Visibility.Hidden;
            l4.Visibility = Visibility.Hidden;
            morethanone2.Visibility = Visibility.Hidden;
            trn.Visibility = Visibility.Visible;
            trn.Content = "Список тренерів";

        }
        private void visiblevalue3()
        {
            rozrd.Visibility = Visibility.Hidden;
            l3.Visibility = Visibility.Hidden;
            l4.Visibility = Visibility.Hidden;
            morethanone2.Visibility = Visibility.Hidden;
            trn.Visibility = Visibility.Visible;
            trn.Content = "Список спортменів";

        }
        private void visiblevalue2()
        {
            rozrd.Visibility = Visibility.Visible;
            l3.Visibility = Visibility.Visible;
            l4.Visibility = Visibility.Visible;
            morethanone2.Visibility = Visibility.Visible;
            trn.Visibility = Visibility.Hidden;

        }
        private void sport_or_tren_MouseLeave(object sender, MouseEventArgs e)
        {
           switch(sport_or_tren.SelectionBoxItem.ToString())
            {
                case "Тренер":sp_or_tr=1; visiblevalue3(); break;
                case "Спорт" : sp_or_tr = 2; visiblevalue2(); break;
                case "Спортсмен": sp_or_tr = 3; visiblevalue(); break;
            }
        }
        
    }
}
