namespace YummyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Feature : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Features", "ImageUrl", c => c.String());
            AlterColumn("dbo.Features", "Title", c => c.String());
            AlterColumn("dbo.Features", "Description", c => c.String());
            AlterColumn("dbo.Features", "VideoUrl", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Features", "VideoUrl", c => c.String(nullable: false));
            AlterColumn("dbo.Features", "Description", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Features", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Features", "ImageUrl", c => c.String(nullable: false));
        }
    }
}
