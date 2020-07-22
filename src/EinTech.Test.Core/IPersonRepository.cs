using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EinTech.Test.Core
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllAsync(CancellationToken ct);
        Task<Person> AddPersonAsync(Person person, CancellationToken ct);
    }
}
