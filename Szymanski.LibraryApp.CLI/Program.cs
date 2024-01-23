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
        
        // var au1 = blc.GetAuthors().FirstOrDefault(author => author.Id == 1);
        // var pu1 = blc.GetPublishers().FirstOrDefault(publisher => publisher.Id == 1);
        //
        // blc.CreateNewBook(2, "Spooky stuff", au1, pu1, 2000, Genre.Horror);


        var au = blc.GetAuthors().FirstOrDefault(author => author.Id == 1);
        var pu = blc.GetPublishers().FirstOrDefault(publisher => publisher.Id == 1);
        //
        // blc.CreateNewBook(1, "DAMN book", au, pu, 2019, Genre.Fantasy);
        

        blc.UpdateAuthor(1, "Joe", "Biden", new DateTime(2001, 03, 05));
        blc.UpdatePublisher(1, "NOICE");

        blc.UpdateBook(1, "New name", au, pu, 2077, Genre.Fantasy);
        
        // blc.DeleteAuthor(1);
        // blc.DeletePublisher(1);

        foreach (IBook book in blc.GetBooks())
        {
            Console.WriteLine($"{book.Id} | {book.Name} | {book.ReleaseYear} | {book.Genre} | {book.Author.Name} {book.Author.Surname} | {book.Publisher.Name}");
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
