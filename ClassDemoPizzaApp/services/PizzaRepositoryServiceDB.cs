using PizzaLib.model;
using System;
using System.Data.SqlClient;

namespace ClassDemoPizzaApp.services
{
    public class PizzaRepositoryServiceDB : IPizzaRepositoryService
    {


        public Pizza Create(Pizza pizza)
        {
            String sql = "insert into Pizza values(@Name, @Pris)";

            // forbindelse
            SqlConnection conn = new SqlConnection(Secret.GetConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            //cmd.Parameters.AddWithValue("@ID", pizza.Id); // blliver lavet i databasen
            cmd.Parameters.AddWithValue("@Name", pizza.Name);
            cmd.Parameters.AddWithValue("@Pris", pizza.Pris);
            

            int row = cmd.ExecuteNonQuery();

            if (row == 1)
            {
                return pizza;
            }
            else
            {
                return null; // eller exception
            }
        }

        public Pizza Delete(int id)
        {
            // finder først personen
            Pizza p = GetById(id);
            if (p is null)
            {
                return null;
            }

            String sql = "delete from Pizza where Id = @ID";

            // forbindelse
            SqlConnection conn = new SqlConnection(Secret.GetConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ID", id);


            int row = cmd.ExecuteNonQuery();

            if (row == 1)
            {
                return p;
            }
            else
            {
                return null; // eller exception
            }
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
            SqlConnection conn = new SqlConnection(Secret.GetConnectionString);
            conn.Open();

            String sql = "select * from Pizza where Id = @ID";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ID", id);

            SqlDataReader reader = cmd.ExecuteReader();

            
            if (reader.Read())
            {
                return ReadPizza(reader);

            }

            throw new KeyNotFoundException();
        }

        public Pizza Update(int id, Pizza pizza)
        {
            String sql = "update Pizza set Name=@Name, Price=@Pris where Id = @ID";

            // forbindelse
            SqlConnection conn = new SqlConnection(Secret.GetConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Name", pizza.Name);
            cmd.Parameters.AddWithValue("@Pris", pizza.Pris);


            int row = cmd.ExecuteNonQuery();

            if (row == 1)
            {
                pizza.Id = id;
                return pizza;
            }
            else
            {
                return null; // eller exception
            }
        }
    }
}
