using System;
using System.Collections.Generic;

namespace cmpg323_Hw2.Repository
{
	public interface IBaseRepository<T> where T : class
	{
		T Get(Guid id);
		IEnumerable<T> GetAll();
		IEnumerable<T> Find(Func<T, Boolean> predicateFunction);
		void Add(T entity);
		void AddRange(IEnumerable<T> entities);
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entities);
		void Update(T entity);
		bool Exists(Guid id);
	}
}
