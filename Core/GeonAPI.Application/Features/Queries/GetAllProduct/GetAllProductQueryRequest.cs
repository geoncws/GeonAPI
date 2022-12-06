using System;
using GeonAPI.Application.RequestParameters;
using MediatR;

namespace GeonAPI.Application.Features.Queries.GetAllProduct
{
	public class GetAllProductQueryRequest: IRequest<GetAllProductQueryResponse>
	{
		public Pagination Pagination { get; set; }
	}
}

