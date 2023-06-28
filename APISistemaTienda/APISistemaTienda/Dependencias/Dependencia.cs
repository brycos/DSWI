using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using APISistemaTienda.DBContext;
using APISistemaTienda.Repository.Interfaces;
using APISistemaTienda.Repository;
using APISistemaTienda.Utility;


namespace APISistemaTienda.Dependencias
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration) {

            services.AddDbContext<DBTiendaContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("TiendaBD"));
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IVentaRepository, VentaRepository>();

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<ICategoriaService,CategoriaService>();
            services.AddScoped<IProductoService,ProductoService>();
            services.AddScoped<IVentaService,VentaService>();
            services.AddScoped<IDashBoardService,DashBoardService>();
            services.AddScoped<IMenuService,MenuService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IEmpleadoService, EmpleadoService>();

        }

    }
}
