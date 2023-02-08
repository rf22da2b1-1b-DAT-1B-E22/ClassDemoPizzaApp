using ClassDemoPizzaApp.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLib.model;

namespace ClassDemoPizzaApp.Pages.Pizzas
{
    public class IndexModel : PageModel
    {
        /*
         * modtage dependency injection
         */
        private IPizzaRepositoryService _service;

        public IndexModel(IPizzaRepositoryService service)
        {
            _service = service;
        }


        /*
         * Properties til viewet
         */
        public List<Pizza> Pizzaer { get; set; }

        public void OnGet()
        {
            Pizzaer = _service.GetAll();
        }
    }
}
