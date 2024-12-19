using api.Models;
using Microsoft.EntityFrameworkCore;
using System;

// This uses Entity framework core to handle DB interactions. 
// It is a Object Relational Mapper, and simplifies the process. 

namespace api.Data
{
    /*
     *  This Class provides access to the entities in the database
     */
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        // All below get or set the database for the name, from the Models folder. 
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("Accounts");
            modelBuilder.Entity<Transaction>().ToTable("Transactions");
            modelBuilder.Entity<Invoice>().ToTable("Invoices");
            modelBuilder.Entity<Payment>().ToTable("Payments");
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Vendor>().ToTable("Vendors");
            modelBuilder.Entity<Item>().ToTable("Items");
            modelBuilder.Entity<PurchaseOrder>().ToTable("PurchaseOrders");
            modelBuilder.Entity<SalesOrder>().ToTable("SalesOrders");
        }
    }
}