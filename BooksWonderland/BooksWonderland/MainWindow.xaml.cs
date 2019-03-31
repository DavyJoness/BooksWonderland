using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BooksWonderland
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SQLiteDataAdapter dataAdapter = null;
        private DataSet dataSet = null;
        private DataTable dataTable = null;
        private List<Book> books = new List<Book>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetData();
        }

        private void GetData()
        {
            Book book;
            SQLiteConnection SQLiteConnection = new SQLiteConnection("Data Source=books.s3db");
            SQLiteCommand oCommand = SQLiteConnection.CreateCommand();
            oCommand.CommandText = "SELECT * FROM BookList";
            dataAdapter = new SQLiteDataAdapter(oCommand.CommandText, SQLiteConnection);
            SQLiteCommandBuilder oCommandBuilder = new SQLiteCommandBuilder(dataAdapter);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            foreach (DataRow dr in dataSet.Tables[0].Rows)
            {
                book = new Book();
                book.Id = Convert.ToInt32(dr["id"]);
                book.Title = dr["title"].ToString();
                book.Author = dr["author"].ToString();
                book.Publisher = dr["publisher"].ToString();
                book.Year = dr["year"].ToString();
                book.Genre = dr["genre"].ToString();
                book.PurchaseDate = Convert.ToDateTime(dr["purchased"]);
                book.Price = dr["price"].ToString();
                book.Pages = dr["pages"].ToString();
                //book.Describe = dr["describe"].ToString();

                books.Add(book);
            }

            prepareGrid();
            SetStatus(SetStatusText());
        }

        private void prepareGrid()
        {
            DataGridTextColumn column;

            dataTable = dataSet.Tables[0];
            gridBooks.AutoGenerateColumns = false;
            gridBooks.ItemsSource = books;

            column = new DataGridTextColumn();
            column.Header = "Tytuł";
            column.Binding = new Binding("Title");
            column.Width = new DataGridLength(50, DataGridLengthUnitType.Star);
            gridBooks.Columns.Add(column);

            column = new DataGridTextColumn();
            column.Header = "Autor";
            column.Binding = new Binding("Author");
            gridBooks.Columns.Add(column);

            column = new DataGridTextColumn();
            column.Header = "Wydawca";
            column.Binding = new Binding("Publisher");
            gridBooks.Columns.Add(column);

            column = new DataGridTextColumn();
            column.Header = "Rok wydania";
            column.Binding = new Binding("Year");
            gridBooks.Columns.Add(column);

            column = new DataGridTextColumn();
            column.Header = "Gatunek";
            column.Binding = new Binding("Genre");
            gridBooks.Columns.Add(column);

            column = new DataGridTextColumn();
            column.Header = "Data zakupu";
            column.Binding = new Binding("PurchaseDate");
            column.Binding.StringFormat = "dd.MM.yyyy";
            gridBooks.Columns.Add(column);


            column = new DataGridTextColumn();
            column.Header = "Cena [zł]";
            column.Binding = new Binding("Price");
            gridBooks.Columns.Add(column);

            column = new DataGridTextColumn();
            column.Header = "Ilość stron";
            column.Binding = new Binding("Pages");
            gridBooks.Columns.Add(column);

            gridBooks.DataContext = dataTable.DefaultView;
        }

        private void MenuItem_Add(object sender, RoutedEventArgs e)
        {
            SimpleBook sb = new SimpleBook();
            sb.ShowDialog();
            if (sb.DialogResult == DialogResult.Value)
            {
                GetData();
            }
        }

        private void MenuItem_Edit(object sender, RoutedEventArgs e)
        {
            int i = gridBooks.SelectedIndex;

            Book book = books[i];

            SimpleBook sb = new SimpleBook(book);
            sb.ShowDialog();
            if (sb.DialogResult.HasValue && sb.DialogResult.Value)
            {
                GetData();
            }
        }

        private void MenuItem_About(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SetStatus(string text)
        {
            TextStatus.Text = text;
        }

        private string SetStatusText()
        {
            int booksNumber = books.Count;
            string res = $"Znaleziono {booksNumber} ";

            if(booksNumber == 1)
                res = res + "książkę.";
            else if(booksNumber>=11 && booksNumber <= 19)
                res = res + "książek.";
            else if(booksNumber.ToString().EndsWith("2")|| booksNumber.ToString().EndsWith("3") || booksNumber.ToString().EndsWith("4"))
                res = res + "książki.";
            else
                res = res + "książek.";

            return res;
        }
    }
}
