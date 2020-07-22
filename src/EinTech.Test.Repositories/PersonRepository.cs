using Eintech.Test.Infrastructure;
using EinTech.Test.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EinTech.Test.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly EinTechContext _einTechContext;

        private readonly ISystemInfo _systemInfo;

        public PersonRepository(EinTechContext einTechContext, ISystemInfo systemInfo)
        {
            _einTechContext = einTechContext;
            _systemInfo = systemInfo;
        }

        public async Task<Person> AddPersonAsync(Person person, CancellationToken ct)
        {
            person.Created = _systemInfo.GetCurrentDateTime();
            await _einTechContext.People.AddAsync(person, ct);
            await _einTechContext.SaveChangesAsync(ct);

            return person;
        }

        public async Task<IEnumerable<Person>> GetAllAsync(CancellationToken ct)
            => await _einTechContext.People.ToListAsync(ct);
    }
}
