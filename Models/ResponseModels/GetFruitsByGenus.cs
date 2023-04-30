using System.Net;

namespace FruityViceApiIntegerationApp.Models.ResponseModels
{
    public class GetFruitsByGenus
    {
        public string name { get; set; }
        public int id { get; set; }
        public string family { get; set; }
        public string genus { get; set; }
        public string order { get; set; }
        public NutritionsBody nutritions { get; set; }
    }

    public class GetFruitsByGenusFinalResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public List<GetFruitsByGenus> getFruitsByGenus { get; set; }
    }
}
