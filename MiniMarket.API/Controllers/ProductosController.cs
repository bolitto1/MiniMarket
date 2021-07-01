using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniMarket.Entidades.Models;
using MiniMarket.DAL.Contratos;
using MiniMarket.DAL.Repositorios;

namespace MiniMarket.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductosController : ControllerBase
	{
		private IProductosRepositorio _productosRepositorio;
		public ProductosController(IProductosRepositorio productosRepositorio)
		{
			this._productosRepositorio = productosRepositorio;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<List<Productos>>> Get()
		{
			try
			{
				List<Productos> prods = await _productosRepositorio.GetProductosListado();
				return prods;
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		// GET: api/Producto/5
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<Productos>> Get(long  id)
		{
			try
			{
				Productos productoID = await _productosRepositorio.GetProductosID(id);
				return productoID;
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}


		// POST: api/Producto
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<bool> Post(Productos producto)
		{
			try
			{
				bool result = await _productosRepositorio.Grabar(producto);

				return result;

			}
			catch (Exception)
			{
				return false;
			}
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[HttpPut("{id:log}")]
		public async Task<ActionResult<Productos>> Actualizar(long id,  Productos productos)
		{
			bool result;
			try
			{
				if (id != productos.id)
					return BadRequest("Producto ID mismatch");
				Productos productoID = await _productosRepositorio.GetProductosID(id);

				if (productoID == null)
					return NotFound($" Producto  with Id = {id} not encontrado");

				result = await _productosRepositorio.Actualizar(productoID);
				return productoID;
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
						"Error updating data");
			}
		}

		// DELETE: api/Producto/5
		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Delete(long id)
		{
			try
			{
				bool resultado = await _productosRepositorio.Eliminar(id);
				if (!resultado)
				{
					return BadRequest();
				}
				return NoContent();
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

	}
}
