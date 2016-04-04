using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicAdventureDTO
{
    class SpaceSystem
    {
        public SpaceSystem(string name, int msp, int bd, int g)
        {
            Name = name;
            MinShipPower = msp;
            BaseDistance = bd;
            Gold = g;
        }

        [DataMember]
        string Name { get; set; }
        private int MinShipPower { get; set; }
        [DataMember]
        int BaseDistance { get; set; }
        private int Gold { get; set; }
    }

    class Starship
    {
        [DataMember]
        List<Person> Crew;
        [DataMember]
        int Gold { get; set; }
        [DataMember]
        int ShipPower { get; set; }
    }

    class Person
    {
        public Person(string name, float age)
        {
            Name = name;
            Age = age;
        }

        string Name { get; set; }
        string Nick { get; set; }
        float Age { get; set; }
    }
}
