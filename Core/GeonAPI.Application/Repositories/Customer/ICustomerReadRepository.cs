using System;
using System.Linq.Expressions;
using GeonAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeonAPI.Application.Repositories
{
    public interface ICustomerReadRepository : IReadRepository<Customer>
    {

    }
}