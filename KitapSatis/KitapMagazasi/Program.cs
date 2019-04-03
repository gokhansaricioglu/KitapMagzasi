using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KitapMagazasi
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            

            IEnumerable<int> squares = Enumerable.Range(10, 5).Select(x => x * x);

            foreach (var item in squares)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();


        }
    }
}
