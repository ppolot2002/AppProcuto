using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Models;
namespace Datos.Repositories.Contracts
{
    //public interface IGenericRepository<TModel> where TModel : class
    public interface IGenericRepository
    {
        
        Producto GetByID(int ProductId);
        void InsertProducto(Producto product);
        bool DeleteProducto(int ProductId);
    }
}
