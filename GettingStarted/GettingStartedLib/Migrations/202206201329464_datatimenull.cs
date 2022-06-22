namespace GettingStartedLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatimenull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BorrowedElems", "BorrowTime", c => c.DateTime());
            AlterColumn("dbo.BorrowedElems", "ReturnDeadline", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BorrowedElems", "ReturnDeadline", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BorrowedElems", "BorrowTime", c => c.DateTime(nullable: false));
        }
    }
}
