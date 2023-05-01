using System.Net;

namespace FruityViceApiIntegerationApp.Models.ResponseModels
{
    public class GetAllFruitsResponse
    {
        public string name { get; set; }
        public int id { get; set; }
        public string family {get; set; }
        public string genus { get; set; }
        public string order { get; set; }
        public NutritionsBody nutritions { get; set; }
    }

    public class NutritionsBody
    {
        public double carbohydrates { get; set; }
        public double protein { get; set; }
        public double fat { get; set; }
        public double calories { get; set; }
        public double sugar { get; set; }
    }

    public class AllFruitsResponse
    {
        public string Message { get; set; }
        public List<GetAllFruitsResponse> getAllFruits { get; set; }
    }
}
