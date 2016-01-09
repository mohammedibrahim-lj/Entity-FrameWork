namespace EntityFrameWorkDemos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class demo1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "StudentDatabase.StudentDetails",
                c => new
                    {
                        StudentID = c.String(nullable: false, maxLength: 128),
                        StudentAdderss = c.String(),
                        StudentHobbies = c.String(),
                        StudentComments = c.String(),
                        StudentFavSports = c.String(),
                        stutab_StudentID = c.Int(),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.StudentTab", t => t.stutab_StudentID)
                .Index(t => t.stutab_StudentID);
            
            CreateTable(
                "dbo.StudentTab",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        StudentClass = c.String(),
                        StudentAge = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("StudentDatabase.StudentDetails", "stutab_StudentID", "dbo.StudentTab");
            DropIndex("StudentDatabase.StudentDetails", new[] { "stutab_StudentID" });
            DropTable("dbo.StudentTab");
            DropTable("StudentDatabase.StudentDetails");
        }
    }
}
