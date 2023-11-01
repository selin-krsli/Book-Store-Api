using BookStore.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.FirstOrDefault(x => x.Id == BookId);
            if (book == null)
            {
                throw new InvalidOperationException("Belirtilen id'de kitap bulunamadı!");
            }
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}
