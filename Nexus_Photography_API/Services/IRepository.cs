using Nexus_Photography_API.DBContext.Entities.TableEntities;
using Nexus_Photography_API.Models.DTOs;
using Nexus_Photography_API.Models.Response;

namespace Nexus_Photography_API.Services
{
    public interface IRepository
    {
        //Couple Films
        Task<List<CoupleFilm>> GetCoupleflimsAsync();
        Task<APIResponse> AddCoupleFilmAsync(CoupleFilmsDTO entity);
        Task<bool> UpdateCoupleFilmAsync(CoupleFilm entity);
        Task<bool> DeleteCoupleFilmAsync(int id);
    }
}
