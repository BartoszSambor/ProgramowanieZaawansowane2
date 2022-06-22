namespace GettingStartedLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rmarchived : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BorrowedElems", "Archived");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BorrowedElems", "Archived", c => c.Boolean(nullable: false));
        }
    }
}
