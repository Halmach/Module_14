using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Module_14
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowContactsByReadKey();

        }

        private static void ShowContactsByReadKey() 
        {
            //  создаём пустой список с типом данных Contact
            var phoneBook = new List<ContactExtended>();

            // добавляем контакты
            phoneBook.Add(new ContactExtended("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new ContactExtended("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new ContactExtended("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new ContactExtended("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new ContactExtended("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new ContactExtended("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            while (true)
            {
                var input = (Console.ReadKey().KeyChar);
                var parsed = Int32.TryParse(input.ToString(), out int pageNumber);
                Thread.Sleep(1000);
                Console.Clear();
                foreach (var person in phoneBook.Skip((pageNumber - 1) * 2).Take(2))
                {
                    Console.WriteLine(person.Name);
                }   
            }
        }

        private static void ShowKontactsPageToPage()
        {
            var contacts = new List<Contact>()
            {
               new Contact() { Name = "Андрей", Phone = 7999945005 },
               new Contact() { Name = "Сергей", Phone = 799990455 },
               new Contact() { Name = "Иван", Phone = 79999675 },
               new Contact() { Name = "Игорь", Phone = 8884994 },
               new Contact() { Name = "Анна", Phone = 665565656 },
               new Contact() { Name = "Василий", Phone = 3434 }
            };

            contacts.RemoveAll(user => user.Name == "Андрей");

            int i = 0;

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                foreach (var person in contacts.Skip(i).Take(2))
                {
                    Console.WriteLine(person.Name + "   ");
                }
                Thread.Sleep(1000);
                i = (i < 4) ? i + 2 : 0;
            }
        }

        private static void ShowHowMultipleSamplingWorkingInLINQ()
        {
            List<Student> students = new List<Student>
{
               new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
               new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
               new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
               new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            var coarses = new List<Coarse>
            {
               new Coarse {Name="Язык программирования C#", StartDate = new DateTime(2020, 12, 20)},
               new Coarse {Name="Язык SQL и реляционные базы данных", StartDate = new DateTime(2020, 12, 15)},
            };

            var studentsFilter = from s in students
                                 where s.Age < 29 && s.Languages.Contains("английский")
                                 let YearOfBirth = DateTime.Now.Year - s.Age
                                 from coarse in coarses where coarse.Name == "Язык программирования C#"                             
                                 select new 
                                 {
                                     Name = s.Name,
                                     YearOfBirth = YearOfBirth,
                                     CoarseName = coarse.Name
                                 };

            foreach (var stud in studentsFilter)
            {
                Console.WriteLine(stud.Name + " добавлен в курс " + stud.CoarseName);
            }
        }

        private static void ShowHowLetWorkingInLINQ()
        {
            // Наш список студентов
            List<Student> students = new List<Student>
{
               new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
               new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
               new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
               new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            var studentsFilter = from s in students
                                 where s.Age < 27
                                 let YearOfBirth = DateTime.Now.Year - s.Age
                                 select new Application
                                 {
                                     Name = s.Name,
                                     YearOfBirth = YearOfBirth
                                 };
            foreach (var stud in studentsFilter)
            {
                Console.WriteLine(stud.Name + " " + stud.YearOfBirth);
            }
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
