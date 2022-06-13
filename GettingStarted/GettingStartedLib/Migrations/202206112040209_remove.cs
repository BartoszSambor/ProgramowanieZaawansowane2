namespace GettingStartedLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "Type");
            DropColumn("dbo.Books", "BookCurrency");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "BookCurrency", c => c.String());
            AddColumn("dbo.Books", "Type", c => c.String());
        }
    }
}
