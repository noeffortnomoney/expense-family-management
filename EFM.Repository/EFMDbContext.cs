using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using EFM.Model.Model;

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

        public static EFMDbContext Create()
        {
            return new EFMDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {

        }
    }
}