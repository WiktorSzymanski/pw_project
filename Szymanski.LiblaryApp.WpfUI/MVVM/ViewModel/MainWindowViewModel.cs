using System;
using System.Collections.ObjectModel;
using Szymanski.LiblaryApp.WpfUI.Core;
using Szymanski.LiblaryApp.WpfUI.Services;
using Szymanski.LibraryApp.BL;
using Szymanski.LibraryApp.Interfaces;

namespace Szymanski.LiblaryApp.WpfUI.MVVM.ViewModel;

public class MainWindowViewModel : Core.ViewModel
{
    private INavigationService _navigation;

    public INavigationService Navigation
    {
        get => _navigation;
        set
        {
            _navigation = value;
            OnPropertyChanged();
        }
    }
    
    public RelayCommand NavigateAuthorsCommand { get; set; }
    public RelayCommand NavigateBooksCommand { get; set; }
    public RelayCommand NavigatePublishersCommand { get; set; }
    
    public MainWindowViewModel(INavigationService navigationService)
    {
        Navigation = navigationService;
        NavigateAuthorsCommand = new RelayCommand(o => { Navigation.NavigateTo<AuthorsViewModel>(); }, o => true);
        NavigateBooksCommand = new RelayCommand(o => { Navigation.NavigateTo<BooksViewModel>(); }, o => true);
        NavigatePublishersCommand = new RelayCommand(o => { Navigation.NavigateTo<PublishersViewModel>(); }, o => true);
    }
    
    // private BL BL;
    // public ObservableCollection<IBook> BooksObservable { get; }
    //
    // public MainWindowViewModel()
    // {
    //     Console.WriteLine("Hello There!");
    //     string libraryName = System.Configuration.ConfigurationManager.AppSettings["DAOLibraryName"];
    //     BL = new BL(libraryName);
    //
    //     BooksObservable = new ObservableCollection<IBook>(BL.GetBooks());
    //     foreach (var book in BooksObservable)
    //     {
    //         Console.WriteLine($"{book.Id} {book.Name}");
    //     }
    // }
}