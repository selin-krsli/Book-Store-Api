using AutoMapper;
using BookStore.DBOperations;
using BookStore.Entities;

namespace BookStore.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAuthorsQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<AuthorViewModel> Handle()
        {
            var authorList = _dbContext.Authors.OrderBy(x=>x.Id).ToList(); 
            List<AuthorViewModel> authorsViewModel = _mapper.Map<List<AuthorViewModel>>(authorList);
            return authorsViewModel;
        }
    }
    public class AuthorViewModel
    {
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
