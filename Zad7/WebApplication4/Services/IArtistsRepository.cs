using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication4.Services
{
    public interface IArtistsRepository
    {
        List<Artist> GetAll();
        Artist Get(int id);
        int Add(Artist artist);
        Artist Update(Artist artist);
        bool Delete(int id);
    }
}
