using System;
using GeonAPI.Application.Repositories;
using GeonAPI.Domain.Entities;
using GeonAPI.Persistence.Contexts;

namespace GeonAPI.Persistence.Repositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(GeonAPIDbContext context) : base(context)
        {
        }
    }
}