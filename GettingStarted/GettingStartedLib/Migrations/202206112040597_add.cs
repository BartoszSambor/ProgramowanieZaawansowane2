namespace GettingStartedLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Type", c => c.String());
            AddColumn("dbo.Books", "BookCurrency", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "BookCurrency");
            DropColumn("dbo.Books", "Type");
        }
    }
}
