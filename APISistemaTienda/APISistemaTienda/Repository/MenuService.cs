using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AutoMapper;
using APISistemaTienda.Repository.Interfaces;
using APISistemaTienda.Dtos;
using APISistemaTienda.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace APISistemaTienda.Repository
{
    public class MenuService : IMenuService
    {
        private readonly IGenericRepository<Menu> _menuRepositorio;
        private readonly IMapper _mapper;

        public MenuService(IGenericRepository<Menu> menuRepositorio, IMapper mapper)
        {
            _menuRepositorio = menuRepositorio;
            _mapper = mapper;
        }

        public async Task<List<MenuDTO>> Lista()
        {
            try
            {
                var listaMenus = await _menuRepositorio.Consultar();
                return _mapper.Map<List<MenuDTO>>(listaMenus.ToList());
            }
            catch {
                throw;
            
            }

        }
    }
}
