using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniMarket.Entidades.Models;


namespace MiniMarket.DAL.Models
{
	public class MiniMarketContext
	{
    public virtual DbSet<Categorias> categorias { get; set; }
    public virtual DbSet<Marcas> marcas { get; set; }
    public virtual DbSet<Productos> productos { get; set; }
    public virtual DbSet<Proveedores> proveedores { get; set; }
  }
}
