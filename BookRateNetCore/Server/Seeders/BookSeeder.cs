using BookRateNetCore.Server.Persistence;
using BookRateNetCore.Shared.Models;
using BookRateNetCore.Shared.Services;

namespace BookRateNetCore.Server.Seeders
{
    public class BookSeeder : IBookSeeder
    {
        private readonly BookDbContext _dbContext;

        public BookSeeder(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task SeedBook()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Books.Any())
                {
                    var books = GetBooks();

                    _dbContext.Books.AddRange(books);

                    _dbContext.SaveChanges();
                }
            }
        }

        public async Task SeedCategory()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Categories.Any())
                {
                    var categories = GetCategories();

                    _dbContext.Categories.AddRange(categories);

                    _dbContext.SaveChanges();
                }
            }
        }

        
        private List<Category> GetCategories()
        {
            var categories = new List<Category>()
            {
                new Category("Science"),
                new Category("Programming"),
                new Category("Design Patterns"),
                new Category("Mathematics"),
                new Category("Artificial Intelligence"),
                new Category("Cybersecurity"),
                new Category("Data Science"),
                new Category("Software Engineering")
            };

            return categories;
        }


        private IEnumerable<Book> GetBooks()
        {
            var books = new List<Book>()
            {
               new Book()
                {
                    Author = "J.K. Rowling",
                    Title = "Harry Potter and the Philosopher's Stone",
                    Description = "Harry Potter has never even heard of Hogwarts when the letters start dropping on the doormat at number four, Privet Drive. Addressed in green ink on yellowish parchment with a purple seal, they are swiftly confiscated by his grisly aunt and uncle. Then, on Harry's eleventh birthday, a great beetle-eyed...",
                    Rate = 4,
                    Publisher = "Bloomsbury",
                    PublishDate = new DateTime(1997, 6, 26),
                    Pages = 223
                },
                new Book()
                {
                    Author = "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides",
                    Title = "Design Patterns: Elements of Reusable Object-Oriented Software",
                    Description = "Design Patterns is a foundational book for software developers, introducing the concept of design patterns in object-oriented design. It provides solutions to common problems in software design and has been influential in the development of software engineering.",
                    Rate = 4,
                    Publisher = "Addison-Wesley Professional",
                    PublishDate = new DateTime(1994, 10, 31),
                    Pages = 395
                },
                new Book()
                {
                    Author = "Andrew Hunt, David Thomas",
                    Title = "The Pragmatic Programmer: Your Journey to Mastery",
                    Description = "The Pragmatic Programmer is a highly regarded book that covers a wide range of topics in software development, from coding and testing to career development. It's packed with practical advice and best practices for becoming a better programmer.",
                    Rate = 5,
                    Publisher = "Addison-Wesley Professional",
                    PublishDate = new DateTime(1999, 10, 20),
                    Pages = 352
                },
                new Book()
                {
                    Author = "Sandi Metz",
                    Title = "Practical Object-Oriented Design in Ruby",
                    Description = "This book is an excellent guide to object-oriented design principles, with a focus on practical examples using Ruby. Sandi Metz provides clear explanations and actionable advice that can be applied in any object-oriented programming language.",
                    Rate = 4,
                    Publisher = "Addison-Wesley Professional",
                    PublishDate = new DateTime(2012, 9, 12),
                    Pages = 272
                }


            };

            return books;
        }
    }
}





