using AutoMapper;
using BookStore.Application.BookOperations.Commands.CreateBooks;
using BookStore.Application.BookOperations.Commands.DeleteBook;
using BookStore.Application.BookOperations.Commands.UpdateBook;
using BookStore.Application.BookOperations.Queries.GetBookDetail;
using BookStore.Application.BookOperations.Queries.GetBooks;
using BookStore.DBOperations;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController] //Http Response dönecek anlamına geliyor.
    [Route("[controller]s")]
    public class BookController:ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            //private olan içerde kullanacağım context referansına inject edilen instance'ı atadım. 
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result= new BookDetailViewModel();
            GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);

                query.BookId = id;
                GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
                validator.ValidateAndThrow(query);
                result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
                command.Model = newBook;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                //ValidationResult result = validator.Validate(command);  
                validator.ValidateAndThrow(command);
                command.Handle();
                //if(!result.IsValid)
                //{
                //    foreach (var item in result.Errors)
                //    {
                //        Console.WriteLine("Özellik:" + item.PropertyName + "Error Message: " + item.ErrorMessage);
                //    }
                //}
                //else
                //{
                //    command.Handle();
                //}
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdatedBookDetail updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context, _mapper);
                command.Id = id;
                command.Model = updatedBook;
                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand deleteBookCommand = new DeleteBookCommand(_context);


                deleteBookCommand.BookId = id;
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(deleteBookCommand);
                deleteBookCommand.Handle();

            return Ok();
        }
    }
}
