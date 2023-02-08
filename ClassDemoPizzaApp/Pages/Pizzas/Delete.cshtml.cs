using ClassDemoPizzaApp.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLib.model;

namespace ClassDemoPizzaApp.Pages.Pizzas
{
    public class DeleteModel : PageModel
    {
        /*
         * modtage dependency injection
         */
        private IPizzaRepositoryService _service;

        public DeleteModel(IPizzaRepositoryService service)
        {
            _service = service;
        }


        /*
         * Properties til viewet
         */

        public Pizza Pizza { get; set; }

        public void OnGet(int id)
        {
            Pizza = _service.GetById(id);
        }

        public IActionResult OnPostSlet(int id)
        {
            _service.Delete(id);
            return RedirectToPage("Index");
        }

        public IActionResult OnPostFortryd()
        {
            return RedirectToPage("Index");
        }
    }
}
