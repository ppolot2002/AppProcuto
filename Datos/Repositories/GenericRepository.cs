using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.DataContext;
using Datos.Models;
using Datos.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Datos.Repositories
{
    public class GenericRepository : IGenericRepository
    
    {
        private readonly DbapiContext _dbcontext;

        public GenericRepository(DbapiContext dbcontext)
        {

            _dbcontext = dbcontext;

        }

        public bool DeleteProducto(int ProductId)
        {
            Producto oProducto = _dbcontext.Productos.Find(ProductId);
            
            if (oProducto == null)
            {
                return false;
            }
            else
            {
                var product = _dbcontext.Productos.Remove(oProducto);
                Save();
                return true;
            }
            
        }

        public Producto GetByID(int ProductId)
        {

            Producto final = new Producto();
            final=_dbcontext.Productos.Find(ProductId);
            Calculo cal = new Calculo();
            final.Price = final.Price * (100 - cal.disccount) / 100;

            return final;
            //return _dbcontext.Productos.Find(final);
            
        }

        public void InsertProducto(Producto product)
        {
            _dbcontext.Add(product);
            Save();
        }

        public void Save()
        {
            _dbcontext.SaveChanges();
        }

       
    }
}
