using Newtonsoft.Json;
using Szymanski.LibraryApp.Core;
using Szymanski.LibraryApp.DAOFile.BO;
using Szymanski.LibraryApp.Interfaces;

namespace Szymanski.LibraryApp.DAOFile;

public class DAOFile : IDAO
{
    private const string DataFile = "data.json";
    
    public IEnumerable<IBook> GetAllBooks()
    {
        return LoadData().Books;
    }

    public IEnumerable<IAuthor> GetAllAuthors()
    {
        return LoadData().Authors;
    }

    public IEnumerable<IPublisher> GetAllPublishers()
    {
        return LoadData().Publishers;
    }
    
    public IBook CreateNewBook(int id, string name, IAuthor author, IPublisher publisher, int releaseYear, ICollection<Genre> genres)
    {
        var data = LoadData();
        var book = new Book() {Id = id, Name = name, Author = author, Publisher = publisher, ReleaseYear = releaseYear, Genres = genres};
        data.Books.Add(book);
        SaveData(data);
        return book;
    }

    public IAuthor CreateNewAuthor(int id, string name, string surname, DateTime birthDate)
    {
        var data = LoadData();
        var author = new Author() {Id = id, Name = name, Surname = surname, BirthDate = birthDate};
        data.Authors.Add(author);
        SaveData(data);
        return author;
    }

    public IPublisher CreateNewPublisher(int id, string name)
    {
        var data = LoadData();
        var publisher = new Publisher() {Id = id, Name = name};
        data.Publishers.Add(publisher);
        SaveData(data);
        return publisher;
    }
    
    public IBook UpdateBook(int id, string name, IAuthor author, IPublisher publisher, int releaseYear, ICollection<Genre> genres)
    {
        var data = LoadData();
        var book = data.Books.FirstOrDefault(b => b.Id == id);
        if (book == null) throw new KeyNotFoundException("Book not found.");

        book.Name = name;
        book.Author = author;
        book.Publisher = publisher;
        book.ReleaseYear = releaseYear;
        book.Genres = genres;
    
        SaveData(data);
        return book;
    }

    public IAuthor UpdateAuthor(int id, string name, string surname, DateTime birthDate)
    {
        var data = LoadData();
        var author = data.Authors.FirstOrDefault(b => b.Id == id);
        if (author == null) throw new KeyNotFoundException("Author not found.");

        author.Name = name;
        author.Surname = surname;
        author.BirthDate = birthDate;
    
        SaveData(data);
        return author;
    }

    public IPublisher UpdatePublisher(int id, string name)
    {
        var data = LoadData();
        var publisher = data.Publishers.FirstOrDefault(b => b.Id == id);
        if (publisher == null) throw new KeyNotFoundException("Publisher not found.");

        publisher.Name = name;
    
        SaveData(data);
        return publisher;
    }

    public void DeleteBook(int id)
    {
        var data = LoadData();
        var book = data.Books.FirstOrDefault(b => b.Id == id);
        if (book == null) throw new KeyNotFoundException("Book not found.");

        data.Books.Remove(book);
        SaveData(data);
    }

    public void DeleteAuthor(int id)
    {
        var data = LoadData();
        var author = data.Authors.FirstOrDefault(b => b.Id == id);
        if (author == null) throw new KeyNotFoundException("Author not found.");

        data.Authors.Remove(author);
        SaveData(data);
    }

    public void DeletePublisher(int id)
    {
        var data = LoadData();
        var publisher = data.Publishers.FirstOrDefault(b => b.Id == id);
        if (publisher == null) throw new KeyNotFoundException("Publisher not found.");

        data.Publishers.Remove(publisher);
        SaveData(data);
    }

    private Data LoadData()
    {
        var json = File.ReadAllText(DataFile);
        if (string.IsNullOrEmpty(json))
        {
            return new Data();
        }
        
        return JsonConvert.DeserializeObject<Data>(json);
    }

    private void SaveData(Data data)
    {
        var json = JsonConvert.SerializeObject(data);
        File.WriteAllText(DataFile, json);
    }
}

public class Data
{
    public List<Book> Books { get; set; } = new List<Book>();
    public List<Author> Authors { get; set; } = new List<Author>();
    public List<Publisher> Publishers { get; set; } = new List<Publisher>();
}