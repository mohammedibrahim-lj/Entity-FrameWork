namespace EntityFrameWorkDemos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "StudentDatabase.StudentDetails",
                c => new
                    {
                        StudentAdderss = c.String(nullable: false, maxLength: 128),
                        StudentHobbies = c.String(),
                        StudentComments = c.String(),
                        StudentFavSports = c.String(),
                        stutab_StudentID = c.Int(),
                    })
                .PrimaryKey(t => t.StudentAdderss)
                .ForeignKey("StudentDatabase.StudentTables", t => t.stutab_StudentID)
                .Index(t => t.stutab_StudentID);
            
            CreateTable(
                "StudentDatabase.StudentTables",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        StudentClass = c.String(),
                        StudentAge = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("StudentDatabase.StudentDetails", "stutab_StudentID", "StudentDatabase.StudentTables");
            DropIndex("StudentDatabase.StudentDetails", new[] { "stutab_StudentID" });
            DropTable("StudentDatabase.StudentTables");
            DropTable("StudentDatabase.StudentDetails");
        }
    }
}
