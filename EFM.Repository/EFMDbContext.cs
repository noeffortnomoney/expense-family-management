using EFM.Model.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Reflection.Emit;

namespace EFM.Repository
{
    public class EFMDbContext : DbContext
    {
        public EFMDbContext() : base("EFMConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<User> Users { set; get; }
        public DbSet<Family> Families { set; get; }
        public DbSet<FamilyMember> FamilyMembers { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Expense> Expenses { set; get; }
        public DbSet<Income> Incomes { set; get; }
        public DbSet<Saving> Savings { set; get; }
        public DbSet<Transaction> Transactions { set; get; }
        public DbSet<Budget> Budgets { set; get; }

        /*public DbSet<ApplicationRole> ApplicationRoles { set; get; }
        public DbSet<ApplicationUser> ApplicationUsers { set; get; }*/

        public static EFMDbContext Create()
        {
            return new EFMDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*base.OnModelCreating(modelBuilder);

            // Tùy chỉnh tên bảng nếu muốn
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");*/
        }
    }
}