namespace EFM.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EFMDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Budget",
                c => new
                    {
                        BudgetID = c.Int(nullable: false, identity: true),
                        FamilyID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BudgetID)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Family", t => t.FamilyID, cascadeDelete: true)
                .Index(t => t.FamilyID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Expense",
                c => new
                    {
                        ExpenseID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentMethod = c.String(nullable: false),
                        ExpenseDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExpenseID)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                        FullName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.FamilyMembers",
                c => new
                    {
                        FamilyMemberID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        FamilyID = c.Int(nullable: false),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FamilyMemberID)
                .ForeignKey("dbo.Family", t => t.FamilyID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.FamilyID);
            
            CreateTable(
                "dbo.Family",
                c => new
                    {
                        FamilyID = c.Int(nullable: false, identity: true),
                        FamilyName = c.String(nullable: false, maxLength: 100),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FamilyID);
            
            CreateTable(
                "dbo.Income",
                c => new
                    {
                        IncomeID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentMethod = c.String(nullable: false),
                        IncomeDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IncomeID)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Saving",
                c => new
                    {
                        SavingID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TargetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SavingID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Type = c.String(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransactionDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "UserID", "dbo.User");
            DropForeignKey("dbo.Saving", "UserID", "dbo.User");
            DropForeignKey("dbo.Income", "UserID", "dbo.User");
            DropForeignKey("dbo.Income", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.FamilyMembers", "UserID", "dbo.User");
            DropForeignKey("dbo.FamilyMembers", "FamilyID", "dbo.Family");
            DropForeignKey("dbo.Budget", "FamilyID", "dbo.Family");
            DropForeignKey("dbo.Expense", "UserID", "dbo.User");
            DropForeignKey("dbo.Expense", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.Budget", "CategoryID", "dbo.Category");
            DropIndex("dbo.Transaction", new[] { "UserID" });
            DropIndex("dbo.Saving", new[] { "UserID" });
            DropIndex("dbo.Income", new[] { "CategoryID" });
            DropIndex("dbo.Income", new[] { "UserID" });
            DropIndex("dbo.FamilyMembers", new[] { "FamilyID" });
            DropIndex("dbo.FamilyMembers", new[] { "UserID" });
            DropIndex("dbo.Expense", new[] { "CategoryID" });
            DropIndex("dbo.Expense", new[] { "UserID" });
            DropIndex("dbo.Budget", new[] { "CategoryID" });
            DropIndex("dbo.Budget", new[] { "FamilyID" });
            DropTable("dbo.Transaction");
            DropTable("dbo.Saving");
            DropTable("dbo.Income");
            DropTable("dbo.Family");
            DropTable("dbo.FamilyMembers");
            DropTable("dbo.User");
            DropTable("dbo.Expense");
            DropTable("dbo.Category");
            DropTable("dbo.Budget");
        }
    }
}
