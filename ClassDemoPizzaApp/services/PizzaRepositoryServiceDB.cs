using PizzaLib.model;
using System.Data.SqlClient;

namespace ClassDemoPizzaApp.services
{
    public class PizzaRepositoryServiceDB : IPizzaRepositoryService
    {


        public Pizza Create(Pizza pizza)
        {
            throw new NotImplementedException();
        }

        public Pizza Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pizza> GetAll()
        {
            SqlConnection conn = new SqlConnection(Secret.GetConnectionString);
            conn.Open();

            String sql = "select * from Pizza";
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Pizza> pizzaer = new List<Pizza>();
            while (reader.Read()) {
                pizzaer.Add(ReadPizza(reader));
            
            }
            return pizzaer;
        }

        private Pizza ReadPizza(SqlDataReader reader)
        {
            Pizza pizza = new Pizza();

            pizza.Id = reader.GetInt32(0);
            pizza.Name = reader.GetString(1);
            pizza.Pris = reader.GetDouble(2);



            return pizza;
        }

        public Pizza GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Pizza Update(int id, Pizza pizza)
        {
            throw new NotImplementedException();
        }
    }
}
