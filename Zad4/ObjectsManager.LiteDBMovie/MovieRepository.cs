using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using ClassLibrary2;
using ObjectsManager.Interfaces;
using ObjectsManager.LiteDBMovie.Model;

namespace ObjectsManager.LiteDBMovie
{
    public class MovieRepository : IMovieRepository
    {
        private readonly string _moviesConnection = DatabaseConnections.MovieConnection;
        public List<Movie> GetAll()
        {
            using (var db = new LiteDatabase(this._moviesConnection))
            {
                var repository = db.GetCollection<MovieDB>("movies");
                var results = repository.FindAll();

                return results.Select(x => Map(x)).ToList();
            }
        }

        public int Add(Movie movie)
        {
            using (var db = new LiteDatabase(this._moviesConnection))
            {
                var dbObject = InverseMap(movie);

                var repository = db.GetCollection<MovieDB>("movies");
                if (repository.FindById(movie.Id) != null)
                    repository.Update(dbObject);
                else
                    repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public Movie Get(int id)
        {
            using (var db = new LiteDatabase(this._moviesConnection))
            {
                var repository = db.GetCollection<MovieDB>("movies");
                var results = repository.FindById(id);

                return Map(results);
            }
        }

        public Movie Update(Movie movie)
        {
            using (var db = new LiteDatabase(this._moviesConnection))
            {
                var dbObject = InverseMap(movie);

                var repository = db.GetCollection<MovieDB>("movies");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._moviesConnection))
            {
                var repository = db.GetCollection<MovieDB>("movies");

                return repository.Delete(id);
            }
        }

        internal Movie Map(MovieDB dbMovie)
        {
            if (dbMovie == null)
                return null;
            return new Movie() { Id = dbMovie.Id, Title = dbMovie.Title, ReleaseYear = dbMovie.ReleaseYear };
        }

        internal MovieDB InverseMap(Movie movie)
        {
            if (movie == null)
                return null;
            return new MovieDB() { Id = movie.Id, Title = movie.Title, ReleaseYear = movie.ReleaseYear };
        }
    }
}
