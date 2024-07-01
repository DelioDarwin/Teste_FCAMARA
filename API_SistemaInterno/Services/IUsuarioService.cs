using API_SistemaInterno.Models;

namespace API_SistemaInterno.Services
{
    public interface IUsuarioService
    {
        public IEnumerable<Usuario> GetUsuarioList();
        public Usuario GetUsuarioById(int id);
        public Usuario AddUsuario(Usuario usuario);
        public Usuario UpdateUsuario(Usuario usuario);
        public bool DeleteUsuario(int Id);
        public LogErro AddErro(LogErro logErro);
        public IEnumerable<LogErro> GetLogErrosList();
    }
}
