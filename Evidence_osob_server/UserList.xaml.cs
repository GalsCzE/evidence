using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Evidence_osob_server.Entity;
using Evidence_osob_server.Framy;
using Evidence_osob_server.Interface;
using Evidence_osob_server.JsonParsse;
using RestSharp;
using Newtonsoft.Json;

namespace Evidence_osob_server
{
    /// <summary>
    /// Interakční logika pro UserList.xaml
    /// </summary>
    public partial class UserList : Page
    {
        public UserList()
        {
            InitializeComponent();
            try
            {
                RUN();
            }
            catch
            {
                Debug.WriteLine("Neplatná hodnota v databázi");
            }
        }

        private async Task RUN()
        {
            var client = new RestClient("https://student.sps-prosek.cz/~sevcima14/4ITB/dotaz.php");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            IParse parser = new JsonParser();
            People_list.ItemsSource = await parser.ParseString<List<User>>(response.Content);
        }
        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            int id = ((User)People_list.SelectedItem).ID;
            BackEnd.frame.Navigate(new Info(id));
        }

        private void People_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BackEnd.frame.Navigate(new NewUser());
        }
    }
}
