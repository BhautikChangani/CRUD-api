using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using crud_api.Models;

namespace crud_api.DBContext;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Column> Columns { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Customer1> Customer1s { get; set; }

    public virtual DbSet<Department1> Department1s { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Employee1> Employee1s { get; set; }

    public virtual DbSet<Manager1> Manager1s { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Orders1> Orders1s { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Products1> Products1s { get; set; }

    public virtual DbSet<Salesman1> Salesman1s { get; set; }

    public virtual DbSet<Shipper> Shippers { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.0.5;Database=bhautikchangani_db;User Id=bhautik;Password=u9Xzkmzd;Encrypt=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CategoryId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.Picture).HasColumnType("image");
        });

        modelBuilder.Entity<Column>(entity =>
        {
            entity.HasKey(e => e.ColumnId).HasName("PK__columns__E301851FD13CAD09");

            entity.ToTable("columns");

            entity.Property(e => e.ColumnId)
                .ValueGeneratedNever()
                .HasColumnName("column_id");
            entity.Property(e => e.ColumnName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("column_name");
            entity.Property(e => e.ColumnTitle)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("column_title");
            entity.Property(e => e.PageId).HasColumnName("page_id");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.ContactName).HasMaxLength(30);
            entity.Property(e => e.ContactTitle).HasMaxLength(30);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CustomerID");
            entity.Property(e => e.Fax).HasMaxLength(24);
            entity.Property(e => e.Phone).HasMaxLength(24);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Region).HasMaxLength(15);
        });

        modelBuilder.Entity<Customer1>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__customer__CD65CB854DCEF44C");

            entity.ToTable("customer1");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("customer_id");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.CustName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("cust_name");
            entity.Property(e => e.Grade).HasColumnName("grade");
            entity.Property(e => e.SalesmanId).HasColumnName("salesman_id");

            entity.HasOne(d => d.Salesman).WithMany(p => p.Customer1s)
                .HasForeignKey(d => d.SalesmanId)
                .HasConstraintName("FK__customer__salesm__403A8C7D");
        });

        modelBuilder.Entity<Department1>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PK__Departme__DCA65974C232CFAA");

            entity.ToTable("Department1");

            entity.Property(e => e.DeptId)
                .ValueGeneratedNever()
                .HasColumnName("dept_id");
            entity.Property(e => e.DeptName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("dept_name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.EmployeeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.Extension).HasMaxLength(4);
            entity.Property(e => e.FirstName).HasMaxLength(10);
            entity.Property(e => e.HireDate).HasColumnType("datetime");
            entity.Property(e => e.HomePhone).HasMaxLength(24);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.Notes).HasColumnType("ntext");
            entity.Property(e => e.Photo).HasColumnType("image");
            entity.Property(e => e.PhotoPath).HasMaxLength(255);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Region).HasMaxLength(15);
            entity.Property(e => e.Title).HasMaxLength(30);
            entity.Property(e => e.TitleOfCourtesy).HasMaxLength(25);
        });

        modelBuilder.Entity<Employee1>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__employee__1299A861AE2D5709");

            entity.ToTable("employee1");

            entity.Property(e => e.EmpId)
                .ValueGeneratedNever()
                .HasColumnName("emp_id");
            entity.Property(e => e.DeptId).HasColumnName("dept_id");
            entity.Property(e => e.EmpName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("emp_name");
            entity.Property(e => e.MngrId).HasColumnName("mngr_id");
            entity.Property(e => e.Salary)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("salary");

            entity.HasOne(d => d.Dept).WithMany(p => p.Employee1s)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK__employee__dept_i__4AB81AF0");

            entity.HasOne(d => d.Mngr).WithMany(p => p.Employee1s)
                .HasForeignKey(d => d.MngrId)
                .HasConstraintName("FK__employee1__mngr___03F0984C");
        });

        modelBuilder.Entity<Manager1>(entity =>
        {
            entity.HasKey(e => e.MngrId).HasName("PK__Manager1__A22B1BC3D31042F5");

            entity.ToTable("Manager1");

            entity.Property(e => e.MngrId)
                .ValueGeneratedNever()
                .HasColumnName("mngr_id");
            entity.Property(e => e.MngrName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("mngr_name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable(tb => tb.HasTrigger("frightChecker"));

            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CustomerID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Freight)
                .HasDefaultValueSql("((0))")
                .HasColumnType("money");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderId)
                .ValueGeneratedOnAdd()
                .HasColumnName("OrderID");
            entity.Property(e => e.RequiredDate).HasColumnType("datetime");
            entity.Property(e => e.ShipAddress).HasMaxLength(60);
            entity.Property(e => e.ShipCity).HasMaxLength(15);
            entity.Property(e => e.ShipCountry).HasMaxLength(15);
            entity.Property(e => e.ShipName).HasMaxLength(40);
            entity.Property(e => e.ShipPostalCode).HasMaxLength(10);
            entity.Property(e => e.ShipRegion).HasMaxLength(15);
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Order Details");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");
            entity.Property(e => e.UnitPrice).HasColumnType("money");
        });

        modelBuilder.Entity<Orders1>(entity =>
        {
            entity.HasKey(e => e.OrdNo).HasName("PK__orders__DC3869041EC0EC59");

            entity.ToTable("orders1");

            entity.Property(e => e.OrdNo)
                .ValueGeneratedNever()
                .HasColumnName("ord_no");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.OrdDate)
                .HasColumnType("date")
                .HasColumnName("ord_date");
            entity.Property(e => e.PurchAmt)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("purch_amt");
            entity.Property(e => e.SalesmanId).HasColumnName("salesman_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders1s)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__orders__customer__4316F928");

            entity.HasOne(d => d.Salesman).WithMany(p => p.Orders1s)
                .HasForeignKey(d => d.SalesmanId)
                .HasConstraintName("FK__orders__salesman__440B1D61");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ProductId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
            entity.Property(e => e.ReorderLevel).HasDefaultValueSql("((0))");
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.UnitPrice)
                .HasDefaultValueSql("((0))")
                .HasColumnType("money");
            entity.Property(e => e.UnitsInStock).HasDefaultValueSql("((0))");
            entity.Property(e => e.UnitsOnOrder).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<Products1>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6EDB3D89FE6");

            entity.ToTable("Products1");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.QuantityPerUnit)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.UnitPrice).HasColumnType("money");
        });

        modelBuilder.Entity<Salesman1>(entity =>
        {
            entity.HasKey(e => e.SalesmanId).HasName("PK__salesman__A8A8389F14200054");

            entity.ToTable("salesman1");

            entity.Property(e => e.SalesmanId)
                .ValueGeneratedNever()
                .HasColumnName("salesman_id");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Commision)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("commision");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Shipper>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.Phone).HasMaxLength(24);
            entity.Property(e => e.ShipperId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ShipperID");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.ContactName).HasMaxLength(30);
            entity.Property(e => e.ContactTitle).HasMaxLength(30);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.Fax).HasMaxLength(24);
            entity.Property(e => e.HomePage).HasColumnType("ntext");
            entity.Property(e => e.Phone).HasMaxLength(24);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Region).HasMaxLength(15);
            entity.Property(e => e.SupplierId)
                .ValueGeneratedOnAdd()
                .HasColumnName("SupplierID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
