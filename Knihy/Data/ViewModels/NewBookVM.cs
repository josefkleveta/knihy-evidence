using	Knihy.Data.Base;
using Knihy.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Knihy.Models
{
    public class NewBookVM {
		[Key]
		public int Id { get; set; }
		[Display(Name = "Název knihy")]
        [Required(ErrorMessage = "Název knihy je potřeba")]
        public string Name { get; set; }
		[Display(Name = "Popis knihy")]
		[Required(ErrorMessage = "Popis knihy je fajn")]
		public string Description { get; set; }
		[Display(Name = "URL odkaz na ukázku z knihy")]
		public string? View { get; set; }
		[Display(Name = "URL odkaz na obrázek knihy")]
		[Required(ErrorMessage = "URL odkaz na obrázek knihy")]
		public string ImageURL { get; set; }
		[Display(Name = "Den započetí čtení")]
		public DateTime? BuyDate { get; set; }
		[Display(Name = "Kdy byla kniha dočtena")]
		public DateTime? FinishedDate { get; set; }
		[Display(Name = "Žánr knihy")]
		[Required(ErrorMessage = "Žánr knihy je vyžadován")]
		public BookCategory? BookCategory { get; set; }
		[Display(Name = "Vyberte spisovatele")]
		[Required(ErrorMessage = "Spisovatel je vyžadován")]
		public List<int> WriterIds { get; set; }
		[Display(Name = "Vyberte nakladatelství")]
		public int PublisherId { get; set; }
	
	}
}
