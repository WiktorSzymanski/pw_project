using Szymanski.LibraryApp.BL;
using Szymanski.LibraryApp.Interfaces;

namespace Szymanski.LibraryApp.CLI;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        string libraryName = System.Configuration.ConfigurationManager.AppSettings["DAOLiblaryName"];
        BL.BL blc = new BL.BL(libraryName);


        foreach (IBook book in blc.GetBooks())
        {
            Console.WriteLine($"{book.Id}: {book.Name}");
        }
        Console.WriteLine("==================================");
        
        foreach (IAuthor author in blc.GetAuthors())
        {
            Console.WriteLine($"{author.Id}: {author.Name}");
        }
        Console.WriteLine("==================================");
        
        foreach (IPublisher publisher in blc.GetPublishers())
        {
            Console.WriteLine($"{publisher.Id}: {publisher.Name}");
        }
    }
}
