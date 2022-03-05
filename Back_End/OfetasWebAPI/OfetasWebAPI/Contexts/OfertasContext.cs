using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OfetasWebAPI.Domains;

#nullable disable

namespace OfetasWebAPI.Contexts
{
    public partial class OfertasContext : DbContext
    {
        public OfertasContext()
        {
        }

        public OfertasContext(DbContextOptions<OfertasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Consumidor> Consumidors { get; set; }
        public virtual DbSet<Fornecedor> Fornecedors { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public Task<ActionResult<IEnumerable<Consumidor>>> Consumidor { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
<<<<<<< HEAD
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer//("Data Source=NOTE0111E6\\SQLEXPRESS; initial catalog=Ofertas; user Id=sa; pwd=Senai@132;");
                    ("Data Source=DESKTOP-KINHA\\SQLEXPRESS; initial catalog=Ofertas; user Id=sa; pwd=151917;");
=======
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=NOTE0113B3\\SQLEXPRESS; initial catalog=Ofertas; user Id=sa; pwd=Senai@132;");
>>>>>>> 99282353ec064a31c882543966f402e912d6eaa1
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__8A3D240CC0ED2748");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.NomeCategoria)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeCategoria");
            });

            modelBuilder.Entity<Consumidor>(entity =>
            {
                entity.HasKey(e => e.IdConsumidor)
                    .HasName("PK__Consumid__4F69B1F66231AB02");

                entity.ToTable("Consumidor");

                entity.Property(e => e.IdConsumidor).HasColumnName("idConsumidor");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("cpf");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Tefelone)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("tefelone");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Consumidors)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Consumido__idUsu__66603565");
            });

            modelBuilder.Entity<Fornecedor>(entity =>
            {
                entity.HasKey(e => e.IdFornecedor)
                    .HasName("PK__Forneced__CBE1227C52262F2F");

                entity.ToTable("Fornecedor");

                entity.Property(e => e.IdFornecedor).HasColumnName("idFornecedor");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("cnpj");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("telefone");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Fornecedors)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Fornecedo__idUsu__6383C8BA");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PK__Produto__5EEDF7C31EA9A231");

                entity.ToTable("Produto");

                entity.Property(e => e.IdProduto).HasColumnName("idProduto");

                entity.Property(e => e.DataValidade)
                    .HasColumnType("date")
                    .HasColumnName("dataValidade");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.IdFornecedor).HasColumnName("idFornecedor");

                entity.Property(e => e.ImagemProduto)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("imagemProduto");

                entity.Property(e => e.NomeProduto)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeProduto");

                entity.Property(e => e.Preco).HasColumnName("preco");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Produto__idCateg__6A30C649");

                entity.HasOne(d => d.IdFornecedorNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdFornecedor)
                    .HasConstraintName("FK__Produto__idForne__693CA210");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.IdReserva)
                    .HasName("PK__Reservas__94D104C8737C30CA");

                entity.Property(e => e.IdReserva).HasColumnName("idReserva");

                entity.Property(e => e.IdConsumidor).HasColumnName("idConsumidor");

                entity.Property(e => e.IdProduto).HasColumnName("idProduto");

                entity.HasOne(d => d.IdConsumidorNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdConsumidor)
                    .HasConstraintName("FK__Reservas__idCons__6D0D32F4");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("FK__Reservas__idProd__6E01572D");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__03006BFF52B89804");

                entity.ToTable("TipoUsuario");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A6EB90A09E");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__idTipoU__60A75C0F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
