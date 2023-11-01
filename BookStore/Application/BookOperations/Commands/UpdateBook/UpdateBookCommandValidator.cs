using FluentValidation;

namespace BookStore.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
            RuleFor(command => command.Model.PublishDate).LessThan(DateTime.Now);
            RuleFor(command => command.Model.Title).Length(1, 20);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
        }
    }
}
