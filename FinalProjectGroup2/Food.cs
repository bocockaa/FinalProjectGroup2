namespace FinalProjectGroup2
{
    public class Food
    {
        public int Id { get; set; }

        //Pizza, Sandwich, Chips, etc...
        public string Name { get; set; }

        //Sweet, salty, sour, bitter and umami
        public string Flavor { get; set; }

        //calories for the food
        public int Calories { get; set; }

        //is it vegan? true/false
        public bool Vegan {get; set; }
    }
}
