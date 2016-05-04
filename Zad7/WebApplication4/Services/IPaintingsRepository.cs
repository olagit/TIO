using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication4.Services
{
    public interface IPaintingsRepository
    {
        List<Painting> GetAll();
        Painting Get(int id);
        int Add(Painting Painting);
        Painting Update(Painting Painting);
        bool Delete(int id);
    }
}
