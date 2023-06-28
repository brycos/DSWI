using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using APISistemaTienda.Repository.Interfaces;
using APISistemaTienda.Dtos;
using APISistemaTienda.Utilidad;

namespace APISistemaTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {

        private readonly IDashBoardService _dashboardServicio;

        public DashBoardController(IDashBoardService dashboardServicio)
        {
            _dashboardServicio = dashboardServicio;
        }


        [HttpGet]
        [Route("Resumen")]
        public async Task<IActionResult> Resumen()
        {
            var rsp = new Response<DashBoardDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _dashboardServicio.Resumen();

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
