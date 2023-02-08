using PizzaLib.model;

namespace ClassDemoPizzaApp.services
{
    public class PizzaRepositoryService : IPizzaRepositoryService
    {
        private List<Pizza> _liste = new List<Pizza>()
        {
            new Pizza(1,"peter",55),
            new Pizza(2,"jakob",45),
            new Pizza(3,"vibeke",52)

        };


        public Pizza Delete(int id)
        {
            Pizza pizza = GetById(id); // kan kaste KeyNotFoundException

            _liste.Remove(pizza);
            return pizza;
        }

        public List<Pizza> GetAll()
        {
            return new List<Pizza>(_liste);
        }

        public Pizza GetById(int id)
        {
            foreach (Pizza p in _liste)
            {
                if (p.Id == id)
                {
                    return p;
                }
            }

            throw new KeyNotFoundException();
        }
    }
}
