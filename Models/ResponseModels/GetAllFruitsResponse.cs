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
        public int carbohydrates { get; set; }
        public int protein { get; set; }
        public int fat { get; set; }
        public int calories { get; set; }
        public int sugar { get; set; }
    }

    public class AllFruitsResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public List<GetAllFruitsResponse> getAllFruits { get; set; }
    }
}
