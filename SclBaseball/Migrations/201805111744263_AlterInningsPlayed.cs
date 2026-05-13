namespace SclBaseball.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterInningsPlayed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Game", "InningsPlayed", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Game", "InningsPlayed", c => c.Int(nullable: false));
        }
    }
}
