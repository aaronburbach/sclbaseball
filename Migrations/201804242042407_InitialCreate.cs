namespace SclBaseball.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScheduledDate = c.DateTime(nullable: false),
                        PlayedDate = c.DateTime(),
                        InningsPlayed = c.Int(nullable: false),
                        HomeTeam = c.String(),
                        HomeScore = c.Int(nullable: false),
                        AwayTeam = c.String(),
                        AwayScore = c.Int(nullable: false),
                        Location = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        IsOnRadio = c.Boolean(nullable: false),
                        RadioStation = c.String(),
                        IsLeagueGame = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Game");
        }
    }
}
