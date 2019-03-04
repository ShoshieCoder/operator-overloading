using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class CampSer
    {
        public int id;

        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public int NumberOfPeople { get; set; }
        public int NumberOfTents { get; set; }
        public int NumberOfFlashLights { get; set; }

        private static int lastCampId = 0;

        public CampSer(int latitude, int longitude, int numberOfPeople, int numberOfTents, int numberOfFlashLights)
        {
            this.id = ++lastCampId;
            Latitude = latitude;
            Longitude = longitude;
            NumberOfPeople = numberOfPeople;
            NumberOfTents = numberOfTents;
            NumberOfFlashLights = numberOfFlashLights;
        }

        public CampSer()
        {
        }

        public override string ToString()
        {
            return ($"ID:{this.id}, Latitude:{this.Latitude}, Longtitude:{this.Longitude}, People:{this.NumberOfPeople}, Tents:{this.NumberOfTents}, Flash Lights:{this.NumberOfFlashLights}");
        }

        public static bool operator ==(CampSer c1, CampSer c2)
        {
            if (ReferenceEquals(c1, null) && ReferenceEquals(c2, null))
                return true;
            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
                return false;

            return c1.id == c2.id;
        }

        public static bool operator !=(CampSer c1, CampSer c2)
        {

            return !(c1.id == c2.id);
        }

        public override bool Equals(object obj)
        {
            CampSer other = obj as CampSer;
            return this.id == other.id;
        }

        public override int GetHashCode()
        {
            return this.id;
        }

        public static bool operator >(CampSer c1, CampSer c2)
        {

            return c1.NumberOfPeople > c2.NumberOfPeople;
        }

        public static bool operator <(CampSer c1, CampSer c2)
        {

            return !(c1.NumberOfPeople > c2.NumberOfPeople);
        }

        public static CampSer operator +(CampSer camp1, CampSer camp2)
        {
            return new CampSer((camp1.Latitude + camp2.Latitude) / 2, (camp1.Longitude + camp2.Longitude) / 2,
                camp1.NumberOfPeople + camp2.NumberOfPeople, camp1.NumberOfTents + camp2.NumberOfTents,
                camp1.NumberOfFlashLights + camp2.NumberOfFlashLights);
        }
    }
}
