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
    
    public override void Refresh()
    {
        Publishers = new ObservableCollection<IPublisher>(_blc.GetPublishers().OrderBy(publisher => publisher.Id));
    }
}