using VidaPlus.Tests.Helpers;
using Xunit;
using VidaPlus.Services;
using VidaPlus.Repositories;
using VidaPlus.Data;
using VidaPlus.Dtos.Paciente;
using Microsoft.EntityFrameworkCore;

namespace VidaPlus.Tests.Paciente
{
    public class PacienteServiceTests
    {
        [Fact]
        public async Task CreatePaciente_ShouldReturnPacienteReadDto()
        {
            // Arrange: cria o DbContext em memória
            var context = InMemoryDbContextFactory.Create();

            // Cria repository e service real
            var repository = new PacienteRepository(context);
            var service = new PacienteService(repository);

            // DTO de exemplo
            var dto = new PacienteCreateDto
            {
                Nome = "Lucas Teste",
                Email = "lucasteste@example.com",
                CPF = "12345678900",
                Telefone = "99999999",
                Endereco = "Rua Teste 123",        // OBRIGATÓRIO
                DataNascimento = DateTime.Parse("2000-01-01"),
                Observacoes = "Nenhuma"
            };

            // Act: chama o serviço real
            var result = await service.CreateAsync(dto);

            // Assert: valida resultados
            Assert.NotNull(result);
            Assert.Equal("Lucas Teste", result.Nome);

            // Confirma que foi salvo no banco
            var saved = await context.Pacientes.FirstOrDefaultAsync();
            Assert.NotNull(saved);
            Assert.Equal("Lucas Teste", saved.Nome);
        }
    }
}
