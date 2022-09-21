using cmpg323_Hw2.Data;
using cmpg323_Hw2.Models;

namespace cmpg323_Hw2.Repository
{
	public class ProductsRepository : BaseRepository<Products>
	{
		public ProductsRepository(CMPGHW2Context context) : base(context)
		{
		}
	}
}
