﻿using FluentValidation;

namespace BookStore.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator:AbstractValidator<UpdateGenreCommand>  
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(command=>command.Model.Name.Trim()).MinimumLength(4).When(x=>x.Model.Name.Trim() != string.Empty);
        }
    }
}