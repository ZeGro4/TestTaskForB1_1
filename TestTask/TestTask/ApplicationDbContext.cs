using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    internal class ApplicationDbContext : DbContext // Класс для работы с бд
    {

        public DbSet<FilesTable> FilesTable { get; set; } // сущность, представляющая таблицу в бд
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // функция, срабатываемма во время создания DBContext
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=TestTaskDb;Trusted_Connection=True;TrustServerCertificate=True"); // строка подключения к бд
        }

        

    }

}
