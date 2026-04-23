namespace VidaPlus.Dtos.Consulta
{
    public class ConsultaReadDto
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public string PacienteNome { get; set; }
        public string ProfissionalNome { get; set; }
        public string? Observacoes { get; set; }
    }
}
