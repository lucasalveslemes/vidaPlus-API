using VidaPlus.Tests.Helpers;
using Xunit;
using VidaPlus.Services;
using VidaPlus.Repositories;
using VidaPlus.Data;
using VidaPlus.Dtos.Consulta;
using Microsoft.EntityFrameworkCore;

namespace VidaPlus.Tests.Consulta
{
    public class ConsultaServiceTests
    {
        [Fact]
        public async Task CreateConsulta_ShouldSaveAndReturnDto()
        {
            // Arrange — criar contexto em memória
            var context = InMemoryDbContextFactory.Create();

            // Precisamos criar repositório e service real
            var repository = new ConsultaRepository(context);
            var service = new ConsultaService(repository);

            // Criar DTO de agendamento
            var dto = new ConsultaCreateDto
            {
                DataHora = DateTime.Parse("2025-01-01T10:00:00"),
                PacienteId = 1,
                ProfissionalId = 1,
                Observacoes = "Retorno"
            };

            // Act
            var result = await service.CreateAsync(dto);

            // Assert — verificar retorno
            Assert.NotNull(result);
            Assert.Equal(dto.DataHora, result.DataHora);
            Assert.Equal("Retorno", result.Observacoes);

            // Verificar se realmente foi salvo no banco
            var saved = await context.Consultas.FirstOrDefaultAsync();
            Assert.NotNull(saved);
            Assert.Equal(1, saved.PacienteId);
            Assert.Equal(1, saved.ProfissionalId);
        }
    }
}
