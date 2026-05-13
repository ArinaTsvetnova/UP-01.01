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
using UP01._01.Pages;

namespace UP01._01
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (AppSession.CurrentUser.Freez == true)
            {

            }
        }
        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
        private void CatalogPage_Click(object sender, RoutedEventArgs e)
        {
            if (AppSession.CurrentUser == null)
            {
                MessageBox.Show("Для записи необходимо войти в аккаунт.");
            }
            else
            {
                MainFrame.Navigate(new CatalogBooks());
            }
        }

        private void ListPage_Click(object sender, RoutedEventArgs e)
        {
            if (AppSession.CurrentUser == null)
            {
                MessageBox.Show("Для записи необходимо войти в аккаунт.");
            }
            else
            {
                MainFrame.Navigate(new ListBooks());
            }
        }

        private void Author_Click(object sender, RoutedEventArgs e)
        {
            if (AppSession.CurrentUser == null)
            {
                MessageBox.Show("Для записи необходимо войти в аккаунт.");
            }
            else
            {
                if (AppSession.CurrentUser.IDRole == 2)
                {
                    MainFrame.Navigate(new AuthorAccount());
                }
                else
                {
                    MessageBox.Show("Вы не имеете прав автора!");
                }
            }
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            if (AppSession.CurrentUser == null)
            {
                MessageBox.Show("Для записи необходимо войти в аккаунт.");
            }
            else
            {
                if (AppSession.CurrentUser.IDRole == 3)
                {
                    MainFrame.Navigate(new AdminAccount());
                }
                else
                {
                    MessageBox.Show("Вы не имеете прав администратора!");
                }
            }
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            if (AppSession.CurrentUser == null)
            {
                MessageBox.Show("Для записи необходимо войти в аккаунт.");
            }
            else
            {
                MainFrame.Navigate(new AccountPage());
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            AppSession.CurrentUser = null;
            MainFrame.Navigate(new LoginPage());
        }
    }
}
