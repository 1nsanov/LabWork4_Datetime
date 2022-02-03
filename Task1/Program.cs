using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            DateTime dateBirthday;
            Console.WriteLine("Введите свою дату рождения(yyyy.mm.dd)...");
            try
            {
                dateBirthday = DateTime.Parse(Console.ReadLine());

            }
            catch (Exception)
            {
                throw new Exception("Некорректный ввод даты");
            }

            for (int i = 1; i <= 20; i++)
            {
                dateBirthday = dateBirthday.AddYears(5);
                Console.WriteLine($"{i} юбилей - {dateBirthday:yyyy, dddd}");
            }

            Console.ReadLine();
        }
    }
}
