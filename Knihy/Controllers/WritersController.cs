using Knihy.Data;
using Knihy.Data.Services;
using Knihy.Models;
using Microsoft.AspNetCore.Mvc;

namespace Knihy.Controllers {
	public class WritersController : Controller {

		private readonly IWriterService _service;

		public WritersController(IWriterService service) {
			_service = service;
		}
		public async Task<IActionResult> Index() {
			var data = await _service.GetAllAsync();
			return View(data);
		}
		public IActionResult Create() {
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Writer writer) {
			if (!ModelState.IsValid) { 
			return View(writer);
			}
			await _service.AddAsync(writer);
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Details(int id) { 
			var writerDetails = await _service.GetByIdAsync(id);
			if (writerDetails == null) return View("NotFound");
			return View(writerDetails);
		}
		public async Task<IActionResult> Edit(int id) {
			var writerDetails = await _service.GetByIdAsync(id);
			if (writerDetails == null) return View("NotFound");
			return View(writerDetails);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Writer writer) {
			if (!ModelState.IsValid) {
				return View(writer);
			}
			await _service.UpdateAsync(id, writer);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(int id) {
			var writerDetails = await _service.GetByIdAsync(id);
			if (writerDetails == null) return View("NotFound");
			return View(writerDetails);
		}
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id) {
			var writerDetails = await _service.GetByIdAsync(id);
			if (writerDetails == null) return View("NotFound");

			await _service.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
