using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using FinalProjectGroup2.Interfaces;

namespace FinalProjectGroup2.Data
{
    public class FoodContextDAO : IFoodContextDAO
    {
        private FoodContext _context;

        public FoodContextDAO(FoodContext context)
        {
            _context = context;
        }

        public List<Food> GetAllFoods()
        {
            return _context.Foods.ToList();
        }

        public Food GetFoodById(int id)
        {
            return _context.Foods.Where(x => x.Id.Equals(id)).firstOrDefault();
        }

        public int? RemoveFoodById(int id)
        {
            var food = this.GetFoodById(id);
            if (food == null) return null;
            try
            {
                _context.Foods.Remove(food);
                _context.SaveChanges();
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }
        }

        public int? UpdateFood(Food food)
        {
            var foodUpdate = this.GetFoodById(food.Id);
            if (foodUpdate == null) return null;

            //{Id = 1, Name = "Pizza", Flavor = "Umami", Calories = 1000, Vegan = false},
            foodUpdate.Name = food.Name;
            foodUpdate.Flavor = food.Flavor;
            foodUpdate.Calories = food.Calories;
            foodUpdate.Vegan = food.Vegan;


            try
            {
                _context.Foods.Update(foodUpdate);
                _context.SaveChanges();
                return 1;
            } catch (Exception)
            {
                return 0;
            }
        }

        public int? Add(Food food)
        {
            //new Food { Id = 1, Name = "Pizza", Flavor = "Umami", Calories = 1000, Vegan = false },
            var foods = _context.Foods.Where(x => x.Name.Equals(food.Name) && x => x.Flavor.Equals(food.Flavor) && x => x.Calories == food.Calories && x => x.Vegan == food.Vegan);

            if (food != null)
            {
                return null;
            }

            try
            {
                _context.Foods.Add(food);
                _context.SaveChanges();
                return 1;
            } catch (Exception)
            {
                return 0;
            }
        }
    }
}