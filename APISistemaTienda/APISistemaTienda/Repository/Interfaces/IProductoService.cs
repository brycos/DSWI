using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using APISistemaTienda.Dtos;

namespace APISistemaTienda.Repository.Interfaces
{
    public interface IProductoService
    {
        Task<List<ProductoDTO>> Lista();
        Task<ProductoDTO> Crear(ProductoDTO modelo);
        Task<bool> Editar(ProductoDTO modelo);
        Task<bool> Eliminar(int id);


    }
}
