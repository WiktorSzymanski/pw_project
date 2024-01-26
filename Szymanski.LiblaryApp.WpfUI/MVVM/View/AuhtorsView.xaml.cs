using System;
using System.Globalization;
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
        var column = e.Column;

 
        switch (column.Header)
        {
            case "Name":
                var nameTextBox = e.EditingElement as TextBox;
                if (nameTextBox != null)
                {
                    row.Name = nameTextBox.Text;
                }
                break;
            case "Surname":
                var surnameTextBox = e.EditingElement as TextBox;
                if (surnameTextBox != null)
                {
                    row.Surname = surnameTextBox.Text;
                }
                break;
            case "Birth Date":
                var birthDayTextBox = e.EditingElement as TextBox;
                if (birthDayTextBox != null)
                {
                    try
                    {
                        row.BirthDate = DateTime.ParseExact(birthDayTextBox.Text, "MM.dd.yyyy",
                            CultureInfo.CurrentCulture);
                    }
                    catch { }
                }
                break;
        }
        ((AuthorsViewModel)this.DataContext).UpdateRecord(row);
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