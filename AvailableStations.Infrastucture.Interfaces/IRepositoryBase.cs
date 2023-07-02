namespace AvailableStations.Infrastucture.Interfaces
{
	public interface IRepositoryBase<T> where T : class
	{
		Task<T?> CreateAsync(T entity);
		Task<T?> UpdateAsync(T entity);
		Task<bool> DeleteAsync(Guid id);
	}
}
