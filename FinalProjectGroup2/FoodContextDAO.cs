using System.Collections.Generic;
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

        public Food RemoveFoodById(int id)
        {
            var food = this.GetFoodById(id);
            if (food == null) return null;
            try
            {
                _context.Foods.Remove(food);
                _context.SaveChanges();
                return food;
            }
            catch(Exception)
            {
                return new Food();
            }
        }
    }
}