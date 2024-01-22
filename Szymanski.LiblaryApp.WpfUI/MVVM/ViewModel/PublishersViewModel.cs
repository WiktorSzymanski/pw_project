using System;
using System.Collections.ObjectModel;
using Szymanski.LibraryApp.BL;
using Szymanski.LibraryApp.Interfaces;

namespace Szymanski.LiblaryApp.WpfUI.MVVM.ViewModel;

public class PublishersViewModel : Core.ViewModel
{
    private BL _blc;
    public ObservableCollection<IPublisher> Publishers { get; }
    
    public PublishersViewModel(BL bl)
    {
        _blc = bl;
        Publishers = new ObservableCollection<IPublisher>(_blc.GetPublishers());

        foreach (IPublisher publisher in Publishers)
        {
            Console.WriteLine($"{publisher.Id} | {publisher.Name}");
        }
    }
}