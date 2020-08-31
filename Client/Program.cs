using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("Client.exe.config");

            Kernel kernel = new Kernel();

            Console.WriteLine("Hello! Change what do u want:\n" +
                    "1 - add new line\n" +
                    "2 - delete last line\n" +
                    "3 - add new station\n" +
                    "4 - delete last station\n" +
                    "5 - change last station\n" +
                    "6 - search station on \"newItem\" name\n" +
                    "7 - count of station last line\n" +
                    "8 - list of station last line\n" +
                    "9 - full list of lines\n" +
                    "0 - exit");

            while (true)
            {
                int answer = int.Parse(Console.ReadLine());

                if (answer == 0)
                    break;

                switch (answer)
                {
                    case 1:
                        Console.WriteLine(kernel.AddNewLine());
                        break;
                    case 2:
                        Console.WriteLine(kernel.RemoveLastLine());
                        break;
                    case 3:
                        Console.WriteLine(kernel.AddNewStation());
                        break;
                    case 4:
                        Console.WriteLine(kernel.RemoveLastStation());
                        break;
                    case 5:
                        Console.WriteLine(kernel.ChangeLastStation());
                        break;
                    case 6:
                        Console.WriteLine(kernel.SearchStationOnName("newItem"));
                        break;
                    case 7:
                        Console.WriteLine(kernel.GetCountOfStationOnLastLine());
                        break;
                    case 8:
                        Console.WriteLine(kernel.GetListOfStationOnLastLine());
                        break;
                    case 9:
                        Console.WriteLine(kernel.GetFullListOfLine());
                        break;
                    case 0:
                        goto Exit;
                        break;
                    default:
                        break;
                }
            }
            Exit:

            Console.ReadKey();
        }
    }
}
