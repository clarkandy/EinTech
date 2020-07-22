using System.Collections.Generic;

namespace EinTech.Test.Web.Models
{
    public class GridData<T>
    {
        public IEnumerable<T> Data { get; private set; }

        public GridData(IEnumerable<T> results)
            => Data = results;
    }
}
