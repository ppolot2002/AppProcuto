using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Models;

namespace Negocio.Services.Contracts
{
    public interface IProductoService
    {

        Producto GetByID(int ProductId);
        void InsertProduct(Producto Product);
        bool DeleteProduct(int ProductId);
        
    }
}
