﻿using FluentValidation;

namespace BookStore.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator:AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.Birthday).LessThan(DateTime.Now);
        }
    }
}
