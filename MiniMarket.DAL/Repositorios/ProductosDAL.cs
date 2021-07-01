using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniMarket.DAL.Contratos;
using MiniMarket.Entidades.Models;


namespace MiniMarket.DAL.Repositorios
{
	public class ProductosDAL : IProductosRepositorio
	{
		private readonly string _cadenaConexion;

		MiniMarketContext db = new MiniMarketContext();
		public ProductosDAL(string Cadenaconexion)
		{
			_cadenaConexion = Cadenaconexion;
		} 

		public async Task<Productos> GetProductosID(long id)
		{
			//Productos objpro= new Productos ();
			//objpro =  await db.productos.Where(x => x.id == id).FirstOrDefaultAsync();
			//return objpro;
			Productos objpro = new Productos();
			SqlConnection con = new SqlConnection(_cadenaConexion);
			SqlCommand cmd = new SqlCommand("SP_select_product_id", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@id", id);
			try
			{
				await con.OpenAsync();
				SqlDataReader sdr = await cmd.ExecuteReaderAsync();
				while (sdr.Read())
				{
					objpro.id = Convert.ToInt64(sdr["id"]);
					objpro.descripcion = sdr["descripcion"].ToString();
					objpro.categoriaID = Convert.ToInt32(sdr["categoriaID"]);
					objpro.proveedorID = Convert.ToInt32(sdr["proveedorID"]);
					objpro.marcaID = Convert.ToInt32(sdr["marcaID"]);
					objpro.medidas = sdr["medidas"].ToString();
					objpro.cantidad = Convert.ToInt32(sdr["cantidad"]);
					objpro.precio_u = Convert.ToDecimal(sdr["precio_u"]);
				}
			}
			catch (Exception )
			{
				con.Close();
			}
			//			listobjpro = await db.productos.ToListAsync();
			return objpro;
		}

		public async Task<List<Productos>> GetProductosListado()
		{
			List<Productos> listobjpro = new List<Productos>();
			SqlConnection con = new SqlConnection(_cadenaConexion);
			SqlCommand cmd = new SqlCommand("sp_productos_listado", con);
			cmd.CommandType = CommandType.StoredProcedure;
			try
			{
				await con.OpenAsync();
				SqlDataReader sdr = await cmd.ExecuteReaderAsync();
				while (sdr.Read())
				{
					listobjpro.Add(
						new Productos
						{
							id = Convert.ToInt64(sdr["id"]),
							descripcion = sdr["descripcion"].ToString(),
							categoriaID = Convert.ToInt32(sdr["categoriaID"]),
							proveedorID = Convert.ToInt32(sdr["proveedorID"]),
							marcaID = Convert.ToInt32(sdr["marcaID"]),
							medidas = sdr["medidas"].ToString(),
							cantidad = Convert.ToInt32(sdr["cantidad"]),
							precio_u = Convert.ToDecimal(sdr["precio_u"])
						}
					);
				}
			}
			catch (Exception )
			{
				con.Close();
			}
			//			listobjpro = await db.productos.ToListAsync();
			return listobjpro;
		}

		public async Task<bool> Eliminar(long id)
		{
			db = new MiniMarketContext();
			Productos pro = new Productos();
			try {
				pro = await db.productos.FirstOrDefaultAsync (c => c.id == id);
				db.Remove(pro);
				return  true;
			}
			catch (Exception )
			{
				return false;
			}
		}



		public async Task<bool> Grabar(Productos entity)
		{
			try {
				db.productos.Add(entity);
				await db.SaveChangesAsync();
				return true;
			}
			catch (Exception ) {
				return false;
			}
		}

		public async Task<bool> Actualizar(Productos entity)
		{
			db = new MiniMarketContext();
			try
			{
				db.Entry(entity).State = EntityState.Modified;
				await db.SaveChangesAsync(); 
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public Task<long> GrabarProducto(Productos entity)
		{
			throw new NotImplementedException();
		}
	}
}
