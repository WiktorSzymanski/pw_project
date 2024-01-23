using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Szymanski.LiblaryApp.WpfUI.MVVM.ViewModel;
using Szymanski.LibraryApp.BL;
using Szymanski.LibraryApp.Core;
using Szymanski.LibraryApp.Interfaces;

namespace Szymanski.LiblaryApp.WpfUI.MVVM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BooksView : UserControl
    {
        private IBook _oldBook;
        public BooksView()
        {
            InitializeComponent();
        }
        
        private void dg_Sorting(object sender, DataGridSortingEventArgs e)
        {
            var viewModel = DataContext as BooksViewModel;
            if (e.Column.Header.ToString() == "Author")
            {
                if (e.Column.SortDirection == null || e.Column.SortDirection == ListSortDirection.Descending)
                {
                    Dg.ItemsSource = new ObservableCollection<IBook>(from item in viewModel.Books
                        orderby item.Author?.Name ?? string.Empty ascending
                        select item);
                    e.Column.SortDirection = ListSortDirection.Ascending;
                }
                else
                {
                    Dg.ItemsSource = new ObservableCollection<IBook>(from item in viewModel.Books
                        orderby item.Author?.Name ?? string.Empty descending
                        select item);
                    e.Column.SortDirection = ListSortDirection.Descending;
                }
            } 
            else if (e.Column.Header.ToString() == "Publisher")
            {
                if (e.Column.SortDirection == null || e.Column.SortDirection == ListSortDirection.Descending)
                {
                    Dg.ItemsSource = new ObservableCollection<IBook>(from item in viewModel.Books
                        orderby item.Publisher?.Name ?? string.Empty ascending
                        select item);
                    e.Column.SortDirection = ListSortDirection.Ascending;
                }
                else
                {
                    Dg.ItemsSource = new ObservableCollection<IBook>(from item in viewModel.Books
                        orderby item.Publisher?.Name ?? string.Empty descending
                        select item);
                    e.Column.SortDirection = ListSortDirection.Descending;
                }
            }

            foreach (var dgColumn in Dg.Columns)
            {
                if (dgColumn.Header.ToString() != e.Column.Header.ToString())
                {
                    dgColumn.SortDirection = null;
                }
            }
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var row = (IBook)e.Row.Item;
            var column = e.Column;

 
            switch (column.Header)
            {
                case "Name":
                    var nameTextBox = e.EditingElement as TextBox;
                    if (nameTextBox != null)
                    {
                        row.Name = nameTextBox.Text;
                    }
                    break;
                case "Author":
                    var authorComboBox = e.EditingElement as ComboBox;
                    if (authorComboBox != null)
                    {
                        row.Author = (IAuthor)authorComboBox.SelectedItem;
                    }
                    break;
                case "Publisher":
                    var publisherComboBox = e.EditingElement as ComboBox;
                    if (publisherComboBox != null)
                    {
                        row.Publisher = (IPublisher)publisherComboBox.SelectedItem;
                    }
                    break;
                case "Release Year":
                    var releaseYearTextBox = e.EditingElement as TextBox;
                    if (releaseYearTextBox != null)
                    {
                        row.ReleaseYear = int.Parse(releaseYearTextBox.Text);
                    }
                    break;
                case "Genre":
                    var genreComboBox = e.EditingElement as ComboBox;
                    if (genreComboBox != null)
                    {
                        row.Genre = (Genre)Enum.Parse(typeof(Genre), genreComboBox.SelectedItem.ToString());
                    }
                    break;
            }
            ((BooksViewModel)this.DataContext).UpdateRecord(row);
        }
        
        private void AddNewBookButton_Click(object sender, RoutedEventArgs e)
        {
            ((BooksViewModel)this.DataContext).CreateEmptyRecord();
        }

        private void RemoveSelectedBooksButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedBooks = Dg.SelectedItems.Cast<IBook>().ToList();
            ((BooksViewModel)this.DataContext).RemoveBooks(selectedBooks);
        }
    }
}