using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ClassLibrary2;
using ObjectsManager.Interfaces;
using ObjectsManager.LiteDBReviewPerson;

namespace ReviewPersonService
{
    public class Service1 : IService1
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IPersonRepository _personRepository;

        public Service1()
        {
            this._reviewRepository = new ReviewRepository();
            this._personRepository = new PersonRepository();
        }

        public int AddPerson(Person person)
        {
            return this._personRepository.Add(person);
        }

        public int AddReview(Review review)
        {
            return this._reviewRepository.Add(review);
        }

        public List<Person> GetAllPersons()
        {
            return this._personRepository.GetAll();
        }

        public List<Review> GetAllReviews()
        {
            return this._reviewRepository.GetAll();
        }

        public Person GetPerson(int id)
        {
            return this._personRepository.Get(id);
        }

        public Review GetReview(int id)
        {
            return this._reviewRepository.Get(id);
        }

        public bool DeletePerson(int id)
        {
            return this._personRepository.Delete(id);
        }

        public bool DeleteReview(int id)
        {
            return this._reviewRepository.Delete(id);
        }

        public Person UpdatePerson(Person person)
        {
            return this._personRepository.Update(person);
        }

        public Review UpdateReview(Review review)
        {
            return this._reviewRepository.Update(review);
        }
    }
}
