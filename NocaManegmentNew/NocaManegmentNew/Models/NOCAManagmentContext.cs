using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NocaManegmentNew.Models
{
    public partial class NOCAManagmentContext : DbContext
    {
        public NOCAManagmentContext()
        {
        }

        public NOCAManagmentContext(DbContextOptions<NOCAManagmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Baskets> Baskets { get; set; }
        public virtual DbSet<Cabinets> Cabinets { get; set; }
        public virtual DbSet<OperationLog> OperationLog { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<SaleProducts> SaleProducts { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<Shelfes> Shelfes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["NOCAManagment"].ConnectionString);

            //            if (!optionsBuilder.IsConfigured)
            //            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //                optionsBuilder.UseSqlServer("Data Source=DESKTOP-DHBCUB8;Initial Catalog=NOCAManagment; Trusted_Connection=True;");
            //            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Baskets>(entity =>
            {
                entity.ToTable("Baskets", "book");

                entity.HasIndex(e => e.Num)
                    .HasName("UQ__Baskets__DF908D648A34759E")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Num).HasColumnName("num");
            });

            modelBuilder.Entity<Cabinets>(entity =>
            {
                entity.ToTable("Cabinets", "book");

                entity.HasIndex(e => e.Num)
                    .HasName("UQ__Cabinets__DF908D64F18525BD")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Num).HasColumnName("num");
            });

            modelBuilder.Entity<OperationLog>(entity =>
            {
                entity.ToTable("OperationLog", "doc");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.JsonData)
                    .IsRequired()
                    .HasColumnName("json_data");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.ToTable("Products", "book");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(50);

                entity.Property(e => e.IsWeight).HasColumnName("is_weight");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(11, 2)");

                entity.Property(e => e.Weight).HasColumnName("weight");
            });

            modelBuilder.Entity<SaleProducts>(entity =>
            {
                entity.ToTable("SaleProducts", "doc");

                entity.HasIndex(e => e.ProductId)
                    .HasName("IND__SaleProducts_product_id");

                entity.HasIndex(e => e.SaleId)
                    .HasName("IND__SaleProducts_sale_id");

                entity.HasIndex(e => e.ShelfId)
                    .HasName("IND__SaleProducts_shelf_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(11, 2)");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.SaleId).HasColumnName("sale_id");

                entity.Property(e => e.ShelfId).HasColumnName("shelf_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SaleProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SaleProdu__produ__59063A47");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.SaleProducts)
                    .HasForeignKey(d => d.SaleId)
                    .HasConstraintName("FK__SaleProdu__sale___5812160E");

                entity.HasOne(d => d.Shelf)
                    .WithMany(p => p.SaleProducts)
                    .HasForeignKey(d => d.ShelfId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SaleProdu__shelf__59FA5E80");
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.ToTable("Sales", "doc");

                entity.HasIndex(e => e.BasketId)
                    .HasName("IND__Sales_basket_id");

                entity.HasIndex(e => e.LogId)
                    .HasName("IND__Sales_log_id");

                entity.HasIndex(e => e.Tdate)
                    .HasName("IND__Sales_tdate");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BasketId).HasColumnName("basket_id");

                entity.Property(e => e.Coeff).HasColumnName("coeff");

                entity.Property(e => e.LogId).HasColumnName("log_id");

                entity.Property(e => e.Tdate)
                    .HasColumnName("tdate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Basket)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.BasketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sales__basket_id__5441852A");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.LogId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Sales__log_id__534D60F1");
            });

            modelBuilder.Entity<Shelfes>(entity =>
            {
                entity.ToTable("Shelfes", "book");

                entity.HasIndex(e => e.Num)
                    .HasName("UQ__Shelfes__DF908D64675891B1")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CabinetId).HasColumnName("cabinet_id");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Cabinet)
                    .WithMany(p => p.Shelfes)
                    .HasForeignKey(d => d.CabinetId)
                    .HasConstraintName("FK__Shelfes__cabinet__49C3F6B7");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Shelfes)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Shelfes__product__4AB81AF0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
