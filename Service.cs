using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_v2
{
    /// <summary>
    /// Статичний клас, що містить сервісні методи для управління дверима транспортного засобу.
    /// </summary>
    internal static class Service
    {
        /// <summary>
        /// Метод для відкриття дверей транспортного засобу.
        /// </summary>
        public static void OpenTheDoor()
        {
            Console.WriteLine("двері відчиняютсья");
        }
        /// <summary>
        /// Метод для закриття дверей транспортного засобу.
        /// </summary>
        public static void CloseTheDoor()
        {
            Console.WriteLine("двері зачиняються");
        }
    }
}
