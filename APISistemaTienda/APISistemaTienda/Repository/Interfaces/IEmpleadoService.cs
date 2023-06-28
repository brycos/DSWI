using APISistemaTienda.Dtos;

namespace APISistemaTienda.Repository.Interfaces
{
    public interface IEmpleadoService
    {
        Task<List<EmpleadoDTO>> Lista();
        Task<EmpleadoDTO> Crear(EmpleadoDTO modelo);
        Task<bool> Editar(EmpleadoDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
