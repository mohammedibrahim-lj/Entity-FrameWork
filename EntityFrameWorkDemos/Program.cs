using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Data.Entity.Validation;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EntityFrameWorkDemos
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                DBCreate db = new DBCreate();
                var value1 = new StudentTable() { StudentID = 1, StudentName = "ibrahim", StudentClass = "MCA", StudentAge = 25 };
                db.StuTabs.Add(value1);
                //db.StuTabs.Add(new StudentTable() { StudentName = "ibrahim", StudentClass = "MCA", StudentAge = "26" });
                //db.StuTabs.Add(new StudentTable() { StudentName = "ibu", StudentClass = "MCA", StudentAge = "26" });
                //db.StuTabs.Add(new StudentTable() { StudentName = "MMM", StudentClass = "MCA", StudentAge = "26" });
                //db.StuTabs.Add(new StudentTable() { StudentName = "ddd", StudentClass = "MCA", StudentAge = "26" });
                //db.StuTabs.Add(new StudentTable() { StudentName = "EEE", StudentClass = "MCA", StudentAge = "26" });
                db.studet.Add(new StudentDetails() { stutab = value1,StudentID=1, StudentAdderss = "Coimbatore", StudentComments = "Good", StudentHobbies = "Stampcollection", StudentFavSports = "cricket" });
                db.SaveChanges();
                var datas = db.StuTabs.ToList();
                foreach (var items in datas)
                {
                    Console.WriteLine(items.StudentName.ToString());
                }
                Console.ReadKey();
            }

            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.
          PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }
    }
    class StudentTable
    {
        [Key]
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentClass { get; set; }
        public int StudentAge { get; set; }
        public List<StudentDetails> studets{get;set;}
    }
    class StudentDetails
    {
       [Key]
        
        public int StudentID { get; set; }
        public string StudentAdderss { get; set; }
        public string StudentHobbies { get; set; }
        public string StudentComments { get; set; }
        public string StudentFavSports { get; set; }
        [ForeignKey("StudentID")]
        public virtual StudentTable stutab{get;set;}
    }
    class DBCreate:DbContext
    {
        public DBCreate()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<DBCreate>());
        }
        public DbSet<StudentDetails> studet { get; set; }
        public DbSet<StudentTable> StuTabs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("StudentDatabase");
            
            //modelBuilder.Entity<StudentTable>().HasKey(t => new{t.StudentID});
            //modelBuilder.Entity<StudentTable>().ToTable("StudentTab", "dbo");
            base.OnModelCreating(modelBuilder);
        }
    }   
}
