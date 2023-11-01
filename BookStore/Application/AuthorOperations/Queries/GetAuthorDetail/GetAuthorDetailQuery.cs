using AutoMapper;
using BookStore.DBOperations;

namespace BookStore.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int AuthorId {  get; set; }  
        public GetAuthorDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public AuthorDetailViewModel Handle()
        {
            var author =_dbContext.Authors.SingleOrDefault(s=>s.Id == AuthorId);
            if (author is null)
                throw new InvalidOperationException("Belirtilen id'de yazar bulunamamıştır.");
            AuthorDetailViewModel authorDetail = _mapper.Map<AuthorDetailViewModel>(author);
            return authorDetail;
        }
    }
    public class AuthorDetailViewModel
    {
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
