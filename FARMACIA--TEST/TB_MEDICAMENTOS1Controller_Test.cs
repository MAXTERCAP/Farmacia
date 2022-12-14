using Farmacia.Controllers;
using Moq;


namespace FARMACIA__TEST
{
    public class TB_MEDICAMENTOS1Controller_Test
    {

        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfMedicamentosAsync()
        {

            // Arrange
            var mockRepo = new Mock<IBrainstormMedicamentosRepository>();
            mockRepo.Setup(repo => repo.ListAsync())
                .ReturnsAsync(GetTestMedicamentos());
            var controller = new TB_MEDICAMENTOS1Controller(mockRepo.Object);


            // Act
            var result = await controller.Index();


            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Medicamentos>>(
                viewResult.ViewData.Model);
            Assert.Equal("Remedio1", model1[0].nombre);
            Assert.Equal(2, model.Count());

        }


        private List<Medicamentos> GetTestMedicamentos()
            {
                var medicamentos = new List<Medicamentos>();
                medicamentos.Add(new Medicamentos()
                {
                    Medicamento = 1,
                    NomMed = "Remedio1"
                });
                medicamentos.Add(new Medicamentos()
                {
                    Medicamento = 2,
                    NomMed = "Remedio2"
                });
                return medicamentos;
            }

                
    }
}