using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2;

namespace ObjectsManager.Interfaces
{
    public interface IReviewsRepository
    {
        List<Review> GetAll();
        int Add(Review review);
        Review Get(int id);
        Review Update(Review review);
        bool Delete(int id);
    }
}
