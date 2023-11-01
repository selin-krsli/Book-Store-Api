using AutoMapper;
using BookStore.DBOperations;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.BookOperations.Commands.CreateBooks
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book != null)
            {
                throw new InvalidOperationException("Kitap zaten mevcut");
            }

            book = _mapper.Map<Book>(Model); //Modelle gelen veriyi Book objesine covert et. //new Book()
            _dbContext.Books.Add(book);
            //herbir değişiklik yaptıktan sonra contexi save etmem gerekiyor.
            _dbContext.SaveChanges();
        }
    }
    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
