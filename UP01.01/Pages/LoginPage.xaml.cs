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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            string Tlogin = login.Text.Trim();
            string Tpassword = password.Password;

            if (string.IsNullOrWhiteSpace(Tlogin) || string.IsNullOrEmpty(Tpassword))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }
            var user = Core.Context.Users.FirstOrDefault(u => u.Login == Tlogin);
            if (user == null)
            {
                MessageBox.Show("Пользователь с таким логином не найден.");
                return;
            }
            if (user.Freez)
            {
                MessageBox.Show("Ваш аккаунт заблокирован. Обратитесь к администратору.");
                NavigationService.Navigate(new CatalogBooks());
            }
            if (user.Password != Tpassword)
            {
                MessageBox.Show("Неверный пароль.");
                return;
            }
            AppSession.CurrentUser = user;
            if (AppSession.CurrentUser != null)
            {
                switch (AppSession.CurrentUser.IDRole)
                {
                    case 0: // Не существует
                        break;
                    case 1: // Читатель
                        NavigationService.Navigate(new CatalogBooks());
                        break;
                    case 2: // Автор
                        NavigationService.Navigate(new CatalogBooks());                     
                        break;
                    case 3: // Админ
                        NavigationService.Navigate(new CatalogBooks());                     
                        break;
                }
            }
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegPage());
        }
    }
}
