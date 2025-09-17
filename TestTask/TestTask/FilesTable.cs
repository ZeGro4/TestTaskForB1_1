using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TestTask
{
    internal class FilesTable // Клас представляющий таблицу в бд
    {
        [Key]  public int IDTable { get; set; }
        public DateTime RandomDate { get; set; }
        public string RandomEuString { get; set; }
        public string RandomRuString { get; set; }

        public int RandomNumber { get; set; }

        public decimal RandomDecimalNumber { get; set; }
    }
}
