using GeonAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace GeonAPI.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}