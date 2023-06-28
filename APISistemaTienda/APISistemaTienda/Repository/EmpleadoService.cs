using APISistemaTienda.Dtos;
using APISistemaTienda.Models;
using APISistemaTienda.Repository.Interfaces;
using AutoMapper;

namespace APISistemaTienda.Repository
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IGenericRepository<Empleado> _empleadoRepositorio;
        private readonly IMapper _mapper;

        public EmpleadoService(IGenericRepository<Empleado> empleadoRepositorio, IMapper mapper)
        {
            _empleadoRepositorio = empleadoRepositorio;
            _mapper = mapper;
        }

        public async Task<List<EmpleadoDTO>> Lista()
        {
            try
            {
                var listaEmpleados = await _empleadoRepositorio.Consultar();

                return _mapper.Map<List<EmpleadoDTO>>(listaEmpleados.ToList());
            }
            catch
            {
                throw;
            }
        }

        public async Task<EmpleadoDTO> Crear(EmpleadoDTO modelo)
        {
            try
            {

                var empleadoCreado = await _empleadoRepositorio.Crear(_mapper.Map<Empleado>(modelo));

                if (empleadoCreado.IdEmp == 0)
                    throw new TaskCanceledException("No se pudo crear");

                var query = await _empleadoRepositorio.Consultar(e => e.IdEmp == empleadoCreado.IdEmp);

                empleadoCreado = query.First();

                return _mapper.Map<EmpleadoDTO>(empleadoCreado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(EmpleadoDTO modelo)
        {
            try
            {
                var empleadoModelo = _mapper.Map<Empleado>(modelo);

                var empleadoEncontrado = await _empleadoRepositorio.Obtener(e => e.IdEmp == empleadoModelo.IdEmp);

                if (empleadoEncontrado == null)
                    throw new TaskCanceledException("El empleado no existe");

                empleadoEncontrado.NomEmp = empleadoModelo.NomEmp;
                empleadoEncontrado.ApeEmp = empleadoModelo.ApeEmp;
                empleadoEncontrado.TelEmp = empleadoModelo.TelEmp;
                empleadoEncontrado.DirEmp = empleadoModelo.DirEmp;
                empleadoEncontrado.Correo = empleadoModelo.Correo;
                empleadoEncontrado.Estado = empleadoModelo.Estado;

                bool respuesta = await _empleadoRepositorio.Editar(empleadoEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo editar");

                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var empleadoEncontrado = await _empleadoRepositorio.Obtener(e => e.IdEmp == id);

                if (empleadoEncontrado == null)
                    throw new TaskCanceledException("El empleado no existe");

                bool respuesta = await _empleadoRepositorio.Eliminar(empleadoEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo eliminar");

                return respuesta;
            }
            catch
            {
                throw;
            }
        }


    }
}
