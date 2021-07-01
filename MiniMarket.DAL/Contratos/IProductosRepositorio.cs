using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniMarket.Entidades.Models;

namespace MiniMarket.DAL.Contratos
{
	public interface IProductosRepositorio: IRepositorioGenerico <Productos>
	{
		Task<Productos> GetProductosID(long id);
		Task<List<Productos>> GetProductosListado();
		Task<bool> Grabar(Productos entity);
		Task<bool> Actualizar(Productos entity);

		Task<bool> Eliminar(long id);


	}
}
