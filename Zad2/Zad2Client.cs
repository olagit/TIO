using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zad2Client.MyOwnService;


namespace Zad2Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Starship starship = new Starship();

            starship.Captain = new Person("Kapitan", 70);

            starship.Crew.Add(new Person("Aaa", 52));
            starship.Crew.Add(new Person("Bbb", 40));
            starship.Crew.Add(new Person("Ccc", 33));
            starship.Crew.Add(new Person("Ddd", 64));
            starship.Crew.Add(new Person("Eee", 5));

            PresentCrew(starship);

            BlackHole bh = new BlackHole();

            Starship newShip = new Starship();
            newShip = bh.PullStarship(starship);

            string answer = bh.UltimateAnswer();

            PresentCrew(newShip);

        }

        static void PresentCrew(Starship starship)
        {
            Console.WriteLine(starship.Captain.Name + ", " + starship.Captain.Age);

            foreach (var p in starship.Crew)
            {
                Console.WriteLine(p.Name + ", " + p.Age);
            }
        }
    }
}
