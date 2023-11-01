using AutoMapper;
using BookStore.Application.AuthorOperations.Commands.UpdateAuthor;
using BookStore.Application.AuthorOperations.Queries.GetAuthorDetail;
using BookStore.Application.AuthorOperations.Queries.GetAuthors;
using BookStore.Application.BookOperations.Commands.CreateBooks;
using BookStore.Application.BookOperations.Commands.UpdateBook;
using BookStore.Application.BookOperations.Queries.GetBookDetail;
using BookStore.Application.BookOperations.Queries.GetBooks;
using BookStore.Application.GenreOperations.Queries.GetGenreDetail;
using BookStore.Application.GenreOperations.Queries.GetGenres;
using BookStore.Entities;

namespace BookStore.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Book
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>()
                    .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book,UpdatedBookDetail > ();
            CreateMap<Book, BooksViewModel> ()
                    .ForMember(dest => dest.Genre, opt=> opt.MapFrom(src => src.Genre.Name));
            //Genre
            CreateMap<Genre, GenreViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            //Author
            CreateMap<Author, AuthorViewModel>().ForMember(dest=>dest.FullName, opt=>opt.MapFrom(src=> src.Name + " " + src.Surname));
            CreateMap<Author, AuthorDetailViewModel>().ForMember(dest=>dest.FullName, opt=>opt.MapFrom(src=>src.Name + " " + src.Surname));
            CreateMap<Author, UpdatedAuthorModel>();
        }
    }
}
