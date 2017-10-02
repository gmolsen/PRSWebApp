namespace PRSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedtypo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchaseRequestLineItems", "PurchaseRequest_PurchaseRequestID", "dbo.PurchaseRequests");
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "PurchaseRequest_PurchaseRequestID" });
            RenameColumn(table: "dbo.PurchaseRequestLineItems", name: "PurchaseRequest_PurchaseRequestID", newName: "PurchaseRequestID");
            AlterColumn("dbo.PurchaseRequestLineItems", "PurchaseRequestID", c => c.Int(nullable: false));
            CreateIndex("dbo.PurchaseRequestLineItems", "PurchaseRequestID");
            AddForeignKey("dbo.PurchaseRequestLineItems", "PurchaseRequestID", "dbo.PurchaseRequests", "PurchaseRequestID", cascadeDelete: true);
            DropColumn("dbo.PurchaseRequestLineItems", "PerchaseRequestID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseRequestLineItems", "PerchaseRequestID", c => c.Int(nullable: false));
            DropForeignKey("dbo.PurchaseRequestLineItems", "PurchaseRequestID", "dbo.PurchaseRequests");
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "PurchaseRequestID" });
            AlterColumn("dbo.PurchaseRequestLineItems", "PurchaseRequestID", c => c.Int());
            RenameColumn(table: "dbo.PurchaseRequestLineItems", name: "PurchaseRequestID", newName: "PurchaseRequest_PurchaseRequestID");
            CreateIndex("dbo.PurchaseRequestLineItems", "PurchaseRequest_PurchaseRequestID");
            AddForeignKey("dbo.PurchaseRequestLineItems", "PurchaseRequest_PurchaseRequestID", "dbo.PurchaseRequests", "PurchaseRequestID");
        }
    }
}
