using Knihy.Data.Base;
using Knihy.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Knihy.Models
{
    public class Book:IEntityBase {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? View { get; set; }
        public string ImageURL { get; set; }
        public DateTime? BuyDate { get; set; }
        public DateTime? FinishedDate { get; set; }
        public BookCategory? BookCategory { get; set; }
        
        public List<Writer_Book> Writer_Books { get; set; }


        public int PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }
    }
}
