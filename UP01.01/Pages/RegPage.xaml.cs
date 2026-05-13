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
using UP01._01.Models;

namespace UP01._01.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }
        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            string N = name.Text;
            string E = email.Text;
            string L = login.Text;
            string P = password.Text;
            Registr(N, E, L, P);
            if (Registr(N, E, L, P) == true)
            {
                NavigationService.Navigate(new LoginPage());
                if (NavigationService.CanGoForward)
                {
                    NavigationService.GoForward();
                }
            }
        }
        public bool Registr(string N, string E, string L, string P)
        {
            if (N != "" && E != "" && L !="" && P != "" && N != " " && E != " " && L != " " && P != " ")
            {
                List<Users> users = Core.Context.Users.ToList();
                Users newUser = new Users // создание нового пользователя
                {
                    Name = N,
                    Email = E,
                    Login = E,
                    Password = P
                };
                Core.Context.Users.Add(newUser);
                Core.Context.SaveChanges();
                UserInfo.kupt = newUser;
                return true;
            }
            else
            {
                MessageBox.Show("Ошибка ввода полей");
                return false;
            }
        }
    }
}
