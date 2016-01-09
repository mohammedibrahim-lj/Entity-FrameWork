using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkDemos
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class StudentTable
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentClass { get; set; }
        public string StudentAge { get; set; }
    }
    class DBCreate:DbContext
    {
        public DbSet<StudentTable> StuTab { get; set; }
    }
}
