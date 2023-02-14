using Datos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio.Services;
using Negocio.Services.Contracts;
using Newtonsoft.Json.Linq;
using Swashbuckle.AspNetCore.Annotations;
using System;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProducto.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoRepository)
        {
            _productoService = productoRepository;
        }
       

        // GET api/<ProductoController>/5
        [HttpGet("{ProductId}")]
        public Producto Get(int ProductId)
        {
            return _productoService.GetByID(ProductId);
        }
        

        // PUT api/<ProductoController>/5        
        [HttpPost]
        [Route("Put")]
        public ActionResult Put([FromBody] Producto value)
        {
            try
            {
                
                
                _productoService.InsertProduct(value);
                
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }



        // DELETE api/<ProductoController>/5
        [HttpDelete("{ProductId}")]        
        public ActionResult Delete(int ProductId)
        {
            bool oProducto = _productoService.DeleteProduct(ProductId);

            if (oProducto == false)
            {
                return BadRequest("Producto no encontrado");

            }

            try
            {   

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }

        }
    }
}
