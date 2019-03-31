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
using System.Windows.Shapes;
using System.Data.SQLite;

namespace BooksWonderland
{
    /// <summary>
    /// Interaction logic for SimpleBook.xaml
    /// </summary>
    public partial class SimpleBook : Window
    {
        enum Operation
        {
            Add,
            Edit
        }

        Operation o;
        Book book;
        SQLiteConnection SQLiteConnection = new SQLiteConnection("Data Source=books.s3db");
        

        public SimpleBook(Book book)
        {
            InitializeComponent();
            o = Operation.Edit;
            this.book = book;
        }

        public SimpleBook()
        {
            InitializeComponent();
            o = Operation.Add;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (o == Operation.Edit)
            {
                AddBook.Content = "Zapisz";
                setAttributes();
            }
            else if(o == Operation.Add)
            {

            }
        }

        private void setAttributes()
        {
            TextBoxTitle.Text = book.Title;
            TextBoxAuthor.Text = book.Author;
            TextBoxPublisher.Text = book.Publisher;
            TextBoxPurchased.Text = book.PurchaseDate.ToShortDateString();
            TextBoxYear.Text = book.Year;
            TextBoxGenre.Text = book.Genre;
            TextBoxPrice.Text = book.Price;
            TextBoxPages.Text = book.Pages;
            TextBoxDescribe.Text = book.Describe;
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            if (o == Operation.Edit)
            {
                addNewBook();
            }
            else if (o == Operation.Add)
            {
                setBook();
            }
        }

        private void setBook()
        {
            SQLiteCommand oCommand = SQLiteConnection.CreateCommand();
            //oCommand.CommandText = "SELECT * FROM BookList";
            //oCommand.ExecuteNonQuery();
        }

        private void addNewBook()
        {
            SQLiteCommand oCommand = SQLiteConnection.CreateCommand();
            //oCommand.CommandText = "SELECT * FROM BookList";
            //oCommand.ExecuteNonQuery();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
