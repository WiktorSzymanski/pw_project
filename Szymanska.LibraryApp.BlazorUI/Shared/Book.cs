using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Szymanski.LibraryApp.Core;
using Szymanski.LibraryApp.Interfaces;

namespace Szymanska.LibraryApp.BlazorUI.Shared
{
    public class Book : IBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Author? Author { get; set; }
        [JsonIgnore]
        IAuthor? IBook.Author
        {
            get => (IAuthor?)Author;
            set => Author = (Author?)value;
        }
        
        public Publisher? Publisher { get; set; }

        [JsonIgnore]
        IPublisher? IBook.Publisher
        {
            get => (IPublisher?)Publisher;
            set => Publisher = (Publisher?)value;
        }

        public int ReleaseYear { get; set; }
        public Genre Genre { get; set; }
    }
}
