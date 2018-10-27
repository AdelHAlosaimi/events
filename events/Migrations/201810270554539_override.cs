namespace events.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _override : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Meetings", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Meetings", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Meetings", new[] { "Genre_Id" });
            DropIndex("dbo.Meetings", new[] { "User_Id" });
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Meetings", "Venue", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Meetings", "Genre_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Meetings", "User_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Meetings", "Genre_Id");
            CreateIndex("dbo.Meetings", "User_Id");
            AddForeignKey("dbo.Meetings", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Meetings", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meetings", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Meetings", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Meetings", new[] { "User_Id" });
            DropIndex("dbo.Meetings", new[] { "Genre_Id" });
            AlterColumn("dbo.Meetings", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Meetings", "Genre_Id", c => c.Byte());
            AlterColumn("dbo.Meetings", "Venue", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String());
            CreateIndex("dbo.Meetings", "User_Id");
            CreateIndex("dbo.Meetings", "Genre_Id");
            AddForeignKey("dbo.Meetings", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Meetings", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
