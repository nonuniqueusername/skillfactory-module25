using EF_final.Models;
using EF_final.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_final.Repository
{

    public class BookRepository : IBookRepository
    {
        private AppContext db;

        public BookRepository(AppContext db)
        {
            this.db = db;
        }

        public Book GetBookById(int id)
        {
            return db.Books.FirstOrDefault(b => b.Id == id);
        }

        public List<Book> GetBooks()
        {
            return db.Books.ToList();
        }

        public void AddBook(Book book)
        {
            db.Books.Add(book);
        }

        public void DeleteBook(Book book)
        {
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }

        public void UpdateBook(int id, int year)
        {
            var book = db.Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                book.ReleaseYear = year;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void IssueToUser(Book book, User user)
        {
            book.User = user;
        }

        public List<Book> GetBooksByGenreNameBetweenYears(string name, int yearAfter, int yearBefore)
        {
            return db.Books.Where(b => b.Genre.Name == name && b.ReleaseYear >= yearAfter && b.ReleaseYear <= yearBefore).ToList();
        }

        public List<Book> GetBooksByAuthorName(string authorName)
        {
            return db.Books.Where(b => b.Author.Name == authorName).ToList();
        }

        public List<Book> BetBooksByGenreName(string genreName)
        {
            return db.Books.Where(b => b.Genre.Name ==  genreName).ToList();
        }

        public bool IsEsixtByAuthorNameAndBookName(string authorName, string bookName)
        {
            return db.Books.Where(b => b.Author.Name == authorName && b.Title == bookName).Any();
        }

        public bool IsBookOnUser(string bookName)
        {
            return db.Books.Where(b => b.Title == bookName)
                           .FirstOrDefault().User != null;
        }

        public Book GetLastReleasedBook()
        {
            return db.Books.OrderByDescending(b => b.ReleaseYear)
                           .FirstOrDefault();
        }

        public List<Book> GetAllBooksAbc()
        {
            return db.Books.OrderBy(b => b.Title).ToList();
        }

        public List<Book> GetAllBooksByReleaseDateDesc()
        {
            return db.Books.OrderByDescending(b => b.ReleaseYear).ToList();
        }
    }
}