namespace MunkaidoNyilvantarto.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentCreated_mezo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Created", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Created");
        }
    }
}
