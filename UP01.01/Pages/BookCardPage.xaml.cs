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
            books = b;
            this.DataContext = this;
        }
    }
}
