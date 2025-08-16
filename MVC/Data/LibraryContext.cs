using LibraryBookManagement.Models;
using Microsoft.EntityFrameworkCore;


namespace LibraryBookManagement.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }


        

        

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "Ahmed Khaled Tawfik", Bio = "Egyptian novelist", DateOfBirth = new DateTime(1962, 6, 10) },
                new Author { Id = 2, Name = "Naguib Mahfouz", Bio = "Nobel Prize winner", DateOfBirth = new DateTime(1911, 12, 11) }
            );

           
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Utopia",
                    Category = Category.Novel,
                    PublicationDate = new DateTime(2008, 1, 1),
                    IsAvailable = true,
                    AuthorId = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "Cairo Trilogy",
                    Category = Category.History,
                    PublicationDate = new DateTime(1956, 1, 1),
                    IsAvailable = true,
                    AuthorId = 2
                }
            );
        }


    }
}
