using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using ObjectsManager.Models;
using ObjectsManager.LiteDBAuthor.Model;


namespace ObjectsManager.LiteDBAuthor
{
    public class AuthorRepository
    {
        private readonly string _authorConnection = DatabaseConnection.AuthorConnection;

        public int Add(Author b)
        {
            using (var db = new LiteDatabase(this._authorConnection))
            {
                var dbObject = InverseMap(b);
                var repository = db.GetCollection<AuthorDB>("authors");
                repository.Insert(dbObject);
                return dbObject.Id;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._authorConnection))
            {
                var repository = db.GetCollection<AuthorDB>("authors");
                return repository.Delete(id);
            }
        }

        public Author Get(int id)
        {
            using (var db = new LiteDatabase(this._authorConnection))
            {
                var repository = db.GetCollection<AuthorDB>("authors");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public List<Author> GetAll()
        {
            using (var db = new LiteDatabase(this._authorConnection))
            {
                var repository = db.GetCollection<AuthorDB>("authors");
                var results = repository.FindAll();
                return results.Select(x => Map(x)).ToList();
            }
        }

        public Author Update(Author b)
        {
            using (var db = new LiteDatabase(this._authorConnection))
            {
                var dbObject = InverseMap(b);
                var repository = db.GetCollection<AuthorDB>("authors");

                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        private Author Map(AuthorDB b)
        {
            if (b == null) return null;
            return new Author() { Id = b.Id, AuthorName = b.AuthorName, AuthorSurname = b.AuthorSurname };
        }

        private AuthorDB InverseMap(Author b)
        {
            if (b == null) return null;
            return new AuthorDB() { Id = b.Id, AuthorName = b.AuthorName, AuthorSurname = b.AuthorSurname };
        }
    }
}
