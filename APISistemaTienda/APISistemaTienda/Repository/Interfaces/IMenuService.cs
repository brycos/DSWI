using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using APISistemaTienda.Dtos;

namespace APISistemaTienda.Repository.Interfaces
{
    public interface IMenuService
    {
        Task<List<MenuDTO>> Lista();
    }
}
