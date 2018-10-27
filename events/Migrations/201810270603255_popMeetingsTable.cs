namespace events.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class popMeetingsTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id,Name) VALUES(1,'Arabic')");
            Sql("INSERT INTO Genres (Id,Name) VALUES(2,'English')");
            Sql("INSERT INTO Genres (Id,Name) VALUES(3,'Greek')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id In (1,2,3) ");
        }
    }
}
