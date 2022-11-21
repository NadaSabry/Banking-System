using Microsoft.AspNetCore.Mvc.Rendering;
using Banking_System.Models;

namespace Banking_System.ViewModel
{
    public class AddTransferVM
    {
        public Transfer? transfer { get; set; }
        public Customer? customerFrom { get; set; }
        public IEnumerable<SelectListItem>? customers { get; set; }
    }
}
