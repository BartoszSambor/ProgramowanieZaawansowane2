namespace GettingStartedLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "BookType", c => c.String());
            AddColumn("dbo.Books", "BookPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Books", "BoughtCurrency", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "BoughtCurrency");
            DropColumn("dbo.Books", "BookPrice");
            DropColumn("dbo.Books", "BookType");
        }
    }
}
