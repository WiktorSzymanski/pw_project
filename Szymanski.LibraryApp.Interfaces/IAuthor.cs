namespace Szymanski.LibraryApp.Interfaces;

public interface IAuthor
{
    int Id { get; set; }
    string Name { get; set; }
    string Surname { get; set; }
    DateTime BirthDate { get; set; }
}