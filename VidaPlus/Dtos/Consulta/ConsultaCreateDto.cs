namespace VidaPlus.Dtos.Consulta
{
    public class ConsultaCreateDto
    {
        public DateTime DataHora { get; set; }
        public int PacienteId { get; set; }
        public int ProfissionalId { get; set; }
        public string? Observacoes { get; set; }
    }
}
