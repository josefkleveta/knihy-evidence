using Books.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Knihy.Models {

	public class Editor : IEntityBase {
		[Key]
		public int Id { get; set; }
		[Display(Name = "Profile picture URL")]

		public string ProfilePictureURL { get; set; }
		[Display(Name = "Full Name")]

		public string FullName { get; set; }
		[Display(Name = "Biography")]

		public string Bio { get; set; }
		public List<Book>? Books { get; set; }

	}
}
