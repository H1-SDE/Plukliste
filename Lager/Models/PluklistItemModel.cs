using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lager.Models
{
    public class PluklistItemModel
    {
        public string? ProductID { get; set; }
        public string? Description { get; set; }
        public int Antal { get; set; }

        public SelectList? SelectListItems { get; set; }

        public int FakturaNummer { get; set; }
    }
}
