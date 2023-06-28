using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




using APISistemaTienda.Repository.Interfaces;
using APISistemaTienda.DBContext;
using APISistemaTienda.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace APISistemaTienda.Repository
{
    public class VentaRepository : GenericRepository<Venta> , IVentaRepository
    {

        private readonly DBTiendaContext _dbcontext;

        public VentaRepository(DBTiendaContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Venta> Registrar(Venta modelo)
        {
            Venta ventaGenerada = new Venta();

            using (var trasaction = _dbcontext.Database.BeginTransaction())
            {
                try {

                    foreach (DetalleVenta dv in modelo.DetalleVenta) {
                        
                        Producto producto_encontrado = _dbcontext.Productos.Where(p => p.IdProd == dv.IdProd).First();

                        producto_encontrado.Stock = producto_encontrado.Stock - dv.Cantidad;
                        _dbcontext.Productos.Update(producto_encontrado);
                    }
                    await _dbcontext.SaveChangesAsync();

                    NumeroDocumento correlativo = _dbcontext.NumeroDocumentos.First();

                    correlativo.UltimoNumero = correlativo.UltimoNumero + 1;
                    correlativo.FechaRegistro = DateTime.Now;

                    _dbcontext.NumeroDocumentos.Update(correlativo);
                    await _dbcontext.SaveChangesAsync();

                    int CantidadDigitos = 4;
                    string ceros = string.Concat(Enumerable.Repeat("0", CantidadDigitos));
                    string numeroVenta = ceros + correlativo.UltimoNumero.ToString();
                    //00001
                    numeroVenta = numeroVenta.Substring(numeroVenta.Length - CantidadDigitos, CantidadDigitos);

                    modelo.NumeroDocumento = numeroVenta;

                    await _dbcontext.Venta.AddAsync(modelo);
                    await _dbcontext.SaveChangesAsync();

                    ventaGenerada = modelo;

                    trasaction.Commit();
 
                } catch {
                    
                    trasaction.Rollback();
                    throw;
                }

                return ventaGenerada;
            
            }



        }
    }
}
