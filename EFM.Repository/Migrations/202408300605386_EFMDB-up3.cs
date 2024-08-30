namespace EFM.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EFMDBup3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "Image", c => c.String());
            AddColumn("dbo.Category", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category", "Type");
            DropColumn("dbo.Category", "Image");
        }
    }
}
