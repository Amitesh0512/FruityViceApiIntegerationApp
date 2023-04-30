using FruityViceApiIntegerationApp.Models.ResponseModels;

namespace FruityViceApiIntegerationApp.Interfaces
{
    public interface IGetFruitsByGenus
    {
        Task<GetFruitsByGenusFinalResponse> GetFruitsByFamilyAsync(string familyName);
    }
}
