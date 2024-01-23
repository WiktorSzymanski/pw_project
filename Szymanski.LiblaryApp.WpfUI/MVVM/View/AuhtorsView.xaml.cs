using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Szymanski.LiblaryApp.WpfUI.MVVM.ViewModel;
using Szymanski.LibraryApp.Interfaces;

namespace Szymanski.LiblaryApp.WpfUI.MVVM.View;

public partial class AuhtorsView : UserControl
{
    public AuhtorsView()
    {
        InitializeComponent();
    }
    
    private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        var row = (IAuthor)e.Row.Item;

        var nameTextBox = e.EditingElement as TextBox;
        if (nameTextBox != null)
        {
            row.Name = nameTextBox.Text;
            ((AuthorsViewModel)this.DataContext).UpdateRecord(row);
        }
    }
    
    private void AddNewRecordButton_Click(object sender, RoutedEventArgs e)
    {
        ((AuthorsViewModel)this.DataContext).CreateEmptyRecord();
    }

    private void RemoveSelectedRecordButton_Click(object sender, RoutedEventArgs e)
    {
        var selectedBooks = Dg.SelectedItems.Cast<IAuthor>().ToList();
        ((AuthorsViewModel)this.DataContext).RemoveRecord(selectedBooks);
    }
}