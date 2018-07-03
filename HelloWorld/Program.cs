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
            Console.WriteLine("Hello World!");

            Console.WriteLine("Press any key to proceed: ");
            Console.ReadKey();

            Console.WriteLine("Press enter to display forecast data: ");
            Console.ReadKey();

            AcquireForecastData data = new AcquireForecastData();
            data.AcquireData();

            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
