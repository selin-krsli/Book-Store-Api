using AutoMapper;
using BookStore.DBOperations;
using FluentValidation;

namespace BookStore.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public UpdatedAuthorModel Model { get; set; }
        public int AuthorId { get; set; }
        public UpdateAuthorCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(s => s.Id == AuthorId);
            if (author is null)
                throw new InvalidOperationException("Belirtilen id'de herhangi kayıt bulunmamaktadır.");
            author.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? author.Name : Model.Name;
            author.Surname = string.IsNullOrEmpty(Model.Surname.Trim()) ? author.Surname : Model.Surname;
            author.Birthday = Model.Birthday;
            _dbContext.SaveChanges();
        }
    }
    public class UpdatedAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
    }
}
