namespace GettingStartedLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rename3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Type", c => c.String());
            AddColumn("dbo.Books", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Books", "Currency", c => c.String());
            AddColumn("dbo.Books", "Pages", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "BookType");
            DropColumn("dbo.Books", "BookPrice");
            DropColumn("dbo.Books", "BoughtCurrency");
            DropColumn("dbo.Books", "PagesCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "PagesCount", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "BoughtCurrency", c => c.String());
            AddColumn("dbo.Books", "BookPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Books", "BookType", c => c.String());
            DropColumn("dbo.Books", "Pages");
            DropColumn("dbo.Books", "Currency");
            DropColumn("dbo.Books", "Price");
            DropColumn("dbo.Books", "Type");
        }
    }
}
