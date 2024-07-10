using Knihy.Data.Services;
using Knihy.Data;
using Knihy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Knihy.Controllers {
    public class BooksController : Controller {
        private readonly IBooksService _service;

        public BooksController(IBooksService service) {
            _service = service;
        }
        public async Task<IActionResult> Index() {
            var allBooks = await _service.GetAllAsync(n => n.Publisher);
            return View(allBooks);

        }

        public async Task<IActionResult> Details(int id) {
            var bookDetails = await _service.GetBookByIdAsync(id);
            return View(bookDetails);
        }

        public async Task<IActionResult> Create() {

            var bookDropdownsData = await _service.GetNewBookDropdownsValues();
            ViewBag.Publishers = new SelectList(bookDropdownsData.Publishers, "Id", "Name");
            ViewBag.Writers = new SelectList(bookDropdownsData.Writers, "Id", "FullName");
			
			return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewBookVM book) {
            if (!ModelState.IsValid) {
				var bookDropdownsData = await _service.GetNewBookDropdownsValues();
				ViewBag.Publishers = new SelectList(bookDropdownsData.Publishers, "Id", "Name");
				ViewBag.Writers = new SelectList(bookDropdownsData.Writers, "Id", "FullName");
               
				return View(book);
            }
            await _service.AddNewBookAsync(book);
            return RedirectToAction(nameof(Index));
        }


		public async Task<IActionResult> Edit(int id) {
            var bookDetails = await _service.GetBookByIdAsync(id);
            if(bookDetails==null) return View("NotFound");

            var response = new NewBookVM() {
                Id = bookDetails.Id,
                Name = bookDetails.Name,
                Description = bookDetails.Description,
                View = bookDetails.View,
                BuyDate = bookDetails.BuyDate,
                FinishedDate = bookDetails.FinishedDate,
                ImageURL = bookDetails.ImageURL,
                BookCategory = bookDetails.BookCategory,
                PublisherId = bookDetails.PublisherId,
                WriterIds = bookDetails.Writer_Books.Select(n => n.WriterId).ToList(),
            };

			var bookDropdownsData = await _service.GetNewBookDropdownsValues();
			ViewBag.Publishers = new SelectList(bookDropdownsData.Publishers, "Id", "Name");
			ViewBag.Writers = new SelectList(bookDropdownsData.Writers, "Id", "FullName");

			return View(response);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(int id, NewBookVM book) {
            if (id != book.Id) return View("NotFound");
			if (!ModelState.IsValid) {
				var bookDropdownsData = await _service.GetNewBookDropdownsValues();
				ViewBag.Publishers = new SelectList(bookDropdownsData.Publishers, "Id", "Name");
				ViewBag.Writers = new SelectList(bookDropdownsData.Writers, "Id", "FullName");

				return View(book);
			}
			await _service.UpdateBookAsync(book);
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Delete(int id) {
			var bookDetails = await _service.GetByIdAsync(id);
			if (bookDetails == null) return View("NotFound");

			return View(bookDetails);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirm(int id) {
			var bookDetails = await _service.GetByIdAsync(id);
			if (bookDetails == null) return View("NotFound");
			await _service.DeleteBookAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
