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
        public string City { get; set; }
        public string Country { get; set; }
        public string TimeArea { get; set; }
        public string UTCOffset { get; set; }
        public string Altitude { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Geobase { get; set; }
        public string GeobaseID { get; set; }
        public List<string> Precipitation;
        public List<string> WindDirectionDeg;
        public List<string> WindDirectionCode;
        public List<string> WindDirectionName;
        public List<string> WindSpeed;
        public List<string> Temperature;
        public List<string> Pressure;

        public AcquireForecastData()
        {
            City = " ";
            Country = " ";
            TimeArea = " ";
            UTCOffset = " ";
            Altitude = " ";
            Latitude = " ";
            Longitude = " ";
            Geobase = " ";
            GeobaseID = " ";
            Precipitation = new List<string>();
            WindDirectionDeg = new List<string>();
            WindDirectionCode = new List<string>();
            WindDirectionName = new List<string>();
            WindSpeed = new List<string>();
            Temperature = new List<string>();
            Pressure = new List<string>();
        }

        public void AcquireData()
        {
            String URLString = "https://www.yr.no/sted/Norge/Oslo/Oslo/Blindern/varsel_time_for_time.xml";
            XmlTextReader reader = new XmlTextReader(URLString);

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        Console.Write("<" + reader.Name);

                        while (reader.MoveToNextAttribute()) // Read the attributes.
                            Console.Write(" " + reader.Name + "='" + reader.Value + "'");
                        Console.Write(">");
                        Console.WriteLine(">");
                        break;
                    case XmlNodeType.Text: //Display the text in each element.
                        Console.WriteLine(reader.Value);
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        Console.Write("</" + reader.Name);
                        Console.WriteLine(">");
                        break;
              
                }
            }
        }

        public void AcquireAndUpdateData()
        {
            String URLString = "https://www.yr.no/sted/Norge/Oslo/Oslo/Blindern/varsel_time_for_time.xml";
            XmlTextReader reader = new XmlTextReader(URLString);

            while(reader.Read())
            {
                switch (reader.Name.ToString())
                {
                    case "name":
                        this.City = reader.ReadString();
                        break;

                    case "country":
                        this.Country = reader.ReadString();
                        break;

                    case "timezone":
                        while (reader.MoveToNextAttribute())
                        {
                            if (reader.Name == "id")
                            {
                                this.TimeArea = reader.Value;
                            }
                            if (reader.Name == "utcoffsetMinutes")
                            {
                                this.UTCOffset = reader.Value;
                            }
                        }
                        break;

                    case "location":
                        while (reader.MoveToNextAttribute())
                        {
                            switch (reader.Name)
                            {
                                case "altitude":
                                    this.Altitude = reader.Value;
                                    break;
                                case "latitude":
                                    this.Latitude = reader.Value;
                                    break;
                                case "longitude":
                                    this.Longitude = reader.Value;
                                    break;
                                case "geobase":
                                    this.Geobase = reader.Value;
                                    break;
                                case "geobaseid":
                                    this.GeobaseID = reader.Value;
                                    break;
                            }
                        }
                        break;

                    case "tabular":
                        while (reader.Read())
                        {
                            switch (reader.Name.ToString())
                            {
                                case "precipitation":
                                    reader.MoveToFirstAttribute();
                                    Precipitation.Add(reader.Value);
                                    break;

                                case "windDirection":
                                    while (reader.MoveToNextAttribute())
                                    {
                                        switch (reader.Name)
                                        {
                                            case "deg":
                                                WindDirectionDeg.Add(reader.Value);
                                                break;
                                            case "code":
                                                WindDirectionCode.Add(reader.Value);
                                                break;
                                            case "name":
                                                WindDirectionName.Add(reader.Value);
                                                break;
                                        }
                                    }
                                    break;

                                case "windSpeed":
                                    reader.MoveToFirstAttribute();
                                    WindSpeed.Add(reader.Value);
                                    break;

                                case "temperature":
                                    while (reader.MoveToNextAttribute())
                                    {
                                        if (reader.Name == "value")
                                        {
                                            Temperature.Add(reader.Value);
                                        }
                                    }
                                    break;

                                case "pressure":
                                    while (reader.MoveToNextAttribute())
                                    {
                                        if (reader.Name == "value")
                                        {
                                            Pressure.Add(reader.Value);
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }
        }

        public void DisplayForecast()
        {
            Console.WriteLine("City: " + this.City);
            Console.WriteLine("Country: " + this.Country);
            Console.WriteLine("TimeArea: " + this.TimeArea);
            Console.WriteLine("UTC offset: " + this.UTCOffset);
            Console.WriteLine("Altitude: " + this.Altitude);
            Console.WriteLine("Latitude: " + this.Latitude);
            Console.WriteLine("Longitude: " + this.Longitude);
            Console.WriteLine("Geobase: " + this.Geobase);
            Console.WriteLine("GeobaseID: " + this.GeobaseID);

            Console.WriteLine("Number of elements in temperature: " + this.Temperature.Count);

            for (int i = 0; i < Precipitation.Count; i++)
            {
                Console.WriteLine("Temperature at time " + i + ": " + Temperature[i]);
            }
        }

    }
}
