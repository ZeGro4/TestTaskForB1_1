using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    static  class Randomizer // класс для генерации случайных значений
    {

        public static int GenerateInt(int minvalue, int maxvalue)
        {
            return new Random().Next(minvalue, maxvalue); // возврат случайных целых чисел в заданном диапазоне
        }

        public static decimal GenerateDouble(int minvalue, int maxvalue, int dgree)
        {

            return new Random().Next(minvalue, maxvalue) + Math.Round((decimal)new Random().NextDouble(), dgree); // возврат случаного числа с указанным числом знаков после запятой
        }

        public static DateTime GenerateDate(int yearbefore) // генерация случайно даты 
        {
            DateTime currentDate = DateTime.Now; // текущая дата
            DateTime startDate = new DateTime(DateTime.Now.Year - yearbefore, 1, 1); // дата 5 лет назад
            TimeSpan timeSpan = currentDate - startDate; // время между ними 
            DateTime RandomDate = startDate.AddDays(new Random().Next(timeSpan.Days)); // добавление к минимальному значею случаное количество дней за 5 лет
            return RandomDate;
        }

        public static string GenerateString(int length, string alphabet) // генерация строк
        {

            string symbols;

            switch (alphabet)
            {
                case "ru":
                    symbols = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
                    break;
                case "en":
                    symbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                    break;
                default:
                    symbols = null;
                    break;
            }

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {

                if (symbols != null)
                {
                    stringBuilder.Append(symbols[new Random().Next(0, symbols.Length)]); // генерация случайных букв из алфавита, заданного выше
                }

            }

            return stringBuilder.ToString();
        }

    }
}
