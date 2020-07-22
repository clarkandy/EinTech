using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EinTech.Test.Core
{
    public interface IPersonService
    {
        Task<Person> AddPersonAsync(Person person, CancellationToken ct);

        Task<IEnumerable<Person>> GetPersonsAsync(CancellationToken ct);
    }
}
