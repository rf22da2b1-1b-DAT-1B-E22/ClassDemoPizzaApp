﻿using PizzaLib.model;

namespace ClassDemoPizzaApp.services
{
    public interface IPizzaRepositoryService
    {
        public List<Pizza> GetAll();
        public Pizza GetById(int id);
        public Pizza Delete(int id);
        public Pizza Create(Pizza pizza);
        public Pizza Update(int id, Pizza pizza);


    }
}
