using AutoMapper;
using BookStore.DBOperations;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.BookOperations.Queries.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }
        public List<BooksViewModel> Handle()
        {
            var bookList = _dbcontext.Books.Include(x=>x.Genre).OrderBy(x => x.Id).ToList<Book>;
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);//new List<BooksViewModel>();
            //foreach (var book in bookList)
            //{
            //    vm.Add(new BooksViewModel()
            //    {
            //        Title = book.Title,AutoMapper.AutoMapperMappingException: 'Error mapping type
            //        Genre = ((GenreEnum)book.GenreId).ToString(),
            //        PublishDate = book.PublishDate.ToString("dd/MM/yyyy"),
            //        PageCount = book.PageCount,
            //    });
            //}
            return vm;
        }

    }
    public class BooksViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}
