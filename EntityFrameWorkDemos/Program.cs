using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            DBCreate db = new DBCreate();
            db.StuTab.Add(new StudentTable { StudentName = "ibrahim", StudentClass = "MCA", StudentAge = "26" });
            db.StuTab.Add(new StudentTable { StudentName = "ibu", StudentClass = "MCA", StudentAge = "26" });
            db.StuTab.Add(new StudentTable { StudentName = "MMM", StudentClass = "MCA", StudentAge = "26" });
            db.StuTab.Add(new StudentTable { StudentName = "ddd", StudentClass = "MCA", StudentAge = "26" });
            db.StuTab.Add(new StudentTable { StudentName = "EEE", StudentClass = "MCA", StudentAge = "26" });
            db.SaveChanges();
            var datas = db.StuTab.ToList();
            foreach(var items in datas)
            {
                Console.WriteLine(items.StudentName.ToString());
            }
            Console.ReadKey();
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
        public DBCreate()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<DBCreate>());
        }
       
        public DbSet<StudentTable> StuTab { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentTable>().HasKey(t => t.StudentID);
            base.OnModelCreating(modelBuilder);
        }
    }
    
}
