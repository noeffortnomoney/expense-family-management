namespace EFM.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EFMDBup4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Family", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Family", "Quantity");
        }
    }
}
