using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniMarket.Entidades.Models;

namespace MiniMarket.DAL.Contratos
{
	public interface IMarcasRepositorio: IRepositorioGenerico <Marcas >
	{
		Task<Marcas> GetMarcasID(int id);
		Task<List<Marcas>> GetMarcasListado();
		Task<int> GrabarMarcas(Marcas entity);
	}
}
