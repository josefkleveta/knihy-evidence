using Knihy.Data;
using Knihy.Data.Base;
using Knihy.Models;


namespace Knihy.Data.Services {
	public class WritersService : EntityBaseRepository<Writer>, IWriterService {
		public WritersService(AppDbContext context):base(context) {
			
		}

	}
}
