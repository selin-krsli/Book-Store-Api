using BookStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize (IServiceProvider serviceProvider)
        {
            using(var context = new BookStoreDbContext (serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any())
                {
                    return;
                }
                context.Authors.AddRange(
                new Author
                {
                    Name = "Irvin D.",
                    Surname = "Yalom",
                    Birthday = new DateTime(1968, 4, 12)
                },
                new Author
                {
                    Name = "Haruki",
                    Surname = "Murakami",
                    Birthday = new DateTime(1984, 8, 04)

                },
                new Author
                {
                    Name = "Jose",
                    Surname = "Saramago",
                    Birthday = new DateTime(1934,8,11)
                });

            context.Genres.AddRange(
            new Genre
            {
                Name = "Psychological"
            },
            new Genre
            {
                Name = "Science Fiction"
            },
            new Genre
            {
                Name = "Romance"
            });

            context.Books.AddRange(
            new Book
            {
                Title = "When Nietzsche Wept",
                GenreId = 1, //Psychological
                PageCount = 1200,
                PublishDate = new DateTime(2001, 06, 12),
            },
            new Book
            {
                Title = "1Q84",
                GenreId = 2, //Science Fiction
                PageCount = 2250,
                PublishDate = new DateTime(2010, 05, 23),
            },
            new Book
            {
                Title = "BLINDNESS",
                GenreId = 2, //Psychological
                PageCount = 540,
                PublishDate = new DateTime(2001, 12, 21),
            });
                context.SaveChanges();
           }

        }
    }
}
