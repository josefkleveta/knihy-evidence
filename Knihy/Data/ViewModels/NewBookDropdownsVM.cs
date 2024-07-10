using Knihy.Models;
using System.Collections.Concurrent;

namespace Knihy.Data.ViewModels {
	public class NewBookDropdownsVM {
        public NewBookDropdownsVM()
        {
             Publishers = new List<Publisher>();
             Writers = new List<Writer> ();
        }
        public  List<Publisher> Publishers { get; set; }
        public List<Writer> Writers { get; set; }

    }
}
