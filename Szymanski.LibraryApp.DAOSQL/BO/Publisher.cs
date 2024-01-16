using Szymanski.LibraryApp.Interfaces;

namespace Szymanski.LibraryApp.DAOSQL.BO;

public class Publisher: IPublisher
{
    public int Id { get; set; }
    public string Name { get; set; }
}