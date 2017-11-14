using RestSharp;
using Newtonsoft.Json;
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
using Evidence_osob_server.Interface;
using Evidence_osob_server.JsonParsse;
using Evidence_osob_server.Framy;

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
            ID = id;
            GetUser();
            name.Content = u.name + " " + u.surname;
            gender.Content = u.gender;
            birth.Content = u.birth.ToString("dd.MM. yyyy");
            birth_num.Content = u.birth_num;
        }

        private void GetUser()
        {
            var client = new RestClient("https://student.sps-prosek.cz/~sevcima14/4ITB/dotaz.php?ID=" + ID);
            //var client = new RestClient("https://requestb.in/19vwv091");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            IParse parser = new JsonParser();
            string result = response.Content.Replace(@"[", "");
            result = result.Replace(@"]", "");
            u = JsonConvert.DeserializeObject<User>(result);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Smazat " + u.name + " ?", "Deleting item", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var client = new RestClient("https://student.sps-prosek.cz/~sevcima14/4ITB/Delete.php?ID=" + ID);
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                BackEnd.frame.Navigate(new UserList());
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            BackEnd.frame.Navigate(new NewUser(u));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            BackEnd.frame.Navigate(new UserList());
        }
    }
}
