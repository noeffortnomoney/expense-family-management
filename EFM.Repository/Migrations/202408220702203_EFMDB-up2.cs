namespace EFM.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EFMDBup2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "IsActived", c => c.Boolean(nullable: false));
            AddColumn("dbo.User", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "IsDeleted");
            DropColumn("dbo.User", "IsActived");
        }
    }
}
