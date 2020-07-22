using Eintech.Test.Infrastructure;
using EinTech.Test.Core;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EinTech.Test.Repositories.Tests
{
    public class PersonRepositoryTests : IClassFixture<EinTechContextFixture>
    {
        private readonly EinTechContext _context;

        private readonly Mock<ISystemInfo> _mockSystemInfo;

        private readonly PersonRepository _personRespository;

        public PersonRepositoryTests(EinTechContextFixture contextFixture)
        {
            _context = contextFixture.Context;
            _mockSystemInfo = new Mock<ISystemInfo>(MockBehavior.Strict);
            _personRespository = new PersonRepository(contextFixture.Context, _mockSystemInfo.Object);
        }

        [Fact]
        public async Task CanGetAll()
        {
            IEnumerable<Person> persons = await _personRespository.GetAllAsync(new CancellationToken());

            Assert.Equal(3, persons.Count());
        }

        [Fact]
        async Task CanAddPerson()
        {
            Person person = await _personRespository.AddPersonAsync(new Person(), new CancellationToken());

            Assert.NotNull(person);
            Assert.NotEqual(default, person.Created);
            Assert.NotEqual(0, person.Id);
            Assert.Equal(person, _context.People.Find(person.Id));
            _mockSystemInfo.Verify(s => s.GetCurrentDateTime(), Times.Once);
            _mockSystemInfo.VerifyNoOtherCalls();
        }
    }
}
