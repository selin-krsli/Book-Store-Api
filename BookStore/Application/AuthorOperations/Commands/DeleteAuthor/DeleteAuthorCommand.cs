using BookStore.DBOperations;

namespace BookStore.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int AuthorId { get; set; }   
        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _dbContext = context;
        }
        public void Handle(int id)
        {
            var author = _dbContext.Authors.SingleOrDefault(s => s.Id == id);
            if (author is null)
                throw new InvalidOperationException("Belirtilen id'de silinecek yazar bulunamadı.");
            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
        }
    }
}
