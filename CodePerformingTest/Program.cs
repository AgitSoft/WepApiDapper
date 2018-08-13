using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePerformingTest
{


    public class Program
    {
        static void Main(string[] args)
        {
            Boolwer boolwer = new Boolwer();

            if (boolwer.Deneme())
            {
                Console.WriteLine("Doğru");
            }
            else
            {
                Console.WriteLine("Yanlış");
            }
           
            Console.ReadKey(true);
        }


    }


}
