namespace GettingStartedLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class history : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BorrowedHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User = c.String(),
                        BookId = c.Int(nullable: false),
                        BorrowTime = c.DateTime(),
                        ReturnDeadline = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BorrowedHistories", "BookId", "dbo.Books");
            DropIndex("dbo.BorrowedHistories", new[] { "BookId" });
            DropTable("dbo.BorrowedHistories");
        }
    }
}
