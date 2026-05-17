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
using static System.Collections.Specialized.BitVector32;

namespace UP01._01.Pages
{
    /// <summary>
    /// Логика взаимодействия для BookCardPage.xaml
    /// </summary>
    public partial class BookCardPage : Page
    {
        public Books books { get; set; }
        public BookCardPage(Books b)
        {
            InitializeComponent();
            if (AppSession.CurrentUser != null && AppSession.CurrentUser.IDRole == 3)
            {
                Block.Visibility = Visibility.Visible;
            }
            books = b;
            this.DataContext = this;
            foreach (var a in books.Book_Genre)
                ganre.Text = a.Genres.Name;
        }

        private void Read_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Text());
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AlBook_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AlAuthor_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BookRewie_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Block_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
