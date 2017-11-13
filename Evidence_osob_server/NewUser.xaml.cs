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
using RestSharp;

namespace Evidence_osob_server
{
    /// <summary>
    /// Interakční logika pro NewUser.xaml
    /// </summary>
    public partial class NewUser : Page
    {
        User u;
        bool edit;
        string url;

        public NewUser()
        {
            InitializeComponent();
        }

        public NewUser(User us)
        {
            InitializeComponent();
            u = us;
            edit = true;
            name.Text = u.name;
            surname.Text = u.surname;
            birth_num.Text = u.birth_num;
            birth.DisplayDate = u.birth;
            select.SelectedValue = u.gender;
        }

        private void Create()
        {
            try
            {
                User uc = new User();
                uc.name = name.Text;
                uc.surname = surname.Text;
                uc.birth = birth.DisplayDate;
                uc.birth_num = birth_num.Text;
                uc.gender = select.SelectedValue.ToString();
                if (edit)
                {
                    url = "https://student.sps-prosek.cz/~sevcima14/Insert.php?ID=" + u.ID;
                    MessageBox.Show(url);
                }
                else
                {
                    url = "https://student.sps-prosek.cz/~sevcima14/Insert.php";
                }
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/json");
                request.AddParameter("application/json", Newtonsoft.Json.JsonConvert.SerializeObject(uc), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
            }
            catch
            {
                MessageBox.Show("Vyskytla se chyba");
            }
        }

        private void created_Click(object sender, RoutedEventArgs e)
        {
            Create();
            if (edit)
            {
                BackEnd.frame.Navigate(new Info(u.ID));
            }
            else
            {
                BackEnd.frame.Navigate(new UserList());
            }
        }

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            if (edit)
            {
                BackEnd.frame.Navigate(new Info(u.ID));
            }
            else
            {
                BackEnd.frame.Navigate(new UserList());
            }
        }

        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (edit)
            {
                created.Content = "Editovat uživatele " + name.Text;
            }
            else
            {
                created.Content = "Vytvořit uživatele " + name.Text;
            }
        }
    }
}
