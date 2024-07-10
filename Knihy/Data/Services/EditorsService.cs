using Books.Data.Base;
using Knihy.Data;
using Knihy.Models;

namespace Books.Data.Services {
	public class EditorsService:EntityBaseRepository<Editor>,IEditorsService {
        public EditorsService(AppDbContext context):base(context) { }
              
    }
}
