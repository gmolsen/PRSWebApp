namespace PRSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedattributestoproductpropertiesaswellasmethodstoproductcontroller : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "PhotoPath", c => c.String(maxLength: 130));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "PhotoPath", c => c.String(nullable: false, maxLength: 130));
        }
    }
}
