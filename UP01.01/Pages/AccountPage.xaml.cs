using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
    /// Логика взаимодействия для AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        List<Books> AllBooks;
        public AccountPage()
        {
            InitializeComponent();
            if (AppSession.CurrentUser != null && AppSession.CurrentUser.Freez == true)
            {
                Freezblok.Visibility = Visibility.Visible;
            }
            //UName.Text = $"Здравствуй, {UserInfo.kupt.Name}!";
            //List<Books> film = Core.Context.Books.ToList();
            //List<Books_Users> bu = Core.Context.Books_Users.Where(t => t.IDUser == UserInfo.kupt.ID).ToList();
            //LbBooks.ItemsSource = bu;
        }

        //private void BookCard_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
