using EinTech.Test.Core;
using EinTech.Test.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EinTech.Test.Web.Api
{
    [Route("api/[Controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken ct)
        {
            IEnumerable<Person> results = await _personService.GetPersonsAsync(ct);

            return Ok(new GridData<Person>(results));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Person person, CancellationToken ct)
        {
            if (person == null)
                return BadRequest();

            await _personService.AddPersonAsync(person, ct);

            return Ok(person);
        }
    }
}
