namespace EFM.Repository.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class EFMDB_up3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Address", c => c.String());
            AlterColumn("dbo.Budget", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Budget", "UpdatedBy", c => c.Int());
            AlterColumn("dbo.Budget", "DeletedBy", c => c.Int());
            AlterColumn("dbo.Category", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Category", "UpdatedBy", c => c.Int());
            AlterColumn("dbo.Category", "DeletedBy", c => c.Int());
            AlterColumn("dbo.Expense", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Expense", "UpdatedBy", c => c.Int());
            AlterColumn("dbo.Expense", "DeletedBy", c => c.Int());
            AlterColumn("dbo.User", "Email", c => c.String());
            AlterColumn("dbo.User", "PhoneNumber", c => c.String());
            AlterColumn("dbo.User", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.User", "UpdatedBy", c => c.Int());
            AlterColumn("dbo.User", "DeletedBy", c => c.Int());
            AlterColumn("dbo.Family", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Family", "UpdatedBy", c => c.Int());
            AlterColumn("dbo.Family", "DeletedBy", c => c.Int());
            AlterColumn("dbo.Income", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Income", "UpdatedBy", c => c.Int());
            AlterColumn("dbo.Income", "DeletedBy", c => c.Int());
            AlterColumn("dbo.Saving", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Saving", "UpdatedBy", c => c.Int());
            AlterColumn("dbo.Saving", "DeletedBy", c => c.Int());
            AlterColumn("dbo.Transaction", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Transaction", "UpdatedBy", c => c.Int());
            AlterColumn("dbo.Transaction", "DeletedBy", c => c.Int());
        }

        public override void Down()
        {
            AlterColumn("dbo.Transaction", "DeletedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Transaction", "UpdatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Transaction", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Saving", "DeletedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Saving", "UpdatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Saving", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Income", "DeletedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Income", "UpdatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Income", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Family", "DeletedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Family", "UpdatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Family", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.User", "DeletedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.User", "UpdatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.User", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.User", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Expense", "DeletedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Expense", "UpdatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Expense", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Category", "DeletedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Category", "UpdatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Category", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Budget", "DeletedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Budget", "UpdatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Budget", "CreatedDate", c => c.DateTime());
            DropColumn("dbo.User", "Address");
        }
    }
}
