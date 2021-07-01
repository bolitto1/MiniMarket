using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Runtime;
using MiniMarket.DAL.Contratos;
using MiniMarket.Entidades.Models;
using MiniMarket.DAL.Repositorios;


namespace MiniMarket.API.Context
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options): base (options)
		{

		}


		public virtual DbSet<Categorias> categorias { get; set; }
		public virtual DbSet<Marcas> marcas { get; set; }
		public virtual DbSet<Productos> productos { get; set; }
	//	public virtual DbSet<Productos_Historico> Productos_Historico { get; set; }
		public virtual DbSet<Proveedores> proveedores { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//https://docs.microsoft.com/es-es/ef/core/modeling/keyless-entity-types?tabs=data-annotations

			modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

			modelBuilder.Entity<Productos>(entity =>
			{
				entity.ToTable("Productos");
				entity.HasKey(e => e.id);
				//se tuvo que instalar Microsoft.EntityFrameworkCore.Relational; para que funcione HasColumnName("id");
				entity.Property(e => e.id).HasColumnName("id");
				entity.Property(e => e.descripcion )
						.HasMaxLength(250)
						.IsUnicode(false)
						.HasColumnName("descripcion");
				entity.Property(e => e.descripcion)
						.HasMaxLength(250)
						.IsUnicode(false)
						.HasColumnName("medidas");
				entity.Property(e => e.cantidad )
						.HasColumnName("cantidad");
				entity.Property(e => e.cantidad)
					.HasColumnName("precio_u");
				entity.Property(e => e.categoriaID)
					.HasColumnName("categoriaID");
				entity.Property(e => e.proveedorID)
					.HasColumnName("proveedorID");
				entity.Property(e => e.marcaID)
					.HasColumnName("marcaID");
			});

			// OnModelCreatingPartial(modelBuilder);
		}

	}
}
