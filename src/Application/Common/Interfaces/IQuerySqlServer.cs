using Andreani.Arq.Core.Interface;
using worker_application.Domain.Entities;
using System.Threading.Tasks;

namespace worker_application.Application.Common.Interfaces
{
    public interface IQuerySqlServer: IReadOnlyQuery
    {
        public Task<Person> GetPersonByNameAsync(string name);
    }
}
