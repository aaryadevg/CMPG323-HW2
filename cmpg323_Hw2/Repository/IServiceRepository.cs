using cmpg323_Hw2.Models;

namespace cmpg323_Hw2.Repository
{
	public interface IServiceRepository : IBaseRepository<Services>
	{
		Services GetMostRecent();
	}
}
