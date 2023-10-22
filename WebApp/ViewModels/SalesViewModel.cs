using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace WebApp.ViewModels
{
    public class SalesViewModel
    {
        public int SelectedCategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        public int SelectedProductId { get; set; }

        [Display(Name = "Quantity")]
        [Range(1, int.MaxValue)]
        public int QuantityToSell { get; set; }
    }
}
