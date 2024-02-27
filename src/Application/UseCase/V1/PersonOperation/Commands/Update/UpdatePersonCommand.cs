using worker_application.Application.Common.Interfaces;
using worker_application.Domain.Common;
using worker_application.Domain.Entities;
using Andreani.Arq.Pipeline.Clases;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;

namespace worker_application.Application.UseCase.V1.PersonOperation.Commands.Update;

public class UpdatePersonCommand : IRequest<Response<string>>
{
  public required string PersonId { get; set; }
  public required string Nombre { get; set; }
  public required string Apellido { get; set; }
}

public class UpdatePersonHandler(ICommandSqlServer repository, IQuerySqlServer query, ILogger<UpdatePersonHandler> logger) : IRequestHandler<UpdatePersonCommand, Response<string>>
{

  public async Task<Response<string>> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
  {
    var person = await query.GetByIdAsync<Person>(nameof(request.PersonId), request.PersonId);
    var response = new Response<string>();
    if (person is null)
    {
      response.AddNotification("#3123", nameof(request.PersonId), string.Format(ErrorMessage.NOT_FOUND_RECORD, "Person", request.PersonId));
      response.StatusCode = System.Net.HttpStatusCode.NotFound;
      return response;
    }
    person.Nombre = request.Nombre;
    person.Apellido = request.Apellido;

    repository.Update(person);
    await repository.SaveChangeAsync();

    logger.LogInformation("the update was successful");

    return response;
  }

}
