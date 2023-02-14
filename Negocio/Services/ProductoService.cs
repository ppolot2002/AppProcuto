using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Models;
using Datos.Repositories.Contracts;
using Negocio.Services.Contracts;


namespace Negocio.Services
{
    public class ProductoService : IProductoService
    {

        private readonly IGenericRepository _repository;
        

        
        public ProductoService (IGenericRepository repository)
        {
            _repository = repository;
        }
        public bool DeleteProduct(int ProductId)
        {
            return _repository.DeleteProducto(ProductId);
        }

        public Producto GetByID(int ProductId)
        {
            return _repository.GetByID(ProductId);
        }

        public void InsertProduct(Producto Product)
        {
            _repository.InsertProducto(Product);
        }

        
    }
}

