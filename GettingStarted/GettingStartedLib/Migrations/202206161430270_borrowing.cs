namespace GettingStartedLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class borrowing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BorrowedElems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User = c.String(),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
            AddColumn("dbo.Books", "Borrowed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BorrowedElems", "BookId", "dbo.Books");
            DropIndex("dbo.BorrowedElems", new[] { "BookId" });
            DropColumn("dbo.Books", "Borrowed");
            DropTable("dbo.BorrowedElems");
        }
    }
}
