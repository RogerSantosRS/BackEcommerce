using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackEcommerce.Models
{
    public partial class bdecomerceContext : DbContext
    {
        public bdecomerceContext()
        {
        }

        public bdecomerceContext(DbContextOptions<bdecomerceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<DetallePedido> DetallePedidos { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Perfil> Perfils { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //TODO falta convertirla en una variable de entorno
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-BDKBKHE\\SQLEXPRESS; Database=bdecomerce; User=sa; Password=masterkey;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("clientes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Estatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estatus")
                    .IsFixedLength();

                entity.Property(e => e.FechaCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreate");

                entity.Property(e => e.FechaDelete)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaDelete");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.ToTable("detallePedido");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdPedido).HasColumnName("idPedido");

                entity.Property(e => e.Importe)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("importe");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.Producto)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("producto");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detallePe__idPed__4222D4EF");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("pedidos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaCompra)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCompra");

                entity.Property(e => e.FechaCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreate");

                entity.Property(e => e.FechaDelete)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaDelete");

                entity.Property(e => e.Folio)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("folio");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.Iva)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("iva");

                entity.Property(e => e.Subtotal)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("subtotal");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("total");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pedidos__idClien__3F466844");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.ToTable("perfil");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Estatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estatus")
                    .IsFixedLength();

                entity.Property(e => e.FechaCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreate");

                entity.Property(e => e.FechaDelete)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaDelete");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("productos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.Estatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estatus")
                    .IsFixedLength();

                entity.Property(e => e.FechaCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreate");

                entity.Property(e => e.FechaDelete)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaDelete");

                entity.Property(e => e.Imagen)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("imagen");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.Stock)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("stock");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contrasenia");

                entity.Property(e => e.Estatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estatus")
                    .IsFixedLength();

                entity.Property(e => e.FechaCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreate");

                entity.Property(e => e.FechaDelete)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaDelete");

                entity.Property(e => e.IdPerfil).HasColumnName("idPerfil");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("usuario");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuario__idPerfi__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
