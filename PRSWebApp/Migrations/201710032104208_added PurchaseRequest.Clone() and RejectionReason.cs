namespace PRSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPurchaseRequestCloneandRejectionReason : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseRequests", "RejectionReason", c => c.String(maxLength: 80));
            DropColumn("dbo.PurchaseRequests", "SubmittedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseRequests", "SubmittedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.PurchaseRequests", "RejectionR`eason");
        }
    }
}
