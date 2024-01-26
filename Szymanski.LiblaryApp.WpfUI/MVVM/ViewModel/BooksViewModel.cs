using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Szymanski.LibraryApp.BL;
using Szymanski.LibraryApp.Core;
using Szymanski.LibraryApp.Interfaces;

namespace Szymanski.LiblaryApp.WpfUI.MVVM.ViewModel;

public class BooksViewModel : Core.ViewModel
{
    private BL _blc;
    
    private ObservableCollection<IBook> _books;
    private ObservableCollection<IAuthor> _authors;
    private ObservableCollection<IPublisher> _publishers;

    public ObservableCollection<IBook> Books
    {
        get { return _books; }
        set
        {
            _books = value;
            OnPropertyChanged("Books");
        }
    }

    public ObservableCollection<IAuthor> Authors
    {
        get { return _authors; }
        set
        {
            _authors = value;
            OnPropertyChanged("Authors");
        }
    }
    
    public ObservableCollection<IPublisher> Publishers
    {
        get { return _publishers; }
        set
        {
            _publishers = value;
            OnPropertyChanged("Publishers");
        }
    }
    
    private string _bookSearch = string.Empty;
    public string BookSearch
    {
        get
        {
            return _bookSearch;
        }
        set
        {
            _bookSearch = value;
            OnPropertyChanged(nameof(BookSearch));
            SearchBooks();
            Refresh();
        }
    }

    private Func<IBook, bool> _whereFilter = book => true;

    public IEnumerable<Genre> AvailableGenres => Enum.GetValues(typeof(Genre)).Cast<Genre>();
    
    public BooksViewModel(BL bl)
    {
        _blc = bl;
        Books = new ObservableCollection<IBook>(_blc.GetBooks().OrderBy(book => book.Id));
        Authors = new ObservableCollection<IAuthor>(_blc.GetAuthors());
        Publishers = new ObservableCollection<IPublisher>(_blc.GetPublishers());
    }
    
    public void UpdateRecord(IBook book)
    {
        _blc.UpdateBook(book.Id, book.Name, book.Author, book.Publisher, book.ReleaseYear, book.Genre);
    }

    public void CreateEmptyRecord()
    {
        _blc.CreateNewBook(0 , "New Book", null, null, 0, 0);
        Refresh();
    }

    public void RemoveBooks(List<IBook> selectedBooks)
    {
        foreach (var book in selectedBooks)
        {
            _blc.DeleteBook(book.Id);
        }

        Refresh();
    }

    private void SearchBooks()
    {
        _whereFilter = string.IsNullOrEmpty(BookSearch) ?
            _ => true :
            book => book.Name.Contains(BookSearch, StringComparison.InvariantCultureIgnoreCase) ||
                    (book.Author?.Name.Contains(BookSearch,
                        StringComparison.InvariantCultureIgnoreCase) ?? false) ||
                    (book.Author?.Surname.Contains(BookSearch,
                        StringComparison.InvariantCultureIgnoreCase) ?? false) ||
                    (book.Publisher?.Name.Contains(BookSearch,
                        StringComparison.InvariantCultureIgnoreCase) ?? false) ||
                    book.Genre.ToString().Contains(BookSearch,
                        StringComparison.InvariantCultureIgnoreCase) ||
                    book.Id.ToString().Contains(BookSearch,
                        StringComparison.InvariantCultureIgnoreCase) ||
                    book.ReleaseYear.ToString().Contains(BookSearch,
                        StringComparison.InvariantCultureIgnoreCase);
    }
    
    public override void Refresh()
    {
        Books = new ObservableCollection<IBook>(_blc.GetBooks().OrderBy(book => book.Id).Where(_whereFilter));
        Authors = new ObservableCollection<IAuthor>(_blc.GetAuthors());
        Publishers = new ObservableCollection<IPublisher>(_blc.GetPublishers());
    }
}