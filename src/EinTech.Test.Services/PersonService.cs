using EinTech.Test.Core;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EinTech.Test.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
            => _personRepository = personRepository;

        public async Task<Person> AddPersonAsync(Person person, CancellationToken ct)
            => await _personRepository.AddPersonAsync(person, ct);

        public async Task<IEnumerable<Person>> GetPersonsAsync(CancellationToken ct)
            => await _personRepository.GetAllAsync(ct);
    }
}
