using Andreani.Arq.Cqrs.Interfaces;
using Andreani.Arq.Cqrs.Queries;
using worker_application.Application.Common.Interfaces;
using worker_application.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using worker_application.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace worker_application.Infrastructure.Services
{
    public class QuerySqlServer : ReadOnlyQuery, IQuerySqlServer
    {
        private readonly ApplicationDbContext _context;
        public QuerySqlServer([FromKeyedServices("default")] IReadOnlyQueryConfiguration config,
            [FromKeyedServices("default")] ApplicationDbContext context) : base(config)
        {
          _context = context;
        }

        public async Task<Person> GetPersonByNameAsync(string name)
        {
          return await _context.Person.FirstAsync(x => x.Nombre == name);
        }
    }
}
