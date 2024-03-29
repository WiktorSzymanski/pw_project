﻿using Szymanski.LibraryApp.Core;
using Szymanski.LibraryApp.DAOMock2.BO;
using Szymanski.LibraryApp.Interfaces;

namespace Szymanski.LibraryApp.DAOMock2;

public class DAOMock: IDAO
{
    private List<IBook> _books;
    private List<IAuthor> _authors;
    private List<IPublisher> _publishers;

    public DAOMock()
    {
        _authors = new List<IAuthor>()
        {
            new Author() {Id = 1, Name = "DAMN", Surname = "DANIEL", BirthDate = new DateTime(2097,03,03)},
            new Author() {Id = 2, Name = "Daniel", Surname = "DAMN", BirthDate = new DateTime(2037,04,05)},
            new Author() {Id = 3, Name = "Adam", Surname = "DAMN", BirthDate = new DateTime(2077,06,01)},
        };

        _publishers = new List<IPublisher>()
        {
            new Publisher() { Id = 1, Name = "PublisherDaniel" },
            new Publisher() { Id = 2, Name = "DAMNPublisher" },
        };

        _books = new List<IBook>()
        {
            new Book()
            {
                Id = 1, Name = "Damn Book", Author = _authors[0], Publisher = _publishers[0], ReleaseYear = 2001, Genre = Genre.Fantasy
            },
            new Book()
            {
                Id = 2, Name = "Book About Daniel", Author = _authors[1], Publisher = _publishers[0], ReleaseYear = 2000, Genre = Genre.Fantasy
            },
            new Book()
            {
                Id = 3, Name = "KaBook", Author = _authors[2], Publisher = _publishers[1], ReleaseYear = 1990, Genre = Genre.Romance
            },
        };
    }
    
    public IEnumerable<IBook> GetAllBooks()
    {
        return _books;
    }

    public IEnumerable<IAuthor> GetAllAuthors()
    {
        return _authors;
    }

    public IEnumerable<IPublisher> GetAllPublishers()
    {
        return _publishers;
    }

    public IBook CreateNewBook(int id, string name, IAuthor author, IPublisher publisher, int releaseYear, Genre genre)
    {
        var biggestId = _books.MaxBy(obj => obj.Id)?.Id;
        Book book = new Book()
        {
            Id = biggestId.GetValueOrDefault(0) + 1, Name = name, Author = author, Publisher = publisher, ReleaseYear = releaseYear, Genre = genre
        };
        _books.Add(book);

        return book;
    }

    public IAuthor CreateNewAuthor(int id, string name, string surname, DateTime birthDate)
    {
        var biggestId = _authors.MaxBy(obj => obj.Id)?.Id;
        Author author = new Author()
        {
            Id = biggestId.GetValueOrDefault(0) + 1, Name = name, Surname = surname, BirthDate = birthDate
        };
            
        _authors.Add(author);

        return author;
    }

    public IPublisher CreateNewPublisher(int id, string name)
    {
        var biggestId = _publishers.MaxBy(obj => obj.Id)?.Id;
        Publisher publisher = new Publisher()
        {
            Id = biggestId.GetValueOrDefault(0) + 1, Name = name
        };
            
        _publishers.Add(publisher);

        return publisher;
    }
    
    public IBook UpdateBook(int id, string name, IAuthor author, IPublisher publisher, int releaseYear, Genre genre)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book != null)
        {
            book.Name = name;
            book.Author = author;
            book.Publisher = publisher;
            book.ReleaseYear = releaseYear;
            book.Genre = genre;
        }
        else
        {
            throw new Exception("Book not found");
        }

        return book;         
    }

    public IAuthor UpdateAuthor(int id, string name, string surname, DateTime birthDate)
    {
        var author = _authors.FirstOrDefault(a => a.Id == id);
        if (author != null)
        {
            author.Name = name;
            author.Surname = surname;
            author.BirthDate = birthDate;
        }
        else
        {
            throw new Exception("Author not found");
        }

        return author;
    }

    public IPublisher UpdatePublisher(int id, string name)
    {
        var publisher = _publishers.FirstOrDefault(a => a.Id == id);
        if (publisher != null)
        {
            publisher.Name = name;
        }
        else
        {
            throw new Exception("Author not found");
        }

        return publisher;
    }

    public void DeleteBook(int id)
    {
        var value = _books.FirstOrDefault(a => a.Id == id);

        if (value != null)
            _books.Remove(value);
    }

    public void DeleteAuthor(int id)
    {
        var value = _authors.FirstOrDefault(a => a.Id == id);

        if (value != null)
            _authors.Remove(value);
    }

    public void DeletePublisher(int id)
    {
        var value = _publishers.FirstOrDefault(a => a.Id == id);

        if (value != null)
            _publishers.Remove(value);
    }
}