using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szymanski.LibraryApp.Core;
using Szymanski.LibraryApp.Interfaces;

namespace Szymanska.LibraryApp.BlazorUI.Shared
{
    public class Book : IBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IAuthor? Author { get; set; }
        public IPublisher? Publisher { get; set; }
        public int ReleaseYear { get; set; }
        public Genre Genre { get; set; }
    }
}
