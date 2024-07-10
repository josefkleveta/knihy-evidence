using Knihy.Data.Base;
using Knihy.Data.ViewModels;
using Knihy.Data;
using Knihy.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Knihy.Data.Services {
	public class BooksService : EntityBaseRepository<Book>, IBooksService {
		private readonly AppDbContext _context;

		public BooksService(AppDbContext context) : base(context) {
			_context = context;
		}

		public async Task AddNewBookAsync(NewBookVM data) {
			var newBook = new Book() {
		
				Name = data.Name,
				Description = data.Description,
				View = data.View,
				ImageURL = data.ImageURL,
				PublisherId = data.PublisherId,
				BuyDate = data.BuyDate,
				FinishedDate = data.FinishedDate,
				BookCategory = data.BookCategory,
			};
			await _context.Books.AddAsync(newBook);
			await _context.SaveChangesAsync();

			foreach (var writerId in data.WriterIds) {
				var newWriterBook = new Writer_Book() {
					BookId = newBook.Id,
					WriterId = writerId
				};
				await _context.Writer_Books.AddAsync(newWriterBook);
			}
			await _context.SaveChangesAsync();
		}


		public async Task<Book> GetBookByIdAsync(int id) {
			var bookDetails = await _context.Books.Include(p => p.Publisher).Include(wb => wb.Writer_Books).ThenInclude(w => w.Writer).FirstOrDefaultAsync(n => n.Id == id);
			return bookDetails;
		}

		public async Task<NewBookDropdownsVM> GetNewBookDropdownsValues() {
			var response = new NewBookDropdownsVM() {
				Writers = await _context.Writers.OrderBy(n => n.FullName).ToListAsync(),
				Publishers = await _context.Publishers.OrderBy(n => n.Name).ToListAsync(),
			};

			return response;
		}

		public async Task UpdateBookAsync(NewBookVM data) {
			var dbBooks = await _context.Books.FirstOrDefaultAsync(n => n.Id == data.Id);
			if (dbBooks != null) {

					dbBooks.Name = data.Name;
					dbBooks.Description = data.Description;
					dbBooks.View = data.View;
					dbBooks.ImageURL = data.ImageURL;
					dbBooks.PublisherId = data.PublisherId;
					dbBooks.BuyDate = data.BuyDate;
					dbBooks.FinishedDate = data.FinishedDate;
					dbBooks.BookCategory = data.BookCategory;
					await _context.SaveChangesAsync();
			};

			var existingWriterDb = _context.Writer_Books.Where(n => n.WriterId == data.Id).ToList();
			_context.Writer_Books.RemoveRange(existingWriterDb);
			await _context.SaveChangesAsync();


			foreach (var writerId in data.WriterIds) {
				var newWriterBook = new Writer_Book() {
					BookId = data.Id,
					WriterId = writerId
				};
				await _context.Writer_Books.AddAsync(newWriterBook);
			}
			await _context.SaveChangesAsync();

		}
		public async Task DeleteBookAsync(int id) {
			var book = await _context.Books.FirstOrDefaultAsync(n => n.Id == id);
			if (book != null) {
				var writerBooks = _context.Writer_Books.Where(wb => wb.BookId == id).ToList();
				_context.Writer_Books.RemoveRange(writerBooks);
				_context.Books.Remove(book);
				await _context.SaveChangesAsync();
			}
		}

	}
}
