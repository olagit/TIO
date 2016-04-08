using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using ClassLibrary2;
using ObjectsManager.Interfaces;
using ObjectsManager.LiteDBReviewPerson.Models;

namespace ObjectsManager.LiteDBReviewPerson
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly string _reviewsConnection = DatabaseConnections.ReviewConnection;

        public List<Review> GetAll()
        {
            using (var db = new LiteDatabase(this._reviewsConnection))
            {
                var repository = db.GetCollection<ReviewDB>("reviews");
                var results = repository.FindAll();

                return results.Select(x => Map(x)).ToList();
            }
        }

        public int Add(Review review)
        {
            using (var db = new LiteDatabase(this._reviewsConnection))
            {
                var dbObject = InverseMap(review);
                var repository = db.GetCollection<ReviewDB>("reviews");
                repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public Review Get(int id)
        {
            using (var db = new LiteDatabase(this._reviewsConnection))
            {
                var repository = db.GetCollection<ReviewDB>("reviews");
                var result = repository.FindById(id);

                return Map(result);
            }
        }

        public Review Update(Review review)
        {
            using (var db = new LiteDatabase(this._reviewsConnection))
            {
                var dbObject = InverseMap(review);
                var repository = db.GetCollection<ReviewDB>("reviews");

                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._reviewsConnection))
            {
                var repository = db.GetCollection<ReviewDB>("reviews");

                return repository.Delete(id);
            }
        }

        private Review Map(ReviewDB dbreview)
        {
            if (dbreview == null)
                return null;

            var personRepo = new PersonRepository();
            //var persons = personRepo.GetAll(dbreview.AuthorId).Select(x => personRepo.Map(x)).tol
            Person person = personRepo.Get(dbreview.Author);

            return new Review() { Id = dbreview.Id, Author = person, Content = dbreview.Content, MovieId = dbreview.MovieId, Score = dbreview.Score };
        }

        private ReviewDB InverseMap(Review review)
        {
            if (review == null)
                return null;
            return new ReviewDB() { Id = review.Id, Author = review.Author.Id, Content = review.Content, MovieId = review.MovieId, Score = review.Score };
        }
    }
}
