using MiniMarket.Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMarket.DAL.Contratos
{
	public interface IProveedoresRepositorio: IRepositorioGenerico<Proveedores>
	{
		Task<Proveedores> GetProveedoresID(int id);
		Task<List<Proveedores>> GetProveedoresListado();
		Task<int> GrabarProveedor(Proveedores entity);
		
	}
}
