using System.ComponentModel.DataAnnotations;

namespace API_SistemaInterno.Models
{
    public class LogErro
    {
        [Key]
        public int IdLogErro { get; set; }
        public string TipoErro { get; set; }
        public string Dados { get; set; }
    }
}
