using Knihy.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Knihy.Models {
    public class Writer:IEntityBase {
        [Key]
        public int Id { get; set; }
        [Display(Name ="URL fotky spisovatele")]
        [Required(ErrorMessage ="Profilový obrázek je potřeba zadat")]
        public string ProfilePictureURL { get; set; }
		[Display(Name = "Celé jméno")]
		[Required(ErrorMessage = "Uvedení jména je třeba")]
		[StringLength(50, MinimumLength = 3,ErrorMessage ="Jméno musí být v rozmezí 3 - 50 znaků")]
		public string FullName { get; set; }
		[Display(Name = "Biografie")]
		[Required(ErrorMessage = "Chybí údaje o autorovi")]
		public string Bio { get; set; }
		public List<Writer_Book>? Writer_Books { get; set; }
    }
}
