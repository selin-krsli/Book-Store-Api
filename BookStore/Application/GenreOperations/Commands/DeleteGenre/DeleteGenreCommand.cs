using BookStore.DBOperations;

namespace BookStore.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int GenreId { get; set; }
        public DeleteGenreCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var deletedObj = _dbContext.Genres.FirstOrDefault(x => x.Id == GenreId);
            if(deletedObj is  null) 
            {
                throw new InvalidOperationException("Belirtilen id'de kitap türü bulunamamaktadır.");
            }
            _dbContext.Genres.Remove(deletedObj);
            _dbContext.SaveChanges();
        }
    }
}
