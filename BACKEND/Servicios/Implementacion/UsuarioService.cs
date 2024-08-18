using Microsoft.EntityFrameworkCore;
using PROYECTO_FLK.BACKEND.Servicios.Contrato;
using PROYECTO_FLK.Models;

namespace PROYECTO_FLK.BACKEND.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {

        private readonly BdSswoggflkContext _context;

        public UsuarioService(BdSswoggflkContext context)
        {
            _context = context;

        }



        public async Task<Usuario> GetUsuario(string nombre_usuario, string contraseña)
        {

            Usuario usuario_encontrado = await _context.Usuarios.Where(u => u.NombreUsuario == nombre_usuario && u.Contraseña == contraseña)

                .FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _context.Usuarios.Add(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }
    }
}

