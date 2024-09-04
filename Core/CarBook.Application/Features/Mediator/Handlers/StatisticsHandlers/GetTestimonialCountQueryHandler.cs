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
    public class GetTestimonialCountQueryHandler:IRequestHandler<GetTestimonialCountQuery, GetTestimonialCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetTestimonialCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetTestimonialCountQueryResult> Handle(GetTestimonialCountQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetTestimonialCount();
            return new GetTestimonialCountQueryResult
            {
                TestimonialCount = value,
            };
        }
    }
}
