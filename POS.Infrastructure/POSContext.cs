using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;

namespace POS.Infrastructure;

public partial class POSContext : DbContext
{
    public POSContext(DbContextOptions<POSContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Config> Configs { get; set; }

    public virtual DbSet<CurrentStock> CurrentStocks { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DailyGrossProfit> DailyGrossProfits { get; set; }

    public virtual DbSet<Hpp> Hpps { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Previllage> Previllages { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductPrice> ProductPrices { get; set; }

    public virtual DbSet<ProductStock> ProductStocks { get; set; }

    public virtual DbSet<ProductStockHistory> ProductStockHistories { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }

    public virtual DbSet<Reconcile> Reconciles { get; set; }

    public virtual DbSet<ReconcileDetail> ReconcileDetails { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleDetail> SaleDetails { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<VUserPrevillage> VUserPrevillages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__AuditLog__5E5499A875EA9C88");

            entity.Property(e => e.LogTimestamp).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_customer");
        });

        modelBuilder.Entity<DailyGrossProfit>(entity =>
        {
            entity.HasKey(e => new { e.TransDate, e.CatalogId }).HasName("PK_dailygrossprofit");
        });

        modelBuilder.Entity<Hpp>(entity =>
        {
            entity.HasKey(e => new { e.TransDate, e.CatalogId }).HasName("PK_hpp");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_menu");
        });

        modelBuilder.Entity<Previllage>(entity =>
        {
            entity.HasKey(e => new { e.MenuId, e.RoleId }).HasName("PK_previllage");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_catalog");
        });

        modelBuilder.Entity<ProductPrice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CatalogPrice");
        });

        modelBuilder.Entity<ProductStockHistory>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_purchase");
        });

        modelBuilder.Entity<PurchaseDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_purchasedetail");
        });

        modelBuilder.Entity<Reconcile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_reconcile");
        });

        modelBuilder.Entity<ReconcileDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_reconciledetail");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_role");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK_sale");

            entity.Property(e => e.Counter).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SaleDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_saledetail");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK_supplier");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_userrole");
        });

        modelBuilder.Entity<VUserPrevillage>(entity =>
        {
            entity.ToView("v_UserPrevillage");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
