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
        List<Reviews> reviews { get; set; }
        public BookCardPage(Books b)
        {
            InitializeComponent();
            reviews = Core.Context.Reviews.ToList();
            books = b;
            this.DataContext = this;
            foreach (var a in books.Book_Genre)
                ganre.Text = a.Genres.Name;
            if (AppSession.CurrentUser != null && AppSession.CurrentUser.IDRole == 3 && books.Freez == false)
            {
                Block.Visibility = Visibility.Visible;
            }
            else if (AppSession.CurrentUser != null && AppSession.CurrentUser.IDRole == 3 && books.Freez == true)
            {
                Unblock.Visibility = Visibility.Visible;
            }
            Rewie.ItemsSource = reviews.Where(r => r.IDBook == books.ID);
        }

        private void Read_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Text());
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddBookPage());
        }

        private void AlBook_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AligBook());
        }

        private void AlAuthor_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AligAuthor());
        }
        private void BookRewie_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RewieBook());
        }
        private void Block_Click(object sender, RoutedEventArgs e)
        {
            Core.Context.Books.First(u => u.ID == books.ID).Freez = true;
            Core.Context.SaveChanges();
        }

        private void AligRew_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AligRewie());
        }

        private void Unblock_Click(object sender, RoutedEventArgs e)
        {
            Core.Context.Books.First(u => u.ID == books.ID).Freez = false;
            Core.Context.SaveChanges();
        }

        //private void RewBlock_Click(object sender, RoutedEventArgs e)
        //{
        //    Core.Context.Reviews.First(u => u.IDBook == books.ID).Freez = true;
        //    Core.Context.SaveChanges();
        //}

        //private void RewUnblock_Click(object sender, RoutedEventArgs e)
        //{
        //    Core.Context.Reviews.First(u => u.IDBook == books.ID).Freez = false;
        //    Core.Context.SaveChanges();
        //}
    }
}
