namespace VidaPlus.Domain.Entities
{
    public class Profissional
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }
        public string RegistroProfissional { get; set; }
        public string Telefone { get; set; }

        // Relacionamento: um profissional possui várias consultas
        public ICollection<Consulta> Consultas { get; set; }
    }
}
