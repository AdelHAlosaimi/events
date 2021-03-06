namespace events.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createmeetingtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Meetings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Venue = c.String(),
                        Genre_Id = c.Byte(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Genre_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meetings", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Meetings", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Meetings", new[] { "User_Id" });
            DropIndex("dbo.Meetings", new[] { "Genre_Id" });
            DropTable("dbo.Meetings");
            DropTable("dbo.Genres");
        }
    }
}
