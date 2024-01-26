using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Szymanski.LibraryApp.BL;
using Szymanski.LibraryApp.Interfaces;

namespace Szymanski.LiblaryApp.WpfUI.MVVM.ViewModel;

public class PublishersViewModel : Core.ViewModel
{
    private BL _blc;

    private ObservableCollection<IPublisher> _publishers;
    public ObservableCollection<IPublisher> Publishers
    {
        get { return _publishers; }
        set
        {
            _publishers = value;
            OnPropertyChanged("Publishers");
        }
    }
    
    private string _publisherSearch = string.Empty;
    public string PublisherSearch
    {
        get
        {
            return _publisherSearch;
        }
        set
        {
            _publisherSearch = value;
            OnPropertyChanged(nameof(PublisherSearch));
            SearchPublishers();
            Refresh();
        }
    }

    private Func<IPublisher, bool> _whereFilter = author => true;
    
    public PublishersViewModel(BL bl)
    {
        _blc = bl;
        Publishers = new ObservableCollection<IPublisher>(_blc.GetPublishers());
    }
    
    public void UpdateRecord(IPublisher publisher)
    {
        _blc.UpdatePublisher(publisher.Id, publisher.Name);
    }

    public void CreateEmptyRecord()
    {
        _blc.CreateNewPublisher(0 , "New Name");
        Refresh();
    }

    public void RemoveRecord(List<IPublisher> selected)
    {
        foreach (var publisher in selected)
        {
            _blc.DeletePublisher(publisher.Id);
        }

        Refresh();
    }
    
    private void SearchPublishers()
    {
            _whereFilter = string.IsNullOrEmpty(PublisherSearch) ?
                _ => true :
                publisher => publisher.Name.Contains(PublisherSearch,
                                 StringComparison.InvariantCultureIgnoreCase) ||
                             publisher.Id.ToString().Contains(PublisherSearch, 
                                 StringComparison.InvariantCultureIgnoreCase);
    }
    
    public override void Refresh()
    {
        Publishers = new ObservableCollection<IPublisher>(_blc.GetPublishers().OrderBy(publisher => publisher.Id).Where(_whereFilter));
    }
}