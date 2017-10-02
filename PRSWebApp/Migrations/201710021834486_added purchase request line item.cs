namespace PRSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpurchaserequestlineitem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseRequestLineItems",
                c => new
                    {
                        PurchaseRequestLineItemID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        PerchaseRequestID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        PurchaseRequest_PurchaseRequestID = c.Int(),
                    })
                .PrimaryKey(t => t.PurchaseRequestLineItemID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseRequests", t => t.PurchaseRequest_PurchaseRequestID)
                .Index(t => t.ProductID)
                .Index(t => t.PurchaseRequest_PurchaseRequestID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseRequestLineItems", "PurchaseRequest_PurchaseRequestID", "dbo.PurchaseRequests");
            DropForeignKey("dbo.PurchaseRequestLineItems", "ProductID", "dbo.Products");
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "PurchaseRequest_PurchaseRequestID" });
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "ProductID" });
            DropTable("dbo.PurchaseRequestLineItems");
        }
    }
}
