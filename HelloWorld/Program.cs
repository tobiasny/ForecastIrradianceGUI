using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HelloWorld
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to this forecast application!");

            Console.WriteLine("Press enter to load forecast data: ");
            Console.ReadKey();
            Console.WriteLine("\n");

            AcquireForecastData data = new AcquireForecastData();
            //data.AcquireData();
            data.AcquireAndUpdateData();
            data.DisplayForecast();

            data = null;

            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
