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
        List<Authors> Authors = new List<Authors>();
        List<Publishers> Publishers = new List<Publishers>();
        List<Genres> Genres = new List<Genres>();

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
            getAuthors();
            getPublishers();
            getGenres();

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
            if (IsValid())
            {
                setBook();
            }

            this.DialogResult = true;
            this.Close();
        }

        private bool IsValid()
        {
            bool res = true;

            if (TextBoxTitle.Text == "")
            {
                MessageBox.Show($"Podaj tytuł", "BooksWonderland", MessageBoxButton.OK, MessageBoxImage.Information);
                res = false;
            }

            if (TextBoxAuthor.Text == "")
            {
                MessageBox.Show($"Podaj lub wybierz autora", "BooksWonderland", MessageBoxButton.OK, MessageBoxImage.Information);
                res = false;
            }

            if (TextBoxPublisher.Text == "")
            {
                MessageBox.Show($"Podaj lub wybierz wydawce", "BooksWonderland", MessageBoxButton.OK, MessageBoxImage.Information);
                res = false;
            }

            if (TextBoxGenre.Text == "")
            {
                MessageBox.Show($"Podaj lub wybierz gatunek literacki", "BooksWonderland", MessageBoxButton.OK, MessageBoxImage.Information);
                res = false;
            }

            if (TextBoxPurchased.Text == "")
            {
                MessageBox.Show($"Podaj datę zakupu", "BooksWonderland", MessageBoxButton.OK, MessageBoxImage.Information);
                res = false;
            }

            if (TextBoxYear.Text == "")
            {
                MessageBox.Show($"Podaj rok wydania", "BooksWonderland", MessageBoxButton.OK, MessageBoxImage.Information);
                res = false;
            }

            if (TextBoxPrice.Text == "")
            {
                MessageBox.Show($"Podaj cenę zakupu", "BooksWonderland", MessageBoxButton.OK, MessageBoxImage.Information);
                res = false;
            }

            if (TextBoxPages.Text == "")
            {
                MessageBox.Show($"Podaj ilość stron", "BooksWonderland", MessageBoxButton.OK, MessageBoxImage.Information);
                res = false;
            }

            return res;
        }

        private void setBook()
        {
            SQLiteCommand oCommand = SQLiteConnection.CreateCommand();
            string queryBooks = "";

            bool isAuthor = Authors.Any(a => a.Author == TextBoxAuthor.Text);
            bool isPublisher = Publishers.Any(a => a.Publisher == TextBoxPublisher.Text);
            bool isGenre = Genres.Any(a => a.Genre == TextBoxGenre.Text);

            int authorId = 0;
            int publisherId = 0;
            int genreId = 0;

            if (isAuthor)
                authorId = Authors.Where(a => a.Author == TextBoxAuthor.Text).ToList()[0].Id;
            else
                authorId = AddNewAuthor();

            if (isPublisher)
                publisherId = Publishers.Where(a => a.Publisher == TextBoxPublisher.Text).ToList()[0].Id;
            else
                publisherId = AddNewPublisher();

            if (isGenre)
                genreId = Genres.Where(a => a.Genre == TextBoxGenre.Text).ToList()[0].Id;
            else
                genreId = AddNewGenre();
            if (o == Operation.Add)
                queryBooks = $@"insert into Books(title, author_id, publisher_id, year, genre_id, purchase_date, price, pages)
                            values ('{TextBoxTitle.Text}',{authorId},{publisherId},'{TextBoxYear.Text}',{genreId}
                                ,'{Convert.ToDateTime(TextBoxPurchased.Text).ToString("yyyy-MM-dd")}',{TextBoxPrice.Text.Replace(",", ".")}
                                ,{TextBoxPages.Text})";
            else if (o == Operation.Edit)
                queryBooks = $@"update Books
                            set title = '{TextBoxTitle.Text}', author_id = {authorId}, publisher_id = {publisherId}, year = '{TextBoxYear.Text}', 
                                genre_id = {genreId}, purchase_date = '{Convert.ToDateTime(TextBoxPurchased.Text).ToString("yyyy-MM-dd")}'
                                , price = {TextBoxPrice.Text.Replace(",", ".")}, pages = {TextBoxPages.Text}
                            where id = {book.Id}";

            if (authorId != 0 && publisherId != 0 && genreId != 0)
            {
                try
                {
                    SQLiteConnection.Open();
                    oCommand.CommandText = queryBooks;
                    oCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    if (o == Operation.Add)
                        MessageBox.Show($"Wystąpił błąd przy dodawaniu nowej książki: {ex.Message}", "BooksWonderland", MessageBoxButton.OK, MessageBoxImage.Error);
                    else if (o == Operation.Edit)
                        MessageBox.Show($"Wystąpił błąd przy modyfikowaniu książki: {ex.Message}", "BooksWonderland", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    SQLiteConnection.Close();
                }
            }
            else
            {
                MessageBox.Show($"Błąd pustych wartosci: kod: {authorId} {publisherId} {genreId}", "BooksWonderland", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private int AddNewGenre()
        {
            int res = 0;
            SQLiteCommand oCommand = SQLiteConnection.CreateCommand();

            string query = $@"insert into Genre(genre_name) values ('{TextBoxGenre.Text}'); select id from Genre where genre_name = '{TextBoxGenre.Text}'";
            try
            {
                SQLiteConnection.Open();
                oCommand.CommandText = query;
                using (SQLiteDataReader reader = oCommand.ExecuteReader())
                {
                    reader.Read();
                    res = reader.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd przy dodawaniu nowego gatunku literackiego: {ex.Message}", "BooksWonderland", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                SQLiteConnection.Close();
            }

            return res;
        }

        private int AddNewPublisher()
        {
            int res = 0;
            SQLiteCommand oCommand = SQLiteConnection.CreateCommand();

            string query = $@"insert into Publisher(publisher_name) values ('{TextBoxPublisher.Text}'); select id from Publisher where publisher_name = '{TextBoxPublisher.Text}'";
            try
            {
                SQLiteConnection.Open();
                oCommand.CommandText = query;
                using (SQLiteDataReader reader = oCommand.ExecuteReader())
                {
                    reader.Read();
                    res = reader.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd przy dodawaniu nowego wydawcy: {ex.Message}", "BooksWonderland", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                SQLiteConnection.Close();
            }

            return res;
        }

        private int AddNewAuthor()
        {
            int res = 0;
            SQLiteCommand oCommand = SQLiteConnection.CreateCommand();

            string query = $@"insert into Author(author_name) values ('{TextBoxAuthor.Text}'); select id from Author where author_name = '{TextBoxAuthor.Text}'";
            try
            {
                SQLiteConnection.Open();
                oCommand.CommandText = query;
                using (SQLiteDataReader reader = oCommand.ExecuteReader())
                {
                    reader.Read();
                    res = reader.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd przy dodawaniu nowego autora: {ex.Message}", "BooksWonderland", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                SQLiteConnection.Close();
            }

            return res;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.DialogResult = false;
        }

        private void getAuthors()
        {

            try
            {
                SQLiteConnection.Open();
                SQLiteCommand oCommand = SQLiteConnection.CreateCommand();
                oCommand.CommandText = "SELECT id, author_name FROM Author";
                using (SQLiteDataReader reader = oCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Authors.Add(new Authors(reader.GetInt32(0), reader.GetString(1)));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd przy pobieraniu listy autorów: {ex.Message}", "BooksWonderland", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                SQLiteConnection.Close();
            }

            TextBoxAuthor.ItemsSource = Authors;  
        }

        private void getPublishers()
        {
            try
            {
                SQLiteConnection.Open();
                SQLiteCommand oCommand = SQLiteConnection.CreateCommand();
                oCommand.CommandText = "SELECT id, publisher_name FROM Publisher";
                using (SQLiteDataReader reader = oCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Publishers.Add(new Publishers(reader.GetInt32(0), reader.GetString(1)));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd przy pobieraniu listy wydawców: {ex.Message}", "BooksWonderland", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                SQLiteConnection.Close();
            }

            TextBoxPublisher.ItemsSource = Publishers;
        }

        private void getGenres()
        {
            try
            {
                SQLiteConnection.Open();
                SQLiteCommand oCommand = SQLiteConnection.CreateCommand();
                oCommand.CommandText = "SELECT id, genre_name FROM Genre";
                using (SQLiteDataReader reader = oCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Genres.Add(new Genres(reader.GetInt32(0), reader.GetString(1)));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd przy pobieraniu listy garunków literackich: {ex.Message}", "BooksWonderland", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                SQLiteConnection.Close();
            }

            TextBoxGenre.ItemsSource = Genres;
        }
    }
}
