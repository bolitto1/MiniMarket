using MiniMarket.Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMarket.DAL.Contratos
{
	public interface ICategoriasRepositorio: IRepositorioGenerico <Categorias>
	{
		Task<Categorias> GetCategoriasID(int id);
		Task<List<Categorias>> GetCategoriasListado();
		Task<int> GrabarCategoria(Categorias entity);
	}
}
