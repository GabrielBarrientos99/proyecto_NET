using PROYECTO_FLK.Models;

namespace PROYECTO_FLK.BACKEND.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuario(string nombre_usuario, string contraseña);
        Task<Usuario> SaveUsuario(Usuario modelo);


    }
}
