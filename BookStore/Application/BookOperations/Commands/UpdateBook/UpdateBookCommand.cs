using AutoMapper;
using BookStore.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int Id { get; set; }
        public UpdatedBookDetail Model { get; set; }
        public readonly IMapper _mapper;
        public UpdateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _dbContext.Books.Where(x => x.Id == Id).FirstOrDefault();

            if (book is null)
                throw new InvalidOperationException("Belirtilen id'li kitap bulunamadı.");
            Model = _mapper.Map<UpdatedBookDetail>(book);

            //book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            //book.Title = Model.Title != default ? Model.Title : book.Title;
            //book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
            //book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
            _dbContext.SaveChanges();
        }
    }
    public class UpdatedBookDetail
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
