using Knihy.Data.Base;
using Knihy.Data;
using Knihy.Models;

namespace Knihy.Data.Services {
	public class PublisherService:EntityBaseRepository<Publisher>, IPublisherService {
        public PublisherService(AppDbContext context):base(context)
        {
            
        }
    }
}
