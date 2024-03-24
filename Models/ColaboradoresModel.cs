using System.ComponentModel.DataAnnotations;
using WebApiGerenciador.Enums;


namespace WebApiGerenciador.Models
{
    public class ColaboradoresModel
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public CargosEnum Cargo { get; set; }

        public int Matricula { get; set; }

        public float Salario { get; set; }
    }
}
