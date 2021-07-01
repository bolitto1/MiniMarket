using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMarket.DAL.Contratos
{
	public interface IRepositorioGenerico<T> where T:class
	{
		 Task<bool> Grabar(T entity);
	//	Task<bool> Eliminar(int id);
	}
}
