using AutoMapper;
using BookStore.Application.AuthorOperations.Commands.CreateAuthor;
using BookStore.Application.AuthorOperations.Commands.DeleteAuthor;
using BookStore.Application.AuthorOperations.Commands.UpdateAuthor;
using BookStore.Application.AuthorOperations.Queries.GetAuthorDetail;
using BookStore.Application.AuthorOperations.Queries.GetAuthors;
using BookStore.Application.BookOperations.Queries.GetBookDetail;
using BookStore.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController:ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetAuthorDetails(int id)
        {
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
            query.AuthorId = id;

            GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var result = query.Handle();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateAuthor([FromBody] CreateAuthorViewModel newModel)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context);
            command.Model = newModel;
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId = id;
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();    
            validator.ValidateAndThrow(command);

            command.Handle(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdatedAuthorModel updatedModel)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.AuthorId = id;
            command.Model = updatedModel;
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok(command);
        }
    }
}
