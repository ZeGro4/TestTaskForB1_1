

using Microsoft.EntityFrameworkCore;
using TestTask;

class Program
{
    public static void Main(string[] args)
    {
        string path = "C:\\src"; // путь к директории





        //Console.WriteLine("Start file generate...");
        //for (int i = 1; i < 101; i++)
        //{
        //    FileManager.CreateTextFile($"{path}\\myfile{i}.txt", 100000);
        //    if (i % 10 == 0)
        //    {
        //        Console.WriteLine($"Generate {i} files");
        //    }
        //}
        //Console.WriteLine("Finish generate!");
        //Console.WriteLine("Start Merge Files!");
        //Console.WriteLine(FileManager.MergingAllFiles(path, "asd"));
        //Console.WriteLine("Finish merge!");

        Console.WriteLine("Start save data");
        FileManager.SaveToDataBase(path);
        Console.WriteLine("Finish save Data");


        

    }
}