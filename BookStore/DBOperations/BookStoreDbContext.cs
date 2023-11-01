using BookStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DBOperations
{
    public class BookStoreDbContext: DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options):base(options) 
        {
            
        }
        //Db'de yazılacak table'lar çoğul yazılır. Buradaki Books nesnesiyle Book entitysinin her şeyine erişebiliyorum.
        //Book aslında Db'deki Books table'nın koddaki replikası.Koddan ulaşabileceğim karşılığı
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
