using Szymanski.LibraryApp.Interfaces;

namespace Szymanski.LibraryApp.DAOMock2.BO;

public class Author: IAuthor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
}