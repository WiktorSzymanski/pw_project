﻿using Szymanski.LibraryApp.Interfaces;
using Szymanski.LibraryApp.Core;
using System.Reflection;

namespace Szymanski.LibraryApp.BL;

public class BL
{
    private IDAO _dao;

    // Make it singleton
    public BL(string libraryName)
    {
        Assembly assembly = Assembly.UnsafeLoadFrom(libraryName);

        Type? typeToCreate = null;

        foreach (Type t in assembly.GetTypes())
        {
            if (t.IsAssignableTo(typeof(IDAO)))
            {
                typeToCreate = t;
                break;
            }
        }

        _dao = (IDAO)Activator.CreateInstance(typeToCreate, null);
    }

    public IEnumerable<IBook> GetBooks() => _dao.GetAllBooks();
    public IEnumerable<IAuthor> GetAuthors() => _dao.GetAllAuthors();
    public IEnumerable<IPublisher> GetPublishers() => _dao.GetAllPublishers();

    public IBook
        CreateNewBook(int id, string name, IAuthor? author, IPublisher? publisher, int releaseYear, Genre genre) =>
        _dao.CreateNewBook(id, name, author, publisher, releaseYear, genre);
    
    public IAuthor CreateNewAuthor(int id, string name, string surname, DateTime birthDate) =>
        _dao.CreateNewAuthor(id, name, surname, birthDate);
    
    public IPublisher CreateNewPublisher(int id, string name) =>
        _dao.CreateNewPublisher(id, name);
    
    public IBook
        UpdateBook(int id, string name, IAuthor? author, IPublisher? publisher, int releaseYear, Genre genre) =>
        _dao.UpdateBook(id, name, author, publisher, releaseYear, genre);
    
    public IAuthor UpdateAuthor(int id, string name, string surname, DateTime birthDate) =>
        _dao.UpdateAuthor(id, name, surname, birthDate);
    
    public IPublisher UpdatePublisher(int id, string name) =>
        _dao.UpdatePublisher(id, name);

    public void DeleteBook(int id) => _dao.DeleteBook(id);
    
    public void DeleteAuthor(int id) => _dao.DeleteAuthor(id);
    
    public void DeletePublisher(int id) => _dao.DeletePublisher(id);
}
