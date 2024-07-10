using Knihy.Data.Base;
using Knihy.Data.ViewModels;
using Knihy.Models;

namespace Knihy.Data.Services {
	public interface IBooksService:IEntityBaseRepository<Book> {
		Task<Book> GetBookByIdAsync(int id);
		Task<NewBookDropdownsVM> GetNewBookDropdownsValues();
		Task AddNewBookAsync(NewBookVM data);
		Task UpdateBookAsync(NewBookVM data);
		Task DeleteBookAsync(int id);
	}
}
