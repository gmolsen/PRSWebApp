namespace PRSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idontknowjustwork : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 32));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 16));
        }
    }
}
