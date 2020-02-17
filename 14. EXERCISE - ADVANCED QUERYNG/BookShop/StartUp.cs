namespace BookShop
{
    using BookShop.Data.ViewModels;
    using BookShop.Models;
    using Data;
    using Initializer;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System.Diagnostics;
    using AutoMapper.EquivalencyExpression;
    using AutoMapper.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            
            using (var db = new BookShopContext())
            {
                Mapper.Initialize(x =>
                {
                    x.AddCollectionMappers();
                    x.UseEntityFrameworkCoreModel<BookShopContext>();
                    //x.SetGeneratePropertyMaps<GenerateEntityFrameworkCorePrimaryKeyPropertyMaps<BookShopContext>>();
                //x.CreateMap<Book, BookDTO>().ForMember(y => y.Author, z => z.MapFrom(a => $"{a.Author.FirstName} {a.Author.LastName}"));
                x.CreateMap<Book, BookDTO>();
                    //.ForMember(y => y.Name, z => z.MapFrom(a => a.Title))
                    //.ReverseMap();
                    x.CreateMap<BookDTO, Book>()
                    .EqualityComparison((y, z) => y.BookId == z.BookId);
                });

                var config = new MapperConfiguration(x =>
                {
                    x.AddCollectionMappers();
                    x.UseEntityFrameworkCoreModel<BookShopContext>();
                    x.CreateMap<Book, BookDTO>();
                    x.CreateMap<BookDTO, Book>().EqualityComparison((y, z) => y.BookId == z.BookId);
                    x.CreateMap<Author, AuthorDTO>();
                    x.CreateMap<AuthorDTO, Author>().EqualityComparison((y,z)=>y.AuthorId==z.AuthorId);
                });

                var mapper = config.CreateMapper();

                //var books = db
                //    .Books
                //    .Select(x => new BookDTO()
                //    {
                //        Title = x.Title,
                //        Price = x.Price,
                //        Author = $"{x.Author.FirstName} {x.Author.LastName}"
                //    })
                //    .ToList();

                //var book = db.Books
                //    .Include(x => x.Author)
                //    .First();

                //var bookDto = Mapper.Map<BookDTO>(book);

                //var bookDto = new BookDTO()
                //{
                //    BookId = 1,
                //    Title = "Title",
                //    Price = 10m,
                //    //AuthorFirstName = "Author",
                //    //AuthorLastName = "Author2"
                //};

                //var book = Mapper.Map<Book>(bookDto);

                //var books = db
                //    .Books
                //    .Where(x => x.EditionType.ToString() == "Gold")
                //    //.Select(x => new BookDTO{ Title = x.Title, Price = x.Price })
                //    .ProjectTo<BookDTO>()
                //    .ToList();

                //var books = new List<Book>()
                //{
                //    new Book()
                //    {
                //        BookId=1,
                //        Title="Title1",
                //        Price=30
                //    },
                //    new Book()
                //    {
                //        BookId=3,
                //        Title="Title3",
                //        Price=10
                //    }
                //};

                //var bookDtos = new List<BookDTO>()
                //{
                //    new BookDTO()
                //    {
                //        BookId=1,
                //        Title="Title1",
                //        Price=15
                //    },
                //    new BookDTO()
                //    {
                //        BookId=2,
                //        Title="Title2",
                //        Price=15
                //    }
                //};

                //Mapper.Map(bookDtos,books);

                //var book = db
                //    .Books
                //    .First(x => x.BookId == 1);

                //var bookDto = new BookDTO()
                //{
                //    Title = "Random title generated ef",
                //    Price = 15m
                //};

                var author = db.Authors.Find(2);
                Console.WriteLine(JsonConvert.SerializeObject(author, Formatting.Indented));

                var authorDto = new AuthorDTO()
                {
                    AuthorId = 2,
                    FirstName = "Penko",
                    LastName = "Penev"
                };

                db.Authors.Persist(mapper).InsertOrUpdate(authorDto);

                var changedAuthor = db.Authors.Find(2);
                Console.WriteLine(JsonConvert.SerializeObject(changedAuthor, Formatting.Indented));

                //db.Books.Persist(mapper).InsertOrUpdate<BookDTO>(bookDto);
                //db.SaveChanges();

                //var changedBook = db.Books.Find(1);

                //Console.WriteLine(JsonConvert.SerializeObject(book,Formatting.Indented));
                //Console.WriteLine(JsonConvert.SerializeObject(bookDtos,Formatting.Indented));
                //Console.WriteLine("--------------------------------");

                Console.WriteLine(stopwatch.ElapsedMilliseconds);

                //DbInitializer.ResetDatabase(db);

                //var input = Console.ReadLine();

                //var result = GetMostRecentBooks(db);

                //Console.WriteLine(result);
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var sb = new StringBuilder();

            var books = context
                .Books
                .Where(x => x.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            foreach (var item in books)
            {
                sb.AppendLine(item);
            }

            return sb.ToString().Trim();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            // var books = new List<Book>();

            var categories = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToArray();

            //foreach (var item in categories)
            //{
            //    var bookToCategory = context
            //        .Books
            //        .Where(x => x.BookCategories.Select(y => y.Category.Name).Any(z => z.ToLower() == item))
            //        .ToList();
            //
            //    books.AddRange(bookToCategory);
            //}
            //
            //var orderedBooks = books
            //    .Select(x => x.Title)
            //    .OrderBy(x => x)
            //    .ToList();

            var orderedBooks = context
                .Books
                .Where(x => x.BookCategories.Any(y => categories.Contains(y.Category.Name.ToLower())))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            return string.Join(Environment.NewLine, orderedBooks);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var booksAndAuthors = context
                .Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(x => x.BookId)
                .Select(x => new
                {
                    x.Title,
                    Author = $"{x.Author.FirstName} {x.Author.LastName}"
                })
                .ToList();

            foreach (var item in booksAndAuthors)
            {
                sb.AppendLine($"{item.Title} ({item.Author})");
            }

            return sb.ToString().Trim();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var sb = new StringBuilder();

            var authors = context
                .Authors
                .Select(x => new
                {
                    Name = $"{x.FirstName} {x.LastName}",
                    BookCopies = x.Books.Sum(y => y.Copies)
                })
                .OrderByDescending(x => x.BookCopies)
                .ToList();

            foreach (var item in authors)
            {
                sb.AppendLine($"{item.Name} - {item.BookCopies}");
            }

            return sb.ToString().Trim();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var categoriesAndMostRecentBooks = context
                .Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    CategoryRecentBooks = x.CategoryBooks
                    .OrderByDescending(y => y.Book.ReleaseDate)
                    .Take(3)
                    .Select(y => new { BookTitle = y.Book.Title, BookRelease = y.Book.ReleaseDate.Value.Year })
                    .ToList()
                })
                .OrderBy(x => x.CategoryName)
                .ToList();

            foreach (var i in categoriesAndMostRecentBooks)
            {
                sb.AppendLine($"--{i.CategoryName}");

                foreach (var item in i.CategoryRecentBooks)
                {
                    sb.AppendLine($"{item.BookTitle} ({item.BookRelease})");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
