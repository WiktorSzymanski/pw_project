using System;
using System.Collections.ObjectModel;
using Szymanski.LibraryApp.BL;
using Szymanski.LibraryApp.Interfaces;

namespace Szymanski.LiblaryApp.WpfUI.MVVM.ViewModel;

public class AuthorsViewModel : Core.ViewModel
{
    private BL _blc;
    public ObservableCollection<IAuthor> Authors { get; }
    
    public AuthorsViewModel(BL bl)
    {
        _blc = bl;
        Authors = new ObservableCollection<IAuthor>(_blc.GetAuthors());

        foreach (IAuthor author in Authors)
        {
            Console.WriteLine($"{author.Id} | {author.Name} | {author.Surname} | {author.BirthDate}");
        }
    }
}