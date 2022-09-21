using cmpg323_Hw2.Data;
using cmpg323_Hw2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cmpg323_Hw2.Repository
{
	public class ServicesRepository : BaseRepository<Services>, IServiceRepository
	{
		public ServicesRepository(CMPGHW2Context context) : base(context)
		{
		}

		public Services GetMostRecent()
		{
			 return _ctx.Services.OrderByDescending(Service => Service.CreatedDate).FirstOrDefault();
		}
	}
}
