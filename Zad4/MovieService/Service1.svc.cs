using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ClassLibrary2;
using ObjectsManager.Interfaces;
using ObjectsManager.LiteDBMovie;

namespace MovieService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        private readonly MovieRepository _movieRepository;

        public Service1()
        {
            this._movieRepository = new MovieRepository();
        }

        public int AddMovie(Movie movie)
        {
            return this._movieRepository.Add(movie);
        }

        public List<Movie> GetAllMovies()
        {
            return this._movieRepository.GetAll();
        }

        public Movie GetMovie(int id)
        {
            return this._movieRepository.Get(id);
        }

        public bool DeleteMovie(int id)
        {
            return this._movieRepository.Delete(id);
        }

        public Movie UpdateMovie(Movie movie)
        {
            return this._movieRepository.Update(movie);
        }
    }
}
