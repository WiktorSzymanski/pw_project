using System.Collections.Generic;
using Szymanski.LibraryApp.Core;

namespace Szymanski.LiblaryApp.WpfUI.View;

public class BookView
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public int ReleaseYear { get; set; }
    public ICollection<Genre> Genres { get; set; }
}