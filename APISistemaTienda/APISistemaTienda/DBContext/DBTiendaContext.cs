using System;
using System.Collections.Generic;
using APISistemaTienda.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APISistemaTienda.DBContext
{
    public partial class DBTiendaContext : DbContext
    {
        public DBTiendaContext()
        {
        }

        public DBTiendaContext(DbContextOptions<DBTiendaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<DetalleVenta> DetalleVenta { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<NumeroDocumento> NumeroDocumentos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Venta> Venta { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCat)
                    .HasName("PK__Categori__398E40457CED6C1B");

                entity.Property(e => e.IdCat).HasColumnName("idCat");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCli)
                    .HasName("PK__Cliente__398F6705922D5A1B");

                entity.ToTable("Cliente");

                entity.Property(e => e.IdCli).HasColumnName("idCli");

                entity.Property(e => e.ApeCli)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("apeCli");

                entity.Property(e => e.Correo)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.DirCli)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("dirCli");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NomCli)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomCli");

                entity.Property(e => e.TelCli)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("telCli");
            });

            modelBuilder.Entity<DetalleVenta>(entity =>
            {
                entity.HasKey(e => e.IdDetalleVenta)
                    .HasName("PK__DetalleV__BFE2843F224891A0");

                entity.Property(e => e.IdDetalleVenta).HasColumnName("idDetalleVenta");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdProd).HasColumnName("idProd");

                entity.Property(e => e.IdVenta).HasColumnName("idVenta");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("total");

                entity.HasOne(d => d.IdProdNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.IdProd)
                    .HasConstraintName("FK__DetalleVe__idPro__5070F446");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.IdVenta)
                    .HasConstraintName("FK__DetalleVe__idVen__4F7CD00D");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmp)
                    .HasName("PK__Empleado__3F174B8BD83633BB");

                entity.ToTable("Empleado");

                entity.Property(e => e.IdEmp).HasColumnName("idEmp");

                entity.Property(e => e.ApeEmp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("apeEmp");

                entity.Property(e => e.Correo)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.DirEmp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("dirEmp");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NomEmp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomEmp");

                entity.Property(e => e.TelEmp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("telEmp");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.IdMenu)
                    .HasName("PK__Menu__C26AF48325C21359");

                entity.ToTable("Menu");

                entity.Property(e => e.IdMenu).HasColumnName("idMenu");

                entity.Property(e => e.Icono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("icono");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Url)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<NumeroDocumento>(entity =>
            {
                entity.HasKey(e => e.IdNumeroDocumento)
                    .HasName("PK__NumeroDo__471E421A2B4C6CCA");

                entity.ToTable("NumeroDocumento");

                entity.Property(e => e.IdNumeroDocumento).HasColumnName("idNumeroDocumento");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UltimoNumero).HasColumnName("ultimo_Numero");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProd)
                    .HasName("PK__Producto__B41BB0CA41FF0018");

                entity.ToTable("Producto");

                entity.Property(e => e.IdProd).HasColumnName("idProd");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCat).HasColumnName("idCat");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.HasOne(d => d.IdCatNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCat)
                    .HasConstraintName("FK__Producto__idCat__44FF419A");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.IdVenta)
                    .HasName("PK__Venta__077D5614E52F844B");

                entity.Property(e => e.IdVenta).HasColumnName("idVenta");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("numeroDocumento");

                entity.Property(e => e.Pago)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pago");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("total");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
