using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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
            SQLiteConnection SQLiteConnection = new SQLiteConnection("Data Source=books.s3db");
            SQLiteCommand oCommand = SQLiteConnection.CreateCommand();
            oCommand.CommandText = "SELECT * FROM BookList";
            dataAdapter = new SQLiteDataAdapter(oCommand.CommandText, SQLiteConnection);
            SQLiteCommandBuilder oCommandBuilder = new SQLiteCommandBuilder(dataAdapter);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            dataTable = dataSet.Tables[0];
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
            DataRow r = dataSet.Tables[0].Rows.Add; //Odwolanie do zaznaczonego row
            Book book = new Book(r);

            SimpleBook sb = new SimpleBook(book);
            sb.ShowDialog();
            if (sb.DialogResult == DialogResult.Value)
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
    }
}
