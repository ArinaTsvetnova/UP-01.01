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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class CatalogBooks : Page
    {
        List<Books> AllBooks;
        List<Genres> genresort;
        public CatalogBooks()
        {
            InitializeComponent();
            AllBooks = Core.Context.Books.ToList();
            LbBooks.ItemsSource = AllBooks;

            List<Sortir> sort = new List<Sortir>()
            {
                new Sortir
                {
                    Name = "По названию (А-Я)",
                },
                new Sortir
                {
                    Name = "По рейтингу (Высокий)",
                },
                new Sortir
                {
                    Name = "-",
                }
            };
            CbSort.ItemsSource = sort;
            CbSort.DisplayMemberPath = "Name";
            CbSort.SelectedIndex = 2;

            genresort = Core.Context.Genres.ToList();
            CbGenreFilter.ItemsSource = genresort;
            CbGenreFilter.DisplayMemberPath = "Name";
            CbGenreFilter.SelectedIndex = 0;
        }
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Search.Text))
            {
                LbBooks.ItemsSource = AllBooks;
            }
            else
            {
                LbBooks.ItemsSource = Core.Context.Books.Where(f => f.Name.Contains(Search.Text)).ToList(); 
            }
        }
        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbGenreFilter.SelectedIndex == 0)
            {
                LbBooks.ItemsSource = null;
                LbBooks.ItemsSource = Core.Context.Books.OrderByDescending(f => f.Name).ToList();
            }
            else if (CbSort.SelectedIndex == 1)
            {
                LbBooks.ItemsSource = null;
                LbBooks.ItemsSource = Core.Context.Books.OrderByDescending(r => r.Rating).ToList();
            }
            else
            { }
        }
        private void CbGenreFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //LbBooks.ItemsSource = null;
            //LbBooks.ItemsSource = Core.Context.Books.OrderBy(f => f.Name).ToList();
        }

        private void BookCard_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Books selectBook = btn.DataContext as Books;
            if (selectBook == null)
            {
                MessageBox.Show("Книга недоступна, попробуйте зайти позднее");
            }
            NavigationService.Navigate(new BookCardPage(selectBook));
            if (NavigationService.CanGoForward)
            {
                NavigationService.GoForward();
            }
        }
    }
}
