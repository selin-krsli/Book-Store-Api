using AutoMapper;
using BookStore.Common;
using BookStore.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.BookOperations.Queries.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        private readonly IMapper _mapper;
        public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Include(x=>x.Genre).Where(x => x.Id == BookId).SingleOrDefault();
            if (book is null)
                throw new InvalidOperationException("Kitap Bulunamadı.");
            //book'u BookDetailViewModele maplemem lazım.
            BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);    //new BookDetailViewModel();
            return vm;
        }
    }
    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}
