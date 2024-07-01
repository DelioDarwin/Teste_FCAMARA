using API_SistemaInterno.Data;
using API_SistemaInterno.Models;

namespace API_SistemaInterno.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DbContextClass _dbContext;
       
        public UsuarioService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Usuario> GetUsuarioList()
        {
            return _dbContext.Usuarios.ToList();
        }
        public Usuario GetUsuarioById(int id)
        {
            return _dbContext.Usuarios.Where(x => x.IdUsuario == id).FirstOrDefault();
        }

        public Usuario AddUsuario(Usuario usuario)
        {
            var result = _dbContext.Usuarios.Add(usuario);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public Usuario UpdateUsuario(Usuario usuario)
        {
            var result = _dbContext.Usuarios.Update(usuario);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public bool DeleteUsuario(int Id)
        {
            var filteredData = _dbContext.Usuarios.Where(x => x.IdUsuario == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }
    }
}
