using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

namespace HelloWorld
{
    public class AcquireForecastData
    {
        public void AcquireData()
        {
            String URLString = "http://www.yr.no/place/United_Arab_Emirates/Dubai/Dubai/forecast.xml";
            XmlTextReader reader = new XmlTextReader(URLString);

            while (reader.Read())
            {
                Console.WriteLine(reader.Name);
            }
            Console.ReadLine();
        }

        public AcquireForecastData() { }
    }
}
