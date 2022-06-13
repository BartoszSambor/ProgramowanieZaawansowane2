namespace GettingStartedLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "BookCurrency", c => c.String());
            AlterColumn("dbo.Books", "Type", c => c.String());
            DropColumn("dbo.Books", "Currency");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Currency", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "BookCurrency");
        }
    }
}
