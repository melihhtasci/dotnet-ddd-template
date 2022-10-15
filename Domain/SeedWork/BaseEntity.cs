namespace Domain.SeedWork
{
    public abstract class BaseEntity
    {
        public Guid Id { get; } = Guid.NewGuid(); // just for now
    }
}
