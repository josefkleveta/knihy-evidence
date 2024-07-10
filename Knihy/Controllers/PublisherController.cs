using Knihy.Data;
using Knihy.Data.Services;
using Knihy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Knihy.Controllers {
    public class PublisherController : Controller {
        private readonly IPublisherService _service;

        public PublisherController(IPublisherService service) {
            _service = service;
        }
        public async Task<IActionResult> Index() {
            var allPublisher = await _service.GetAllAsync();
            return View(allPublisher);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Publisher publisher) {
            if (!ModelState.IsValid) return View(publisher);
            await _service.AddAsync(publisher);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id) { 
        var publisherDetails = await _service.GetByIdAsync(id);
            if (publisherDetails == null) return View("NotFound");
            return View(publisherDetails);
        }
		public async Task<IActionResult> Edit(int id) {
			var publisherDetails = await _service.GetByIdAsync(id);
			if (publisherDetails == null) return View("NotFound");
			return View(publisherDetails);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Publisher publisher) {
			if (!ModelState.IsValid) return View(publisher);
			await _service.UpdateAsync(id, publisher);
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Delete(int id) {
			var publisherDetails = await _service.GetByIdAsync(id);
			if (publisherDetails == null) return View("NotFound");
			return View(publisherDetails);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirm(int id) {
			var publisherDetails = await _service.GetByIdAsync(id);
			if (publisherDetails == null) return View("NotFound"); 
			await _service.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
