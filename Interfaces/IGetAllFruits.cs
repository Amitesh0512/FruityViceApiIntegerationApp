using FruityViceApiIntegerationApp.Models.ResponseModels;

namespace FruityViceApiIntegerationApp.Interfaces
{
    public interface IGetAllFruits
    {
        Task<AllFruitsResponse> GetAllFruitsAsync();
    }
}
