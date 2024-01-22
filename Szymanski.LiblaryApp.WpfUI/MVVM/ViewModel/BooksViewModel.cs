using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Szymanski.LibraryApp.BL;
using Szymanski.LibraryApp.Core;
using Szymanski.LibraryApp.Interfaces;

namespace Szymanski.LiblaryApp.WpfUI.MVVM.ViewModel;

public class BooksViewModel : Core.ViewModel
{
    private BL _blc;
    public ObservableCollection<IBook> Books { get; }
    public ObservableCollection<IAuthor> Authors { get; }
    public ObservableCollection<IPublisher> Publishers { get; }
    public IEnumerable<Genre> AvailableGenres => Enum.GetValues(typeof(Genre)).Cast<Genre>();
    
    public BooksViewModel(BL bl)
    {
        _blc = bl;
        Books = new ObservableCollection<IBook>(_blc.GetBooks());
        Authors = new ObservableCollection<IAuthor>(_blc.GetAuthors());
        Publishers = new ObservableCollection<IPublisher>(_blc.GetPublishers());
    }
}

public class GenreCollectionConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is ICollection<Genre> genres)
        {
            return string.Join(", ", genres.Select(g => g.ToString()));
        }

        return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
