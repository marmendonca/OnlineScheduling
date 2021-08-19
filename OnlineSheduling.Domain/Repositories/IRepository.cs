namespace OnlineScheduling.Domain.Repositories
{
    public interface IRepository<T>
    {
        void Save(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
