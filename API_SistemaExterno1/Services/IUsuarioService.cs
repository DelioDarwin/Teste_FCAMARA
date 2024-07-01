using API_SistemaExterno1.Models;

namespace API_SistemaExterno1.Services
{
    public interface IUsuarioService
    {
        public IEnumerable<Usuario> GetUsuarioList();
        public Usuario GetUsuarioById(int id);
        public Usuario AddUsuario(Usuario usuario);
        public Usuario UpdateUsuario(Usuario usuario);
        public bool DeleteUsuario(int Id);
    }
}
