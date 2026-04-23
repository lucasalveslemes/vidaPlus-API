namespace VidaPlus.Domain.Entities
{
    public class Consulta
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }

        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        public int ProfissionalId { get; set; }
        public Profissional Profissional { get; set; }

        public string Observacoes { get; set; }
    }
}
