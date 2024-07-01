using Microsoft.AspNetCore.Mvc;
using API_SistemaInterno.Models;
using API_SistemaInterno.RabitMQ;
using API_SistemaInterno.Services;

namespace API_SistemaInterno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;
        private readonly IRabitMQUsuario _rabitMQUsuario;

        public UsuarioController(IUsuarioService _usuarioService, IRabitMQUsuario rabitMQUsuario)
        {
            usuarioService = _usuarioService;
            _rabitMQUsuario = rabitMQUsuario;
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

            //send the inserted product data to the queue and consumer will listening this data from queue
            _rabitMQUsuario.SendSistemaExterno1_Incluir(usuarioData);
            _rabitMQUsuario.SendSistemaExterno2_Incluir(usuarioData);


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
