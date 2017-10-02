namespace PRSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ifthisdoesntworkigivethefuckup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        VendorPartNumber = c.String(nullable: false, maxLength: 30),
                        Name = c.String(nullable: false, maxLength: 30),
                        Price = c.Double(nullable: false),
                        Unit = c.String(nullable: false, maxLength: 30),
                        PhotoPath = c.String(nullable: false, maxLength: 130),
                        VendorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Vendors", t => t.VendorID, cascadeDelete: true)
                .Index(t => t.VendorID);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        VendorID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false, maxLength: 255),
                        Address = c.String(nullable: false, maxLength: 255),
                        City = c.String(nullable: false, maxLength: 255),
                        State = c.String(nullable: false, maxLength: 2),
                        Zip = c.String(nullable: false, maxLength: 5),
                        Phone = c.String(nullable: false, maxLength: 12),
                        Email = c.String(nullable: false, maxLength: 100),
                        IsPreapproved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VendorID);
            
            CreateTable(
                "dbo.PurchaseRequestLineItems",
                c => new
                    {
                        PurchaseRequestLineItemID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        PurchaseRequestID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseRequestLineItemID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseRequests", t => t.PurchaseRequestID, cascadeDelete: true)
                .Index(t => t.PurchaseRequestID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.PurchaseRequests",
                c => new
                    {
                        PurchaseRequestID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 80),
                        Justification = c.String(nullable: false, maxLength: 80),
                        DateNeeded = c.DateTime(nullable: false),
                        DeliveryMode = c.String(nullable: false, maxLength: 20),
                        Status = c.String(nullable: false, maxLength: 15),
                        Total = c.Double(nullable: false),
                        SubmittedDate = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseRequestID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseRequestLineItems", "PurchaseRequestID", "dbo.PurchaseRequests");
            DropForeignKey("dbo.PurchaseRequests", "UserID", "dbo.Users");
            DropForeignKey("dbo.PurchaseRequestLineItems", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "VendorID", "dbo.Vendors");
            DropIndex("dbo.PurchaseRequests", new[] { "UserID" });
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "ProductID" });
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "PurchaseRequestID" });
            DropIndex("dbo.Products", new[] { "VendorID" });
            DropTable("dbo.PurchaseRequests");
            DropTable("dbo.PurchaseRequestLineItems");
            DropTable("dbo.Vendors");
            DropTable("dbo.Products");
            DropTable("dbo.Logs");
        }
    }
}
