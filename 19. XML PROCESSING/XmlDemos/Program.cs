using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XmlDemos
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var books = new List<Book>
            //{
            //    new Book("The Little Prince", "Exupery", 1943),
            //    new Book("The Master and Margarita", "Bulgakov", 1967),
            //};
            //XmlSerializer xmlSerializer = new XmlSerializer(books.GetType());
            //using var writer = new StreamWriter("books_new.xml");
            //xmlSerializer.Serialize(writer, books);

            XmlSerializer booksSerializer = new XmlSerializer(typeof(List<Book>), new XmlRootAttribute("books"));
            using var reader = new StreamReader("Data/book_modified3.xml");
            var books = (List<Book>)booksSerializer.Deserialize(reader);
            var books2 = new List<Book2>();

            foreach (var item in books)
            {
                Console.WriteLine(item);
                var book = new Book2 { Author = item.Author, Name = item.Name, Page = item.Page };
                books2.Add(book);
            }

            XmlSerializer booksSerializer2 = new XmlSerializer(typeof(List<Book2>), new XmlRootAttribute("books"));
            using var writer = new StreamWriter("Data/book_modified4.xml");
            booksSerializer2.Serialize(writer, books2);

            //var settings = new XDocument();
            //settings.Add(new XElement("books",
            //    new XElement("book", 
            //        new XElement("title", "The Little Prince"), 
            //        new XElement("author", "Exupery")),
            //    new XElement("book",
            //        new XElement("title", "The Master and Margarita"),
            //        new XElement("author", "Bulgakov"))));

            //settings.Save("book.xml",SaveOptions.DisableFormatting);

            //var settings = new XDocument();
            //settings.Add(new XElement("settings",
            //    new XAttribute("lang", "bg-bg"),
            //    new XElement("XPosition", 
            //        new XElement("X1",123),
            //        new XElement("X2","321")), 
            //    new XElement("YPosition", 321)));

            //settings.Save("settings.xml");


            //document.Declaration.Version = "3.0";
            //document.Root.Add(new XElement("car", new XElement("make", "Audi")));
            //document.Save("Data/Library_updated.xml");

            //var root = document.Root;
            //document.Root.SetAttributeValue("count", "500");

            //var books = root.Elements().Where(x => x.Element("BookPage").Value == "300").Select(x => new Book
            //{
            //    Name = x.Element("BookName").Value,
            //    Author = x.Element("BookAuthor").Value,
            //    Page = int.Parse(x.Element("BookPage").Value)
            //}).Where(x => x.Page > 300);

            //Console.WriteLine(root.Attribute("address").Value);
            //Console.WriteLine(root.Attribute("count").Value);


            //var books = root.Elements();
            //root.RemoveAll();

            //foreach (var item in books)
            //{
            //    var bookObject = new Book
            //    {
            //        Name = item.Element("BookName").Value,
            //        Author = item.Element("BookAuthor").Value,
            //        Page = int.Parse(item.Element("BookPage").Value)
            //    }
            //};
            //Console.WriteLine($"{item.Element("BookName").Value}: {item.Element("BookAuthor").Value}: {item.Element("BookPage").Value}");
            //Console.WriteLine($"{bookObject.Author}: {bookObject.Name}: {bookObject.Page}");

            //item.Element("BookPage").Value = "Ghjjjk";

            //item.RemoveAll();


            //document.Save("Data/book_modified.xml");
        }
        //public class Book
        //{
        //    public Book()
        //    {
        //    }
        //    public Book(string title, string author, int year)
        //    {
        //        Title = title;
        //        Author = author;
        //        Year = year;
        //    }
        //    public string Title { get; set; }
        //    public string Author { get; set; }
        //    public int Year { get; set; }
        //}

        //[XmlType("books")]
        //public class XmlBooks
        //{
        //    public List<Book> books { get; set; }
        //}

        [XmlType("book")]
        public class Book
        {
            [XmlElement("name")]
            public string Name { get; set; }

            [XmlElement("author")]
            public string Author { get; set; }

            [XmlElement("page")]
            public string Page { get; set; }

            public override string ToString()
            {
                return $"{Name}: {Author}: {Page}";
            }
        }

        [XmlType("book")]
        public class Book2
        {
            [XmlAttribute("name")]
            public string Name { get; set; }

            [XmlElement("author")]
            public string Author { get; set; }

            [XmlElement("page")]
            public string Page { get; set; }

            public override string ToString()
            {
                return $"{Name}: {Author}: {Page}";
            }
        }

    }
}
