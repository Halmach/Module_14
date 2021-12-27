using System;
using System.Collections.Generic;
using System.Linq;

namespace Module_14
{
    class Program
    {
        static void Main(string[] args)
        {
            ChooseByNameLengthWithOrdering();

        }
        
        private static void ChooseByNameLengthWithOrdering()
        {
            string[] words = { "Обезьяна", "Лягушка", "Кот", "Собака", "Черепаха" };

            var animals = words.Select( a => new
            {
                Name = a,
                Length = a.Length
            }).OrderBy(a => a.Length);

            foreach (var animal in animals) Console.WriteLine(animal.Name);
        }

        private static void ConcatToNewCollectionWithOrdering()
        {
            var numsList = new List<int[]>()
            {
               new[] {2, 3, 7, 1},
               new[] {45, 17, 88, 0},
               new[] {23, 32, 44, -6},
            };

            var numbers = from nums in numsList from num in nums orderby num select num;

            numbers = numsList.SelectMany(s => s).OrderBy(s => s);

            foreach (var num in numbers) Console.WriteLine(num);
        }

        private static void ConcatByLINQ()
        {
            string[] text = { "Раз два три",
                               "четыре пять шесть",
                               "семь восемь девять" };

            var words = from str in text from word in str.Split(' ') select word;

            foreach (var word in words) Console.WriteLine(word);
        }

        private static void SelectPopulationFromCity()
        {
            // Добавим Россию с её городами
            var russianCities = new List<City>();
            russianCities.Add(new City("Москва", 11900000));
            russianCities.Add(new City("Санкт-Петербург", 4991000));
            russianCities.Add(new City("Волгоград", 1099000));
            russianCities.Add(new City("Казань", 1169000));
            russianCities.Add(new City("Севастополь", 449138));

            var shortNameCities = russianCities.Where(c => c.Name.Length <= 10).OrderBy(c => c.Name.Length);

            foreach (var city in shortNameCities)
                Console.WriteLine(city.Name + " - " + city.Population);
        }

        private static void ShowLINQBySelectNames()
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

            foreach (var name in objects.Where(n => n is string).OrderBy(n => n))
            {
                Console.WriteLine(name);
            }
        }
    }
}
