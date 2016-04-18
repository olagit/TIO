using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using ObjectsManager.LiteDBBook.Model;
using ObjectsManager.Models;

namespace ObjectsManager.LiteDBBook
{
    public class BookRepository
    {
        private readonly string _bookConnection = DatabaseConnection.BookConnection;

        public int Add(Book b)
        {
            using (var db = new LiteDatabase(this._bookConnection))
            {
                var dbObject = InverseMap(b);
                var repository = db.GetCollection<BookDB>("books");
                repository.Insert(dbObject);
                return dbObject.Id;
            }
        }

        public bool Delete(int id)
        {
            using(var db = new LiteDatabase(this._bookConnection))
            {
                var repository = db.GetCollection<BookDB>("books");
                return repository.Delete(id);
            }
        }

        public Book Get(int id)
        {
            using (var db = new LiteDatabase(this._bookConnection))
            {
                var repository = db.GetCollection<BookDB>("books");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public List<Book> GetAll()
        {
            using (var db = new LiteDatabase(this._bookConnection))
            {
                var repository = db.GetCollection<BookDB>("books");
                var results = repository.FindAll();
                return results.Select(x => Map(x)).ToList();
            }
        }

        public Book Update(Book b)
        {
            using (var db = new LiteDatabase(this._bookConnection))
            {
                var dbObject = InverseMap(b);
                var repository = db.GetCollection<BookDB>("books");

                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        private Book Map(BookDB b)
        {
            if (b == null) return null;
            return new Book() { Id = b.Id, BookTitle = b.BookTitle, ISBN = b.ISBN };
        }

        private BookDB InverseMap(Book b)
        {
            if (b == null) return null;
            return new BookDB() { Id = b.Id, BookTitle = b.BookTitle, ISBN = b.ISBN };
        }
    }
}
