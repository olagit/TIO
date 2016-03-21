using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Zad2
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri address = new Uri("http://localhost:9009/Test");
            ServiceHost selfHost = new ServiceHost(typeof(BlackHole), address);

            try
            {
                selfHost.AddServiceEndpoint(typeof(IBlackHole), new WSHttpBinding(), "TestServiceEndpoint");
                ServiceMetadataBehavior smd = new ServiceMetadataBehavior();
                smd.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smd);

                selfHost.Open();
                Console.WriteLine("Running");
                Console.ReadLine();
                selfHost.Close();
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine(ex.Message);
                selfHost.Abort();
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Starship
    {
        public string Name { get; set; }
        public Person Captain { get; set; }
        public List<Person> Crew = new List<Person>();
    }

    public class Planet
    {
        public string Name { get; set; }
        public int Mass { get; set; }
    }

    [ServiceContract]
    public interface IBlackHole
    {
        [OperationContract]
        Starship PullStarship(Starship ship);
        string UltimateAnswer();
    }

    class BlackHole : IBlackHole
    {
        public string UltimateAnswer()
        {
            return 42.ToString();
        }

        Starship IBlackHole.PullStarship(Starship ship)
        {
            if(ship.Captain.Age <= 40)
            {
                foreach(var c in ship.Crew)
                {
                    c.Age += 20;
                }
            }

            return ship;
        }
    }
}