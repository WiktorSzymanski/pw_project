using System;
using System.Collections.ObjectModel;
using Szymanski.LibraryApp.BL;
using Szymanski.LibraryApp.Interfaces;

namespace Szymanski.LiblaryApp.WpfUI.MVVM.ViewModel;

public class BooksViewModel : Core.ViewModel
{
    private BL _blc;
    public ObservableCollection<IBook> Books { get; }
    
    public BooksViewModel(BL bl)
    {
        _blc = bl;
        Books = new ObservableCollection<IBook>(_blc.GetBooks());

        foreach (IBook book in Books)
        {
            string genres = string.Join(",", book.Genres);
            Console.WriteLine($"{book.Id} | {book.Name} | {book.ReleaseYear} | {genres} | {book.Author.Name} {book.Author.Surname} | {book.Publisher.Name}");
        }
    }
}