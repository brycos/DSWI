using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using APISistemaTienda.Repository.Interfaces;
using APISistemaTienda.Dtos;
using APISistemaTienda.Utilidad;

namespace APISistemaTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuServicio;

        public MenuController(IMenuService menuServicio)
        {
            _menuServicio = menuServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<MenuDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _menuServicio.Lista();

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }
            return Ok(rsp);
        }


    }
}
