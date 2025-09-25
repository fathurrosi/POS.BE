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

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DailyGrossProfit> DailyGrossProfits { get; set; }

    public virtual DbSet<Hpp> Hpps { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Previllage> Previllages { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }

    public virtual DbSet<Reconcile> Reconciles { get; set; }

    public virtual DbSet<ReconcileDetail> ReconcileDetails { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleDetail> SaleDetails { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<VUserPrevillage> VUserPrevillages { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__AuditLog__5E5499A875EA9C88");

            entity.Property(e => e.LogTimestamp).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasOne(d => d.ProfileNavigation).WithMany(p => p.Categories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Category_Profile");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasOne(d => d.ProfileNavigation).WithMany(p => p.Customers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Profile");
        });

        modelBuilder.Entity<DailyGrossProfit>(entity =>
        {
            entity.HasKey(e => new { e.TransDate, e.CatalogId }).HasName("PK_dailygrossprofit");
        });

        modelBuilder.Entity<Hpp>(entity =>
        {
            entity.HasKey(e => new { e.TransDate, e.CatalogId }).HasName("PK_hpp");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Inventor__F5FDE6D37B00FB72");

            entity.Property(e => e.LastUpdated).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.ProductNavigation).WithMany(p => p.Inventories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventory_Product");

            entity.HasOne(d => d.WarehouseNavigation).WithMany(p => p.Inventories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventory_Warehouses");
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
            entity.Property(e => e.BasePrice).HasDefaultValue(0m);
            entity.Property(e => e.MinStock).HasDefaultValue(0);
            entity.Property(e => e.SalesPrice).HasDefaultValue(0m);
            entity.Property(e => e.Stock).HasDefaultValue(0);

            entity.HasOne(d => d.ProfileNavigation).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Profile");
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
            entity.HasOne(d => d.ProfileNavigation).WithMany(p => p.Suppliers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Supplier_Profile");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__55433A4BD175584C");

            entity.Property(e => e.TransactionDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_userrole");
        });

        modelBuilder.Entity<VUserPrevillage>(entity =>
        {
            entity.ToView("v_UserPrevillage");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Warehous__2608AFD933081C7D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
