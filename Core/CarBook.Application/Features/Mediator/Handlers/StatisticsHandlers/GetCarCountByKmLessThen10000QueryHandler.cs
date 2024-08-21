using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarCountByKmLessThen10000QueryHandler : IRequestHandler<GetCarCountByKmLessThen10000Query, GetCarCountByKmLessThen10000QueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByKmLessThen10000QueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByKmLessThen10000QueryResult> Handle(GetCarCountByKmLessThen10000Query request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByKmLessThen10000();
            return new GetCarCountByKmLessThen10000QueryResult
            {
                CarCountByKmLessThen10000 = value,
            };
        }
    }
}
