using PizzaLib.model;

namespace ClassDemoPizzaApp.services
{
    public class PizzaRepositoryServiceDBEF : IPizzaRepositoryService
    {
        private PizzaDBContext _db = new PizzaDBContext();



        public Pizza Create(Pizza pizza)
        {
            _db.Pizza.Add(pizza);
            _db.SaveChanges(); // Husk
            return pizza;
        }

        public Pizza Delete(int id)
        {
            Pizza? pizza = GetById(id); // kaster en exception hvis den ikke findes

            _db.Pizza.Remove(pizza);
            _db.SaveChanges();

            return pizza;
        }

        public List<Pizza> GetAll()
        {
            return new List<Pizza>(_db.Pizza);
        }

        public Pizza GetById(int id)
        {
            Pizza? pizza = GetAll().FirstOrDefault(x => x.Id == id);
            if (pizza == null)
            {
                throw new KeyNotFoundException();
            }

            return pizza;
        }

        public Pizza Update(int id, Pizza pizza)
        {
            Pizza? updatepizza = GetById(id); // kaster en exception hvis den ikke findes

            _db.Pizza.Update(updatepizza);
            _db.SaveChanges();

            return pizza;
        }
    }
}
