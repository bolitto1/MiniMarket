using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMarket.Entidades.Models
{
	public class Productos
	{

		public long id { get; set; }
		public string descripcion { get; set; }
		public Nullable<int> categoriaID { get; set; }
		public Nullable<int> proveedorID { get; set; }
		public Nullable<int> marcaID { get; set; }
		public string medidas { get; set; }
		public Nullable<int> cantidad { get; set; }
		public Nullable<decimal> precio_u { get; set; }

		public virtual Categorias categorias { get; set; }
		public virtual Marcas marcas { get; set; }
		public virtual Proveedores proveedores { get; set; }

	}
}
