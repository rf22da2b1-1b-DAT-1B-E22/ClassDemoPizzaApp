using ClassDemoPizzaApp.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaLib.model;
using System.ComponentModel.DataAnnotations;

namespace ClassDemoPizzaApp.Pages.Pizzas
{
    public class CreateModel : PageModel
    {
        private IPizzaRepositoryService service;

        public CreateModel(IPizzaRepositoryService repo)
        {
            service = repo;
        }

        /*
         * Properties to create a Member
         */
        [BindProperty]
        [Required(ErrorMessage = "Der skal være et Piiza Id")]
        [Range(0, int.MaxValue, ErrorMessage = "Pizza Id må ikke være negativ")]
        public int Id { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Der skal være et Navn")]
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Navn skal være mindst 3 tegn")]
        public String Navn { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Der skal være en pris")]
        [Range(30, 1000, ErrorMessage = "Prisen skal være over 30")]
        public double Price { get; set; }

        [BindProperty]
        public PizzaType Slags { get; set; }

        
        public List<PizzaType> PizzaTyper { get; set; }


        // når siden vises
        public void OnGet()
        {
            PizzaTyper = Enum.GetValues<PizzaType>().ToList();
        }


        // Når vi trykker på en knap
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            PizzaEnum pizza = new PizzaEnum(Id, Navn, Price, Slags);
            service.Create(pizza);

            return RedirectToPage("Index");
            
        }
    }
}
