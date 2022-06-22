namespace GettingStartedLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class archived : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BorrowedElems", "Archived", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BorrowedElems", "Archived");
        }
    }
}
