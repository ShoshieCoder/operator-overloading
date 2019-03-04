using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Camp
    {
        private readonly int id;

        public int Latitude { get; private set; }
        public int Longitude { get; private set; }
        public int NumberOfPeople { get; private set; }
        public int NumberOfTents { get; private set; }
        public int NumberOfFlashLights { get; private set; }

        private static int lastCampId = 0;

        public Camp(int latitude, int longitude, int numberOfPeople, int numberOfTents, int numberOfFlashLights)
        {
            this.id = ++lastCampId;
            Latitude = latitude;
            Longitude = longitude;
            NumberOfPeople = numberOfPeople;
            NumberOfTents = numberOfTents;
            NumberOfFlashLights = numberOfFlashLights;
        }

        public override string ToString()
        {
            return ($"ID:{this.id}, Latitude:{this.Latitude}, Longtitude:{this.Longitude}, People:{this.NumberOfPeople}, Tents:{this.NumberOfTents}, Flash Lights:{this.NumberOfFlashLights}");
        }

        public static bool operator ==(Camp c1, Camp c2)
        {
            if (ReferenceEquals(c1, null) && ReferenceEquals(c2, null))
                return true;
            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
                return false;

            return c1.id == c2.id;
        }

        public static bool operator !=(Camp c1, Camp c2)
        {

            return !(c1.id == c2.id);
        }

        public override bool Equals(object obj)
        {
            Camp other = obj as Camp;
            return this.id == other.id;
        }

        public override int GetHashCode()
        {
            return this.id;
        }

        public static bool operator >(Camp c1, Camp c2)
        {

            return c1.NumberOfPeople > c2.NumberOfPeople;
        }

        public static bool operator <(Camp c1, Camp c2)
        {

            return !(c1.NumberOfPeople > c2.NumberOfPeople);
        }

        public static Camp operator +(Camp camp1, Camp camp2)
        {
            return new Camp((camp1.Latitude + camp2.Latitude) / 2, (camp1.Longitude + camp2.Longitude) / 2,
                camp1.NumberOfPeople + camp2.NumberOfPeople, camp1.NumberOfTents + camp2.NumberOfTents,
                camp1.NumberOfFlashLights + camp2.NumberOfFlashLights);
        }


    }
}
