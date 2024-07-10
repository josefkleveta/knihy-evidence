using Books.Data.Services;
using Knihy.Data;
using Knihy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Knihy.Controllers {
    public class EditorsController : Controller {
        private readonly IEditorsService _service;

        public EditorsController(IEditorsService service) {
			_service = service;
        }
        public async Task<IActionResult> Index() {
            var data = await _service.GetAllAsync();
            return View(data);

        }

        public async Task<IActionResult> Details(int id) { 
            var editorDetails = await _service.GetByIdAsync(id);
            if (editorDetails == null) return View("NotFound");
            return View(editorDetails);
        }

        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")]Editor editor) { 
            if(!ModelState.IsValid) return View(editor);
            await _service.AddAsync(editor);
            return RedirectToAction(nameof(Index));
        }

		public async Task<IActionResult> Edit(int id) {
            var editorDetails = await _service.GetByIdAsync(id);
            if (editorDetails == null) return View("NotFound");
			return View(editorDetails);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Editor editor) {

			if (!ModelState.IsValid) return View(editor);
            if (id == editor.Id) {
                await _service.UpdateAsync(id, editor);
                return RedirectToAction(nameof(Index));
            }
            return View(editor);
		}
		public async Task<IActionResult> Delete(int id) {
			var editorDetails = await _service.GetByIdAsync(id);
			if (editorDetails == null) return View("NotFound");
			return View(editorDetails);
		}
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id) {
            var editorDetails = await _service.GetByIdAsync(id);
            if (editorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id); 
            return RedirectToAction(nameof(Index));

		}

	}
}
