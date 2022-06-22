namespace GettingStartedLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BorrowedElems", "BorrowTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.BorrowedElems", "ReturnDeadline", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BorrowedElems", "ReturnDeadline");
            DropColumn("dbo.BorrowedElems", "BorrowTime");
        }
    }
}
