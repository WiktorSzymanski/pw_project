using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Szymanski.LibraryApp.Core;
using Szymanski.LibraryApp.DAOSQL.BO;

namespace Szymanski.LibraryApp.DAOSQL;

public class AppDbContext : DbContext
{
    protected readonly IConfiguration Configuration;
    
    public AppDbContext() { }

    public AppDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql("Host=localhost; Database=library_db; Username=postgres; Password=passwd");
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasOne(b => b.Author);
        modelBuilder.Entity<Book>().HasOne(b => b.Publisher);
        
        modelBuilder.Entity<Book>()
            .Property(b => b.Genres)
            .HasConversion(
                genres => string.Join(",", genres),
                str => str.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(genre => (Genre)Enum.Parse(typeof(Genre), genre)).ToList());

    }
    
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
}