using Knihy.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Knihy.Models {
    public class Publisher:IEntityBase {
        [Key]
        public int Id { get; set; }
        [Display(Name = "URL odkaz loga nakladatele")]
        [Required(ErrorMessage ="Nebylo nic zadáno")]
        public string Logo { get; set; }
		[Display(Name = "Název")]
		[Required(ErrorMessage = "Uveďte název nakladatelství")]
		public string Name { get; set; }
		[Display(Name = "Popis")]
		[Required(ErrorMessage = "Chybí informace o nakladatelství")]
		public string Description { get; set; }
        public List<Book>? Books { get; set; }
    }
}
