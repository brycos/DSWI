using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using APISistemaTienda.Repository.Interfaces;
using APISistemaTienda.Dtos;
using APISistemaTienda.Utilidad;

namespace APISistemaTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoServicio;

        public EmpleadoController(IEmpleadoService empleadoServicio)
        {
            _empleadoServicio = empleadoServicio;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<EmpleadoDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _empleadoServicio.Lista();

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }
            return Ok(rsp);
        }

       
        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] EmpleadoDTO empleado)
        {
            var rsp = new Response<EmpleadoDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _empleadoServicio.Crear(empleado);

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }
            return Ok(rsp);

        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] EmpleadoDTO empleado)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _empleadoServicio.Editar(empleado);

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }
            return Ok(rsp);

        }



        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _empleadoServicio.Eliminar(id);

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
