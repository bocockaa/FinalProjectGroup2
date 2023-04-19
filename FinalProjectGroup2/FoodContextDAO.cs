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

        public Food GetFood(int id)
        {
            return _context.Foods.Where(x => x.Id.Equals(id)).firstOrDefault;
        }
    }
}