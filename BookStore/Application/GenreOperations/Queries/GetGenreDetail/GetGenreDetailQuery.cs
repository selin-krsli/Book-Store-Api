using AutoMapper;
using BookStore.DBOperations;

namespace BookStore.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int GenreId { get; set; }    
        public GetGenreDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId);
            if(genre is null)
            {
                throw new InvalidOperationException("Belirtilen id'de kitap türü bulunamadı.");
            }
            var gdViewModel = _mapper.Map<GenreDetailViewModel>(genre);
            return gdViewModel;

        }
    }
    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
