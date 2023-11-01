using EF_final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_final.Repository.Interfaces
{
    internal interface IBookRepository
    {
        void AddBook(Book book);
        void DeleteBook(Book book);
        Book GetBookById(int id);
        List<Book> GetBooks();
        void UpdateBook(int id, int year);
        void IssueToUser(Book book, User user);
        List<Book> GetBooksByGenreNameBetweenYears(string name, int yearAfter, int yearBefore);
        List<Book> GetBooksByAuthorName(string authorName);
        List<Book> BetBooksByGenreName(string genreName);
        bool IsEsixtByAuthorNameAndBookName(string authorName, string bookName);
        bool IsBookOnUser (string bookName);
        Book GetLastReleasedBook ();
        List<Book> GetAllBooksAbc();
        List<Book> GetAllBooksByReleaseDateDesc();
        void Save();
    }
}
