using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SupermarketApi.Models.DB;

#nullable disable

namespace SupermarketApi.Models
{
    public partial class SuperMarketTecocContext : DbContext
    {
        public SuperMarketTecocContext()
        {
        }

        public SuperMarketTecocContext(DbContextOptions<SuperMarketTecocContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BranchOffice> BranchOffices { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<JobTitle> JobTitles { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductProvider> ProductProviders { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<TypeProduct> TypeProducts { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<BranchOffice>(entity =>
            {
                entity.ToTable("Branch_Office");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Branch_Name");

                entity.Property(e => e.IdUser).HasColumnName("Id_user");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.BranchOffices)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Branch_Office_User");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CellPhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Cell_Phone_Number");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.CellPhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Cell_Phone_Number");

                entity.Property(e => e.HiringDate)
                    .HasColumnType("date")
                    .HasColumnName("Hiring_Date");

                entity.Property(e => e.IdJobTitle).HasColumnName("Id_Job_Title");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdJobTitleNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdJobTitle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Job_Title");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.Property(e => e.DepartureDate)
                    .HasColumnType("date")
                    .HasColumnName("Departure_Date");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.EntryDate)
                    .HasColumnType("date")
                    .HasColumnName("Entry_Date");

                entity.Property(e => e.IdBranchOffice).HasColumnName("Id_Branch_Office");

                entity.Property(e => e.Quantify)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdBranchOfficeNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.IdBranchOffice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_Branch_Office");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.Property(e => e.IdClient).HasColumnName("Id_Client");

                entity.Property(e => e.IdEmployee).HasColumnName("Id_Employee");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnType("date")
                    .HasColumnName("Invoice_Date");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_Client");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_Employee");
            });

            modelBuilder.Entity<JobTitle>(entity =>
            {
                entity.ToTable("Job_Title");

                entity.Property(e => e.JobDescrption)
                    .IsRequired()
                    .HasColumnName("Job_Descrption");

                entity.Property(e => e.WorkPosition)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Work_Position");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.IdBranchOffice).HasColumnName("Id_Branch_Office");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.ProductElaborationDate)
                     .HasColumnType("date")
                     .HasColumnName("Product_Elaboration_Date");

                entity.Property(e => e.ProductExpirationDate)
                    .HasColumnType("date")
                    .HasColumnName("Product_Expiration_Date");

                entity.Property(e => e.Stock)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdBranchOfficeNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdBranchOffice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Branch_Office");
            });

            modelBuilder.Entity<ProductProvider>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Product_Provider");

                entity.Property(e => e.IdProduct).HasColumnName("Id_Product");

                entity.Property(e => e.IdProvider).HasColumnName("Id_Provider");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Provider_Product");

                entity.HasOne(d => d.IdProduct1)
                    .WithMany()
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Provider_Provider");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.ToTable("Provider");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TypeProduct>(entity =>
            {
                entity.ToTable("Type_Product");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IdProduct).HasColumnName("Id_Product");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.TypeProducts)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Type_Product_Product");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.IdEmployee).HasColumnName("Id_Employee");

                entity.Property(e => e.IdInventory).HasColumnName("Id_Inventory");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Employee");

                entity.HasOne(d => d.IdInventoryNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdInventory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Inventory");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users");

                OnModelCreatingPartial(modelBuilder);

                entity.Property(e => e.surnames)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.names)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.email)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.usename)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.passwor)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
