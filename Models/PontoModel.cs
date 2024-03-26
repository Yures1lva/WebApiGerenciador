using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiGerenciador.Models
{
    public class PontoModel 
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("colaboradorId")]
        public int colaboradorId { get; set; }

        public DateTime hEntrada { get; set; } 

        public DateTime hSaida { get; set; }

    }
}
