using AutoMapper;
using BookStore.DBOperations;
using BookStore.Entities;

namespace BookStore.Application.GenreOperations.Commands.CreateGenres
{
    public class CreateGenreCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public CreateGenreModel Model { get; set; }
        public CreateGenreCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.FirstOrDefault(x=>x.Name == Model.Name);
            if(genre is not null)
            {
                throw new InvalidOperationException("Belirtilen kitap türü zaten mevcut.");
            }
            //Mapleme yapmayıp, boş bir Genre instance'ı yarattım.
            genre = new Genre();
            genre.Name = Model.Name;
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
        }
    }
    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}
