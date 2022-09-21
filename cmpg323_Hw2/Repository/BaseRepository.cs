using cmpg323_Hw2.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cmpg323_Hw2.Repository
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class
	{ 
		protected readonly CMPGHW2Context _ctx;

		public BaseRepository(CMPGHW2Context context)
		{
			this._ctx = context;
		}
		public void Add(T entity)
		{
			_ctx.Set<T>().Add(entity);
		}

		public void AddRange(IEnumerable<T> entities)
		{
			_ctx.Set<T>().AddRange(entities);
		}

		public bool Exists(Guid id)
		{
			T value = _ctx.Set<T>().Find(id);
			if (value != null)
			{
				return true;
			}

			return false;
		}

		public IEnumerable<T> Find(Func<T, bool> predicateFunction)
		{
			return _ctx.Set<T>().Where(predicateFunction);
		}

		public T Get(Guid id)
		{
			return _ctx.Set<T>().Find(id);
		}

		public IEnumerable<T> GetAll()
		{
			return _ctx.Set<T>().ToList();
		}

		public void Remove(T entity)
		{
			_ctx.Set<T>().Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			_ctx.Set<T>().RemoveRange(entities);
		}

		public void Update(T entity)
		{
			_ctx.Set<T>().Update(entity);
		}
	}
}
