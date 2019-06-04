namespace TrueStudentInformation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Academies",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Academy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrueStudents",
                c => new
                    {
                        Num = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.String(),
                        Firstscore = c.Int(nullable: false),
                        Secondscore = c.Int(nullable: false),
                        Thirdscore = c.Int(nullable: false),
                        Classroomid = c.String(),
                    })
                .PrimaryKey(t => t.Num);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TrueStudents");
            DropTable("dbo.Classrooms");
            DropTable("dbo.Academies");
        }
    }
}
