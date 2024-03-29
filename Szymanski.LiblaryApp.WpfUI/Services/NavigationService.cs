using System;
using System.Windows.Controls;
using Szymanski.LiblaryApp.WpfUI.Core;
using Szymanski.LiblaryApp.WpfUI.MVVM.ViewModel;

namespace Szymanski.LiblaryApp.WpfUI.Services;

public interface INavigationService
{
    ViewModel CurrentView { get; }
    void NavigateTo<T>() where T : ViewModel;
}

public class NavigationService : ObservableObject, INavigationService
{
    private ViewModel _currentView;
    private readonly Func<Type, ViewModel> _viewModelFactory;

    public ViewModel CurrentView
    {
        get => _currentView;
        private set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    public NavigationService(Func<Type, ViewModel> viewModelFactory)
    {
        _viewModelFactory = viewModelFactory;
        CurrentView = _viewModelFactory.Invoke(typeof(BooksViewModel));
    }
    
    public void NavigateTo<TViewModel>() where TViewModel : ViewModel
    {
        ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
        CurrentView = viewModel;
        CurrentView.Refresh();
    }
}