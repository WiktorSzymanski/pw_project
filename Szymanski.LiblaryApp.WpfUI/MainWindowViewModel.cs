using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Szymanski.LiblaryApp.WpfUI.View;
using Szymanski.LibraryApp.BL;
using Szymanski.LibraryApp.Interfaces;

namespace Szymanski.LiblaryApp.WpfUI;

public class MainWindowViewModel
{
    private BL BL;
    
    public IEnumerable<IBook> Books { get; }
    
    public MainWindowViewModel()
    {
        Console.WriteLine("Hello World!");
        string libraryName = System.Configuration.ConfigurationManager.AppSettings["DAOLibraryName"];
        BL = new BL(libraryName);

        Books = BL.GetBooks();
    }
}