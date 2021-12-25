using System;
using System.Collections.Generic;
using System.Linq;

namespace Module_14
{
    class Program
    {
        static void Main(string[] args)
        {
            var objects = new List<object>()
            {
               1,
               "Сергей ",
               "Андрей ",
               300,
            };

            var names = from n in objects where n is string orderby n select n;

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            names = objects.Where(n => n is string).OrderBy(n => n);

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

        } 
    }
}
