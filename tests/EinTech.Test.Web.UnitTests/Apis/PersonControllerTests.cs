using EinTech.Test.Core;
using EinTech.Test.Web.Api;
using EinTech.Test.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EinTech.Test.Web.UnitTests.Apis
{
    public class PersonControllerTests
    {
        private readonly Mock<IPersonService> _mockPersonService;

        private readonly PersonController _personController;

        public PersonControllerTests()
        {
            _mockPersonService = new Mock<IPersonService>(MockBehavior.Strict);
            _personController = new PersonController(_mockPersonService.Object);
        }

        [Fact]
        public async Task CanGetPersons()
        {
            _mockPersonService.Setup(s => s.GetPersonsAsync(It.IsAny<CancellationToken>())).ReturnsAsync(new[] { new Person() });

            IActionResult result = await _personController.Get(new CancellationToken());
            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
            GridData<Person> gridData = Assert.IsType<GridData<Person>>(okResult.Value);

            Assert.Single(gridData.Data);
            _mockPersonService.Verify(s => s.GetPersonsAsync(It.IsAny<CancellationToken>()), Times.Once);
            _mockPersonService.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task CanAddPerson()
        {
            Person personToAdd = new Person();

            _mockPersonService.Setup(s => s.AddPersonAsync(It.IsAny<Person>(), It.IsAny<CancellationToken>())).ReturnsAsync(personToAdd);

            IActionResult result = await _personController.Post(personToAdd, new CancellationToken());
            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
            Person person = Assert.IsType<Person>(okResult.Value);

            Assert.Equal(person, personToAdd);
            _mockPersonService.Verify(s => s.AddPersonAsync(personToAdd, It.IsAny<CancellationToken>()), Times.Once);
            _mockPersonService.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task CannotAddNullPerson()
        {
            IActionResult result = await _personController.Post(null, new CancellationToken());

            Assert.IsType<BadRequestResult>(result);
            _mockPersonService.VerifyNoOtherCalls();
        }
    }
}
