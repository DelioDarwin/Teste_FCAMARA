using Microsoft.AspNetCore.Mvc;
using API_SistemaExterno1.Models;
using API_SistemaExterno1.Services;

namespace API_SistemaExterno1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService _usuarioService)
        {
            usuarioService = _usuarioService;
        }

        [HttpGet("usuariolist")]
        public IEnumerable<Usuario> UsuariotList()
        {
            var usuarioList = usuarioService.GetUsuarioList();
            return usuarioList;

        }
        [HttpGet("getusuariobyid")]
        public Usuario GetUsuarioById(int Id)
        {
            return usuarioService.GetUsuarioById(Id);
        }

        [HttpPost("addusuario")]
        public Usuario AddUsuario(Usuario usuario)
        {
            var usuarioData = usuarioService.AddUsuario(usuario);

            return usuarioData;
        }

        [HttpPut("updateusuario")]
        public Usuario UpdateUsuario(Usuario usuario)
        {
            return usuarioService.UpdateUsuario(usuario);
        }

        [HttpDelete("deleteusuario")]
        public bool DeleteUsuario(int Id)
        {
            return usuarioService.DeleteUsuario(Id);
        }
    }
}
