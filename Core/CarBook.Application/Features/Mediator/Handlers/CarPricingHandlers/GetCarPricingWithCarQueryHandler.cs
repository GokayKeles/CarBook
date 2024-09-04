﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Features.Mediator.Results.ServiceResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
	internal class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
	{
		private readonly ICarPricingRepository _repository;

		public GetCarPricingWithCarQueryHandler(ICarPricingRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetCarPricingWithCars();
			return values.Select(x => new GetCarPricingWithCarQueryResult
			{
			   Amount = x.Amount,
			   CarPricingID = x.CarPricingID,
		       Brand = x.Car.Brand.Name,
			   CoverImageUrl = x.Car.CoverImageUrl,
			   Model = x.Car.Model,
			   CarID = x.CarID,
			}).ToList();
		}
	}
}
