using System;
using GeonAPI.Application.Repositories;
using GeonAPI.Domain.Entities;
using GeonAPI.Persistence.Contexts;

namespace GeonAPI.Persistence.Repositories
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(GeonAPIDbContext context) : base(context)
        {
        }
    }
}