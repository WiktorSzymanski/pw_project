using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Szymanski.LibraryApp.BL;
using Szymanski.LibraryApp.Interfaces;

namespace Szymanski.LiblaryApp.WpfUI.MVVM.ViewModel;

public class AuthorsViewModel : Core.ViewModel
{
    private BL _blc;
    private ObservableCollection<IAuthor> _authors;

    public ObservableCollection<IAuthor> Authors
    {
        get { return _authors; }
        set
        {
            _authors = value;
            OnPropertyChanged("Authors");
        }
    }
    
    public AuthorsViewModel(BL bl)
    {
        _blc = bl;
        Authors = new ObservableCollection<IAuthor>(_blc.GetAuthors());
    }
    
    public void UpdateRecord(IAuthor author)
    {
        _blc.UpdateAuthor(author.Id, author.Name, author.Surname, author.BirthDate);
    }

    public void CreateEmptyRecord()
    {
        _blc.CreateNewAuthor(0 , "New Name", "New Surname", new DateTime());
        Refresh();
    }

    public void RemoveRecord(List<IAuthor> selected)
    {
        foreach (var author in selected)
        {
            _blc.DeleteAuthor(author.Id);
        }

        Refresh();
    }
    
    public override void Refresh()
    {
        Authors = new ObservableCollection<IAuthor>(_blc.GetAuthors().OrderBy(author => author.Id));
    }
}