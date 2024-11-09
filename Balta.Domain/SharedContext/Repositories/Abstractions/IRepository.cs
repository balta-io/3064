using Balta.Domain.SharedContext.Aggregates.Abstractions;

namespace Balta.Domain.SharedContext.Repositories.Abstractions;

public interface IRepository<TEntity> where TEntity : IAggregateRoot;