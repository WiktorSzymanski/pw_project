using Szymanski.LibraryApp.Interfaces;

namespace Szymanski.LibraryApp.DAOFile.BO;

public class Publisher: IPublisher
{
    public int Id { get; set; }
    public string Name { get; set; }
}