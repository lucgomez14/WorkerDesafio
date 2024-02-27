﻿using Andreani.Arq.Pipeline.Clases;
using worker_application.Application.Common.Interfaces;
using worker_application.Domain.Entities;
using MediatR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace worker_application.Application.UseCase.V1.PersonOperation.Queries.GetList
{

  public record struct ListPerson : IRequest<Response<List<Person>>>
  {
  }

  public class ListPersonHandler(IQuerySqlServer query) : IRequestHandler<ListPerson, Response<List<Person>>>
  {
    public async Task<Response<List<Person>>> Handle(ListPerson request, CancellationToken cancellationToken)
    {
      var result = await query.GetAllAsync<Person>();
      return new Response<List<Person>>
      {
        Content = result.ToList(),
        StatusCode = System.Net.HttpStatusCode.OK
      };
    }
  }
}
