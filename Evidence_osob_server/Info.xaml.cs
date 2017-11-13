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
using Evidence_osob_server.Entity;
using Evidence_osob_server.Framy;
using Evidence_osob_server.Interface;
using Evidence_osob_server.JsonParsse;

namespace Evidence_osob_server
{
    /// <summary>
    /// Interakční logika pro Info.xaml
    /// </summary>
    public partial class Info : Page
    {
        User u;
        int ID;

        public Info(int id)
        {
            InitializeComponent();
            InitializeComponent();
            ID = id;
            // GetUser();
            name.Content = u.name + " " + u.surname;
            gender.Content = u.gender;
            birth.Content = u.birth.ToString("dd.MM. yyyy");
            birth_num.Content = u.birth_num;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
