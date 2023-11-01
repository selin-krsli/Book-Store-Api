using AutoMapper;
using BookStore.DBOperations;

namespace BookStore.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GetGenresQuery(BookStoreDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public List<GenreViewModel> Handle()
        {
            var genres = _dbcontext.Genres.Where(x => x.IsActive).OrderBy(x => x.Id);
            List<GenreViewModel> returnObj = _mapper.Map<List<GenreViewModel>>(genres);
            return returnObj;

        }
    }
        public class GenreViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool IsActive { get; set; } = true;
        }
}
