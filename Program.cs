using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Camp woot = new Camp(555, 666, 50, 50, 50);
            Camp wootWoot = new Camp(123, 321, 32, 11, 4);

            Camp joined = woot + wootWoot;
            Console.WriteLine($"joined = {joined}");
            Console.WriteLine($"woot > wootWoot {woot > wootWoot}");
            Console.WriteLine($"woot < wootWoot {woot < wootWoot}");
            Console.WriteLine(woot == wootWoot);

            if (woot > wootWoot)
                Console.WriteLine("woot is bigger");

            Console.WriteLine("CHALLENGE");
            Console.WriteLine("===================");

            CampSer woott = new CampSer(555, 666, 50, 50, 50);

            XmlSerializer myXmlSerialiser = new XmlSerializer(typeof(CampSer));

            using (Stream file = new FileStream(@"*DIRECTORY*\xmlfile.xml", FileMode.Create))
            {
                myXmlSerialiser.Serialize(file, woott);
            }

            CampSer readCampOne = null;
            CampSer readCampTwo = null;

            using (Stream file = new FileStream(@"*DIRECTORY*\xmlfile.xml", FileMode.Open))
            {
                readCampOne=myXmlSerialiser.Deserialize(file) as CampSer;
            }

            using (Stream file = new FileStream(@"*DIRECTORY*\xmlfile.xml", FileMode.Open))
            {
                readCampTwo = myXmlSerialiser.Deserialize(file) as CampSer;
            }

            Console.WriteLine(readCampOne.GetHashCode() == readCampTwo.GetHashCode());

            Console.WriteLine($"HASHCODE1:{readCampOne.GetHashCode()}");
            Console.WriteLine($"HASHCODE2:{readCampTwo.GetHashCode()}");
        }
    }
}
