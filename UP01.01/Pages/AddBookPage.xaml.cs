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
    /// Логика взаимодействия для AddBookPage.xaml
    /// </summary>
    public partial class AddBookPage : Page
    {
        public Books books { get; set; }
        public Books_Users book_users { get; set; }
        public AddBookPage(Books b)
        {
            InitializeComponent();
            books = b;
            this.DataContext = this;
            priv.Text = $"Добавить книгу {books.Name} в:";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Books_Users books_users = new Books_Users
            {
                IDBook = books.ID,
                IDUser = AppSession.CurrentUser.ID,
                IDStatus = 1
            };
            Core.Context.Books_Users.Add(books_users);
            Core.Context.SaveChanges();
            NavigationService.Navigate(new CatalogBooks());
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Books_Users books_users = new Books_Users
            {
                IDBook = books.ID,
                IDUser = AppSession.CurrentUser.ID,
                IDStatus = 2
            };
            Core.Context.Books_Users.Add(books_users);
            Core.Context.SaveChanges();
            NavigationService.Navigate(new CatalogBooks());
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Books_Users books_users = new Books_Users
            {
                IDBook = books.ID,
                IDUser = AppSession.CurrentUser.ID,
                IDStatus = 3
            };
            Core.Context.Books_Users.Add(books_users);
            Core.Context.SaveChanges();
            NavigationService.Navigate(new CatalogBooks());
        }
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            Books_Users books_users = new Books_Users
            {
                IDBook = books.ID,
                IDUser = AppSession.CurrentUser.ID,
                IDStatus = 4
            };
            Core.Context.Books_Users.Add(books_users);
            Core.Context.SaveChanges();
            NavigationService.Navigate(new CatalogBooks());
        }
    }
}
