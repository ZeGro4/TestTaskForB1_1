using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    static class FileManager // Клас для работы с файлами
    {
        public static void CreateTextFile(string path, int countString) // функция создания файла
        {

            try
            {
                using (StreamWriter file = new StreamWriter(path,false,Encoding.UTF8)) // Открываем поток для работы с файлом
                {
                    for (int i = 0; i < countString; i++)
                    {

                        string RandomRuString = Randomizer.GenerateString(10, "ru"); // генерируем строку из русского алфавита
                        string RandomEnString = Randomizer.GenerateString(10, "en"); // генерируем строку из английского алфавита
                        int RandomNumber = Randomizer.GenerateInt(1, 100000000); // случайное число int в заданном диапазоне

                        decimal RandomDecimal = Randomizer.GenerateDouble(1, 19, 8); // случайное число с числом знаков после запятой равное 8

                        DateTime RandomDate = Randomizer.GenerateDate(5); // Случайная дата за последние 5 лет
                        file.WriteLine($"{RandomDate.ToShortDateString()}||{RandomEnString}||{RandomRuString}||{RandomNumber}||{RandomDecimal}"); // запись в файл
                    }
                }
                
            }
            catch(Exception ex) // обработка ошибок
            {
                Console.WriteLine("Error for creating file: " +  ex.Message);

            }

        }


        public static int MergingAllFiles(string pathToFolder, string deletedString) { // функция для соединения в один файл

            DirectoryInfo directoryInfo = new DirectoryInfo(pathToFolder); // объект для работы с каталогами

            FileInfo[] allFiles = directoryInfo.GetFiles(); // получаем все фалйы каталога

            int countDeletedString = 0; // переменная для подсчета удаленны строк

            using(StreamWriter fs = new StreamWriter($"{pathToFolder}\\AllFiles\\AllText.txt")) // Поток для записи в файл
            {
              
               
                for (int i = 0; i <allFiles.Length ; i++) // цикл перебоа всех файлов
                {
                    FileInfo file = allFiles[i]; // получаем текущий файл
                    string pathFile = file.FullName; // имя файла

                    using(StreamReader sr = new StreamReader(pathFile)) // поток для чтения файла
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null) // читаем файл пока не закончится
                        {
                            if (line.Contains(deletedString)) countDeletedString++; // увеличиваем счетчик удаленных строк
                            fs.WriteLine(line.Replace(deletedString, "")); // удаляем строку
                        }

                    }

                    if (i % 10 == 0)
                    {
                        Console.WriteLine($"Merging {i} files"); // Вывод результата каждые 10 файлов
                    }
                }
            }


            
            return countDeletedString;

        }


        public static void SaveToDataBase(string path) { // сохранение в бд

            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            FileInfo[] allFiles = directoryInfo.GetFiles();

            using (var dbContext = new ApplicationDbContext()) // поток работы с бд
            {
                int IdTable = 0; // id для таблиц
                for (int i = 0; i < allFiles.Length; i++)
                {
                    FileInfo file = allFiles[i];
                    string pathFile = file.FullName;


                    using (StreamReader sr = new StreamReader(file.FullName)) // поток чтения 
                    {
                        int counter = 0;
                        string line;
                        while ((line = sr.ReadLine()) != null) {
                            string[] Randomvalues = line.Split("||"); // разделение строки данных в файле
                            counter++;
                            IdTable++;
                            dbContext.FilesTable.Add(new FilesTable() { IDTable = IdTable, RandomDate = DateTime.Parse(Randomvalues[0]), RandomEuString = Randomvalues[1], RandomRuString = Randomvalues[2], RandomNumber = int.Parse(Randomvalues[3]), RandomDecimalNumber = decimal.Parse(Randomvalues[4]) }); // добавление данных в бд 
                            
                            Console.WriteLine($"Import lines {counter}/ 100 000"); // прогресс добавления
                        }

                    }

                    dbContext.SaveChanges();// сохранение изменений
                    Console.WriteLine($"File {file.Name} saved");
                    
                }
               
            }
        }
    }
   
}
