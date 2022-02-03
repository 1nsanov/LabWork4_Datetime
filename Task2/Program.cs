using System;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        private static Random rnd = new Random();
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            var listHospital = new List<Hospital>();

            for (int i = 1; i <= 5; i++)
            {
                var nameCab = "Кабинет " + i;
                var idCab = rnd.Next(1, 1000);
                var fullName = "Фадеев Фрол Антонович " + i;
                var receptionDay = rnd.Next(1, 7);
                var day = rnd.Next(1, 28);
                var startReception = new DateTime(2022, 2, day, 7 + i, 00, 00);
                var endReception = new DateTime(2022, 2, day, 14 + i, 00, 00);
                listHospital.Add(new Hospital(nameCab, idCab, fullName, receptionDay, startReception, endReception));
            }

            OutputList(listHospital);

            Console.WriteLine("Введите время приема...");
            var time = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Номер дня недели приема...");
            var numberDay = int.Parse(Console.ReadLine());

            CheckReception(listHospital, time, numberDay);


            Console.ReadLine();
        }

        private static void CheckReception(List<Hospital> list, DateTime time, int day)
        {
            foreach (var item in list)
            {
                if (item.ReceptionDay == day && time.TimeOfDay > item.StartReception.TimeOfDay && time.TimeOfDay < item.EndReception.TimeOfDay)
                {
                    Console.WriteLine($"{item.FullName} сможет вас принять в {GetDayWeek(day)} в {time.ToString("t")}");
                }
                else
                {
                    Console.WriteLine($"{item.FullName} НЕ сможет вас принять в {GetDayWeek(day)}  в {time.ToString("t")}");
                }
            }
        }

        private static void OutputList(List<Hospital> list)
        {
            Console.WriteLine();
            if (list.Count > 0)
            {
                Console.WriteLine("Название кабинета  | Номер   | ФИО                      |День приема | Начало приема | Окончание приема");
                Console.WriteLine("________________________________________________________________________________________________________");
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("________________________________________________________________________________________________________");
            }
            else
            {
                Console.WriteLine("Список пуст.");
            }
            Console.WriteLine();
        }

        private static string GetDayWeek(int day)
        {
            switch (day)
            {
                case 1:
                    return "понедельник";
                case 2:
                    return "вторник";
                case 3:
                    return "среда";
                case 4:
                    return "четверг";
                case 5:
                    return "пятница";
                case 6:
                    return "суббота";
                case 7:
                    return "воскресенье";
                default:
                    return "";
                    break;
            }
        }
    }
}
