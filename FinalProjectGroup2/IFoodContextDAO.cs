using System.Collections.Generic;
using FinalProjectGroup2.Data;

namespace FinalProjectGroup2.Interfaces
{
    public interface IFoodContextDAO
    {
        List<Food> GetAllFoods();

        Food GetFoodById(int id);

        int? RemoveFoodById(int id);

        int? UpdateFood(Food food);

    }

}