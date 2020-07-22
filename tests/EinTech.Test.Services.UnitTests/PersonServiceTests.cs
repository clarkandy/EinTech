using EinTech.Test.Core;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EinTech.Test.Services.UnitTests
{
    public class PersonServiceTests
    {
        private readonly Mock<IPersonRepository> _mockPersonRepository;

        private readonly PersonService _personService;

        public PersonServiceTests()
        {
            _mockPersonRepository = new Mock<IPersonRepository>(MockBehavior.Strict);
            _personService = new PersonService(_mockPersonRepository.Object);
        }

        [Fact]
        public async Task CanGetPersons()
        {
            _mockPersonRepository.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(new[] { new Person() });

            IEnumerable<Person> persons = await _personService.GetPersonsAsync(new CancellationToken());

            Assert.Single(persons);

            _mockPersonRepository.Verify(r => r.GetAllAsync(It.IsAny<CancellationToken>()), Times.Once);
            _mockPersonRepository.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task CanAddPerson()
        {
            Person person = new Person();

            _mockPersonRepository.Setup(r => r.AddPersonAsync(It.IsAny<Person>(), It.IsAny<CancellationToken>())).ReturnsAsync(person);

            Person added = await _personService.AddPersonAsync(person, new CancellationToken());

            Assert.Equal(person, added);
            _mockPersonRepository.Verify(r => r.AddPersonAsync(person, It.IsAny<CancellationToken>()), Times.Once);
            _mockPersonRepository.VerifyNoOtherCalls();
        }
    }
}
