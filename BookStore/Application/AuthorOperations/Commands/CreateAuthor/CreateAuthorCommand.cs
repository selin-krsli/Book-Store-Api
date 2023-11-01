using AutoMapper;
using BookStore.DBOperations;
using BookStore.Entities;

namespace BookStore.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public CreateAuthorViewModel Model { get; set; }    
        public CreateAuthorCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var author = _dbContext.Authors.Where(s=>s.Name==Model.Name).FirstOrDefault();
            if(author is not null)
            {
                throw new InvalidOperationException("Belirtilen yazar ismi zaten mevcut.");
            }
            author = new Author(); //boş bir Author instance'ı yarattım.
            author.Name = Model.Name;
            author.Surname = Model.Surname;
            author.Birthday = Model.Birthday;   

            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges(); 
        }
    }
    public class CreateAuthorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
    }
}
