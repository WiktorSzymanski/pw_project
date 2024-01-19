using Szymanski.LibraryApp.BL;
using Szymanski.LibraryApp.Core;
using Szymanski.LibraryApp.Interfaces;

namespace Szymanski.LibraryApp.CLI;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        string libraryName = System.Configuration.ConfigurationManager.AppSettings["DAOLibraryName"];
        BL.BL blc = new BL.BL(libraryName);

        // blc.CreateNewAuthor(2, "Daniel", "Damn", new DateTime(2010, 01, 01));
        // blc.CreateNewPublisher(2, "DamnProducer");

        // var au = blc.GetAuthors().FirstOrDefault(author => author.Id == 2);
        // var pu = blc.GetPublishers().FirstOrDefault(publisher => publisher.Id == 2);

        // blc.CreateNewBook(2, "DAMN book", au, pu, 2019, new HashSet<Genre>() { Genre.Fantasy, Genre.Horror });

        // blc.UpdateAuthor(1, "Joe", "Biden", new DateTime(2001, 03, 05));
        // blc.UpdatePublisher(1, "NOICE");
        
        // blc.DeleteAuthor(1);
        // blc.DeletePublisher(1);

        foreach (IBook book in blc.GetBooks())
        {
            string genres = string.Join(",", book.Genres);
            Console.WriteLine($"{book.Id} | {book.Name} | {book.ReleaseYear} | {genres} | {book.Author.Name} {book.Author.Surname} | {book.Publisher.Name}");
        }
        Console.WriteLine("==================================");
        
        foreach (IAuthor author in blc.GetAuthors())
        {
            Console.WriteLine($"{author.Id} | {author.Name} | {author.Surname} | {author.BirthDate}");
        }
        Console.WriteLine("==================================");
        
        foreach (IPublisher publisher in blc.GetPublishers())
        {
            Console.WriteLine($"{publisher.Id} | {publisher.Name}");
        }
    }
}
